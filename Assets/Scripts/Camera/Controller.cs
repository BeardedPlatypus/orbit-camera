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
        // TODO: Should we decompose the Orbit, Zoom, and Translation further?
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
        /// Gets the orbit center around which rotations occur.
        /// </summary>
        public Vector3 OrbitCenter { get; } = Vector3.zero;

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

            RotateX(rotation.y, orbitCenter);
            RotateY(rotation.x, orbitCenter);
        }

        private void RotateX(float rotation, Vector3 orbitCenter)
        {
            var worldX = VirtualCameraTransform.TransformVector(Vector3.left);
            var currentRotation = CalculateCameraRotationAroundX();
            
            // Note the negative sign of the newRotation, this is necessary to ensure we
            // rotate in the same direction as the mouse movement.
            float clampedRotation = Mathf.Clamp(-rotation * Mathf.Deg2Rad,
                                                -currentRotation + _settings.Orbit.RangeX.Min * Mathf.Deg2Rad,
                                                _settings.Orbit.RangeX.Max * Mathf.Deg2Rad - currentRotation) 
                * -Mathf.Rad2Deg;
            
            VirtualCameraTransform.RotateAround(orbitCenter, worldX, clampedRotation);
        }

        private void RotateY(float rotation, Vector3 orbitCenter)
        {
            float _currentRotation = CalculateCameraRotationAroundY();
            float min = -_currentRotation + _settings.Orbit.RangeY.Min;
            float max = _settings.Orbit.RangeY.Max - _currentRotation;

            float clampedRotation = Mathf.Clamp(rotation, min, max);
            VirtualCameraTransform.RotateAround(orbitCenter, Vector3.up, clampedRotation);
        }

        private bool IsOrbitEnabled() => !(_settings.Orbit is null);
        
        private float CalculateCameraRotationAroundX()
        {
            Vector3 position = VirtualCameraTransform.position;
            float distance = Vector3.Distance(position, Vector3.zero);
            return Mathf.Asin(position.y / distance);
        }

        private float CalculateCameraRotationAroundY()
        {
            float rot = VirtualCameraTransform.rotation.eulerAngles.y;
            // We evaluate the range between -180F and 180F, however
            // The euler values will be reported between 0 - 360, as 
            // such we need shift our scale.
            return rot <= 180F ? rot : rot - 360.0F;
        }

        private void OnTranslate(Vector3 translation) { }
        
        private bool IsTranslateEnabled() => !(_settings.Translate is null);

        private void OnZoom(float zoomTranslation)
        {
            if (!IsZoomEnabled() || VirtualCameraTransform is null) return;

            float currDistance = Vector3.Distance(VirtualCameraTransform.position, OrbitCenter);
            float minTranslationDistance = _settings.Zoom.Range.Min - currDistance;
            float maxTranslationDistance = _settings.Zoom.Range.Max - currDistance;
            float inputTranslation = -zoomTranslation * _settings.Zoom.Factor;

            float translation = Mathf.Clamp(
                inputTranslation,
                minTranslationDistance,
                maxTranslationDistance
            );
            
            VirtualCameraTransform.Translate(new Vector3(0F, 0F, -translation));
        }
        
        private bool IsZoomEnabled() => !(_settings.Zoom is null);

        public void Dispose()
        {
            _disposable?.Dispose();
        }
    }
}
