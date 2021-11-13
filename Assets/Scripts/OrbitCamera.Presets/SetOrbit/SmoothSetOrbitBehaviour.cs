using System.Collections;
using BeardedPlatypus.OrbitCamera.Core;
using BeardedPlatypus.OrbitCamera.Core.Behaviours;
using BeardedPlatypus.OrbitCamera.Presets.Common;
using UnityEngine;

namespace BeardedPlatypus.OrbitCamera.Presets.SetOrbit
{
    /// <summary>
    /// <see cref="SmoothSetOrbitBehaviour"/> sets the provided rotation over
    /// the specified transition time.
    /// </summary>
    public sealed class SmoothSetOrbitBehaviour : ISetOrbitBehaviour
    {
        private readonly float _transitionTime;
        private readonly ICoroutineRunner _runner;

        /// <summary>
        /// Creates a new <see cref="SmoothSetOrbitBehaviour"/> with the given
        /// dependencies.
        /// </summary>
        /// <param name="transitionTime">The transition time.</param>
        /// <param name="runner">The coroutine runner.</param>
        public SmoothSetOrbitBehaviour(float transitionTime, ICoroutineRunner runner)
        {
            _transitionTime = transitionTime;
            _runner = runner;
        }
        
        /// <inheritdoc cref="ISetOrbitBehaviour.OnSetOrbit"/>
        public void OnSetOrbit(Vector2 rotation, IOrbitCenter orbitCenter, Transform cameraTransform) =>
            _runner.Run(RotateSmooth(rotation, orbitCenter, cameraTransform));

        private IEnumerator RotateSmooth(Vector2 rotation,
                                         IOrbitCenter orbitCenter,
                                         Transform cameraTransform)
        {
            float rotationX = CalculateRotationX(rotation.x, orbitCenter.Location, cameraTransform);
            float rotationY = CalculateRotationY(rotation.y, cameraTransform);

            float timeFactor = 1.0F / _transitionTime;

            for (var t = 0.0F; t < 1.0F; t += Time.deltaTime * timeFactor)
            {
                var rotationFactor = Time.deltaTime * timeFactor;
                cameraTransform.RotateAround(orbitCenter.Location, 
                                             cameraTransform.TransformVector(Vector3.right),
                                             rotationFactor * rotationX);
                cameraTransform.RotateAround(orbitCenter.Location, 
                                             Vector3.up, 
                                             rotationFactor * rotationY);
                
                yield return null;
            }
        }

        private static float CalculateRotationX(float goalRotation,
                                                Vector3 orbitCenter,
                                                Transform cameraTransform)
        {
            float currentRotation = RotationCalculator.CalculateRotationAroundX(cameraTransform.position,
                                                                                orbitCenter);
            return goalRotation - currentRotation;
        }

        private static float CalculateRotationY(float goalRotation,
                                                Transform cameraTransform)
        {
            var rotation = goalRotation - cameraTransform.eulerAngles.y;
            if (rotation > 180F) rotation -= 360.0F;
            else if (rotation < -180F) rotation += 360.0F;
            
            return rotation;
        }
    }
}