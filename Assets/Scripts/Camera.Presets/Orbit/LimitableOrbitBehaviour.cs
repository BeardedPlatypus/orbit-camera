using BeardedPlatypus.Camera.Core;
using BeardedPlatypus.Camera.Core.Behaviours;
using UnityEngine;

namespace BeardedPlatypus.Camera.Presets.Orbit
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
            var worldX = cameraTransform.TransformVector(Vector3.left);
            var currentRotation = CalculateCameraRotationAroundX(cameraTransform);
            
            // Note the negative sign of the newRotation, this is necessary to ensure we
            // rotate in the same direction as the mouse movement.
            float clampedRotation = Mathf.Clamp(-rotation * Mathf.Deg2Rad,
                                                -currentRotation + _settings.Limit.X.Min * Mathf.Deg2Rad,
                                                _settings.Limit.X.Max * Mathf.Deg2Rad - currentRotation) 
                * -Mathf.Rad2Deg;
            
            cameraTransform.RotateAround(orbitCenter, worldX, clampedRotation);
        }
        
        private static float CalculateCameraRotationAroundX(Transform cameraTransform)
        {
            Vector3 position = cameraTransform.position;
            float distance = Vector3.Distance(position, Vector3.zero);
            return Mathf.Asin(position.y / distance);
        }
        
        private void RotateAroundY(float rotation, 
                                   Vector3 orbitCenter, 
                                   Transform cameraTransform)
        {
            float currentRotation = CalculateCameraRotationAroundY(cameraTransform);
            float min = -currentRotation + _settings.Limit.Y.Min;
            float max = _settings.Limit.Y.Max - currentRotation;

            float clampedRotation = Mathf.Clamp(rotation, min, max);
            cameraTransform.RotateAround(orbitCenter, Vector3.up, clampedRotation);
        }

        private static float CalculateCameraRotationAroundY(Transform cameraTransform)
        {
            float rot = cameraTransform.rotation.eulerAngles.y;
            // We evaluate the range between -180F and 180F, however
            // The euler values will be reported between 0 - 360, as 
            // such we need shift our scale.
            return rot <= 180F ? rot : rot - 360.0F;
        }
    }
}