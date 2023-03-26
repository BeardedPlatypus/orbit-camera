using System;
using BeardedPlatypus.OrbitCamera.Core;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;
using UniDi;

namespace BeardedPlatypus.OrbitCamera.Samples
{
    /// <summary>
    /// <see cref="Bindings"/> implements the boilerplate to connect the InputActions
    /// to the <see cref="IBindings"/> interface.
    /// </summary>
    public sealed class Bindings : MonoBehaviour, IBindings
    {
        private CameraInputActions _inputActions;
        private ResetViewController _resetViewController;
 
        [Inject]
        private void Init(CameraInputActions inputActions,
                          ResetViewController resetViewController)
        {
            _inputActions = inputActions;
            _resetViewController = resetViewController;
        }
        
        /// <inheritdoc cref="IBindings"/>
        public IObservable<Vector2> Orbit { get; private set; }
        /// <inheritdoc cref="IBindings"/>
        public IObservable<Vector3> Translate { get; private set; }
        /// <inheritdoc cref="IBindings"/>
        public IObservable<float> Zoom { get; private set; }

        public IObservable<Vector2> SetOrbit { get; private set; }
        public IObservable<Vector3> SetPosition { get; private set; }
        public IObservable<float> SetZoom { get; private set; }

        private void Awake()
        {
            ConfigureObservables();
        }

        private void Start()
        {
            _inputActions.Enable();
        }

        private void ConfigureObservables()
        {
            IObservable<Vector2> dragStream = _inputActions.Camera.Drag.ActionAsObservable()
                .Select(InterpretAs<Vector2>);

            ConfigureOrbitObservable(dragStream);
            ConfigureTranslateObservable(dragStream);
            ConfigureZoomObservable();

            ConfigureSetObservables();
        }
        
        private void ConfigureOrbitObservable(IObservable<Vector2> dragStream)
        {

            IObservable<bool> isOrbitingStream = _inputActions.Camera.OrbitActive.ActionAsObservable()
                .Select(InterpretAsBool)
                .DistinctUntilChanged();

            Orbit = isOrbitingStream.CombineLatest(dragStream, (isActive, direction) => (isActive, direction))
                .Where(x => x.isActive)
                .Select(x => x.direction);
        }

        private void ConfigureTranslateObservable(IObservable<Vector2> dragStream)
        {
            IObservable<bool> isTranslatingStream = _inputActions.Camera.TranslateActive.ActionAsObservable()
                .Select(InterpretAsBool)
                .DistinctUntilChanged();

            IObservable<bool> isAlternativeStream = _inputActions.Camera.TranslateAlt.ActionAsObservable()
                .Select(InterpretAsBool)
                .StartWith(false)
                .DistinctUntilChanged();

            Translate = isAlternativeStream
                .CombineLatest(dragStream, ToTranslation)
                .CombineLatest(isTranslatingStream, (translation, isActive) => (isActive, translation))
                .Where(x => x.isActive)
                .Select(x => x.translation);
        }

        private static Vector3 ToTranslation(bool isAlt, Vector2 dragDirection) =>
            isAlt ? new Vector3(dragDirection.x, dragDirection.y, 0F)
                  : new Vector3(dragDirection.x, 0F, dragDirection.y);

        private void ConfigureZoomObservable()
        {
            Zoom = _inputActions.Camera.Zoom.ActionAsObservable()
                                            .Select(InterpretAs<float>);
        }

        private static T InterpretAs<T>(InputAction.CallbackContext context) where T : struct => 
            context.ReadValue<T>();
        private static bool InterpretAsBool(InputAction.CallbackContext context) => 
            context.ReadValue<float>() != 0F;

        private void ConfigureSetObservables()
        {
            // In the future other streams that work with the set behaviour can be mixed in here.
            SetOrbit = _resetViewController.ResetOrbitObservable;
            SetPosition = _resetViewController.ResetPositionObservable;
            SetZoom = _resetViewController.ResetZoomObservable;
        }
    }
}
