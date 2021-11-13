using BeardedPlatypus.OrbitCamera.Core;
using BeardedPlatypus.OrbitCamera.Core.Behaviours;
using BeardedPlatypus.OrbitCamera.Presets.Common;
using UnityEngine;

namespace BeardedPlatypus.OrbitCamera.Presets.Orbit
{
    /// <summary>
    /// <see cref="LimitableOrbitBehaviour"/> implements the <see cref="IOrbitBehaviour"/>
    /// where the rotation around the x and y axis can be limited by the values contained in
    /// the <see cref="ILimitableOrbitSettings"/>.
    /// </summary>
    public sealed class LimitableOrbitBehaviour : IOrbitBehaviour
    {
        private readonly ILimitableOrbitSettings _settings;

        /// <summary>
        /// Creates a new <see cref="LimitableOrbitBehaviour"/> with the given
        /// <paramref name="settings"/>.
        /// </summary>
        /// <param name="settings">The settings which define the behaviour.</param>
        public LimitableOrbitBehaviour(ILimitableOrbitSettings settings)
        {
            _settings = settings;
        }
        
        /// <inheritdoc cref="IOrbitBehaviour"/>>
        public void OnOrbit(Vector2 inputDirection, 
                            IOrbitCenter orbitCenter, 
                            Transform cameraTransform)
        {
            Vector2 rotationInput = inputDirection * _settings.Factor;
            RotateAroundX(rotationInput.y,
                          orbitCenter.Location,
                          cameraTransform);
            RotateAroundY(rotationInput.x,
                          orbitCenter.Location,
                          cameraTransform);
        }

        private void RotateAroundX(float rotation, 
                                   Vector3 orbitCenter, 
                                   Transform cameraTransform)
        {
            var worldX = cameraTransform.TransformVector(Vector3.right);
            var currentRotation = 
                RotationCalculator.CalculateRotationAroundX(cameraTransform.position, 
                                                            orbitCenter);
            
            // Note the negative sign of the newRotation, this is necessary to ensure we
            // rotate in the same direction as the mouse movement.
            float clampedRotation = Mathf.Clamp(-rotation,
                                                -currentRotation + _settings.Limit.X.Min,
                                                _settings.Limit.X.Max - currentRotation);
            
            cameraTransform.RotateAround(orbitCenter, worldX, clampedRotation);
        }
        
        private void RotateAroundY(float rotation, 
                                   Vector3 orbitCenter, 
                                   Transform cameraTransform)
        {
            float currentRotation = 
                RotationCalculator.CalculateRotationAroundY(cameraTransform);
            float min = -currentRotation + _settings.Limit.Y.Min;
            float max = _settings.Limit.Y.Max - currentRotation;

            float clampedRotation = Mathf.Clamp(rotation, min, max);
            cameraTransform.RotateAround(orbitCenter, Vector3.up, clampedRotation);
        }
    }
}