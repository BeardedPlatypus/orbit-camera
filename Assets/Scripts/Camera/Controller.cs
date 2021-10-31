using System;
using JetBrains.Annotations;
using UniRx;
using UnityEngine;

namespace BeardedPlatypus.Camera
{
    /// <summary>
    /// <see cref="Controller"/> the controller is responsible for controlling the
    /// provided <see cref="VirtualCameraTransform"/> based upon the provided
    /// <see cref="IBindings"/> and <see cref="Settings"/>.
    /// </summary>
    public sealed class Controller : IDisposable
    {
        private readonly CompositeDisposable _disposable = new CompositeDisposable();
        
        // Currently, we assume the bindings and settings do never change.
        private readonly IBindings _bindings;
        private readonly Settings _settings;

        /// <summary>
        /// Construct a new <see cref="Controller"/> with the given parameters.
        /// </summary>
        /// <param name="bindings">
        /// The bindings which provide the input for the controller.
        /// </param>
        /// <param name="settings">
        /// The settings which provide the behaviour definition of the controller.
        /// </param>
        public Controller(IBindings bindings, Settings settings)
        {
            _bindings = bindings;
            _settings = settings;
            
            ConfigureSubscriptions();
        }

        /// <summary>
        /// Gets the <see cref="Transform"/> of the Virtual Camera that is currently
        /// controlled by this <see cref="Controller"/>.
        /// </summary>
        /// <remarks>
        /// If set to <c>null</c>, the controller will not update anything.
        /// </remarks>
        [CanBeNull] public Transform VirtualCameraTransform { get; set; } = null;

        private void ConfigureSubscriptions()
        {
            _bindings.Orbit.Subscribe(OnOrbit).AddTo(_disposable);
            _bindings.Translate.Subscribe(OnTranslate).AddTo(_disposable);
            _bindings.Zoom.Subscribe(OnZoom).AddTo(_disposable);
        }

        private void OnOrbit(Vector2 inputTranslation)
        {
            if (!IsOrbitEnabled() || VirtualCameraTransform is null) return;
            Vector2 rotation = inputTranslation * _settings.Orbit.Factor;

            var orbitCenter = Vector3.zero;
            var worldX = VirtualCameraTransform.TransformVector(Vector3.left);

            float rotationAroundX = ClampRotation(rotation.y);
            
            VirtualCameraTransform.RotateAround(orbitCenter, worldX, rotationAroundX);
            VirtualCameraTransform.RotateAround(orbitCenter, Vector3.up, rotation.x);
        }

        private bool IsOrbitEnabled() => !(_settings.Orbit is null);
        
        private float ClampRotation(float newRotation)
        {
            // The rotation will be applied negatively due to rotating around the local x axis.
            // As such we need to invert the rotation during this calculation.
            float rotation = -newRotation * Mathf.Deg2Rad;
            float currentRotation = CameraRotationAroundX();

            float clampedRotation = Mathf.Clamp(rotation, 
                                                -currentRotation + _settings.Orbit.RangeX.Min * Mathf.Deg2Rad, 
                                                _settings.Orbit.RangeX.Max * Mathf.Deg2Rad - currentRotation);

            return -clampedRotation * Mathf.Rad2Deg;
        }

        private float CameraRotationAroundX()
        {
            Vector3 position = VirtualCameraTransform.position;
            float distance = Vector3.Distance(position, Vector3.zero);
            return Mathf.Asin(position.y / distance);
        }
        
        private void OnTranslate(Vector3 translation) { }
        
        private bool IsTranslateEnabled() => !(_settings.Translate is null);
        
        private void OnZoom(float zoomTranslation) { }
        
        private bool IsZoomEnabled() => !(_settings.Zoom is null);

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}
