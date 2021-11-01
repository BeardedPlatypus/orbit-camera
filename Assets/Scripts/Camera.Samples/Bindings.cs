using System;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace BeardedPlatypus.Camera.Samples
{
    /// <summary>
    /// <see cref="Bindings"/> implements the boilerplate to connect the InputActions
    /// to the <see cref="IBindings"/> interface.
    /// </summary>
    public sealed class Bindings : MonoBehaviour, Camera.IBindings
    {
        private CameraInputActions _inputActions;
 
        [Inject]
        private void Init(CameraInputActions inputActions)
        {
            _inputActions = inputActions;
        }
        
        /// <inheritdoc cref="IBindings"/>
        public IObservable<Vector2> Orbit { get; private set; }
        /// <inheritdoc cref="IBindings"/>
        public IObservable<Vector3> Translate { get; private set; }
        /// <inheritdoc cref="IBindings"/>
        public IObservable<float> Zoom { get; private set; }

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
            ConfigureOrbitObservable();
            ConfigureTranslateObservable();
            ConfigureZoomObservable();
        }
        
        private void ConfigureOrbitObservable()
        {

            IObservable<Vector2> dragStream = _inputActions.Camera.Drag.ActionAsObservable()
                .Select(InterpretAs<Vector2>);

            var isOrbitingStream = _inputActions.Camera.OrbitActive.ActionAsObservable()
                .Select(InterpretAsBool)
                .DistinctUntilChanged();

            Orbit = isOrbitingStream.CombineLatest(dragStream, (isActive, direction) => (isActive, direction))
                .Where(x => x.isActive)
                .Select(x => x.direction);
        }

        private void ConfigureTranslateObservable()
        {
            // TODO: Placeholder
            Translate = Observable.Empty<Vector3>();
        }

        private void ConfigureZoomObservable()
        {
            // TODO: Placeholder
            Zoom = Observable.Empty<float>();
        }

        private static T InterpretAs<T>(InputAction.CallbackContext context) where T : struct => 
            context.ReadValue<T>();
        private static bool InterpretAsBool(InputAction.CallbackContext context) => 
            context.ReadValue<float>() != 0F;
    }
}
