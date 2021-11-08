using System.Collections;
using BeardedPlatypus.Camera.Core;
using BeardedPlatypus.Camera.Core.Behaviours;
using BeardedPlatypus.Camera.Presets.Common;
using UnityEngine;

namespace BeardedPlatypus.Camera.Presets.SetOrbit
{
    public sealed class SmoothSetOrbitBehaviour : ISetOrbitBehaviour
    {
        private readonly float _maxTransitionTime;
        private readonly ICoroutineRunner _runner;

        public SmoothSetOrbitBehaviour(float maxTransitionTime, ICoroutineRunner runner)
        {
            _maxTransitionTime = maxTransitionTime;
            _runner = runner;
        }

        public void OnSetOrbit(Vector2 rotation, IOrbitCenter orbitCenter, Transform cameraTransform) =>
            _runner.Run(RotateSmooth(rotation, orbitCenter.Location, cameraTransform));

        private IEnumerator RotateSmooth(Vector2 rotation,
                                         Vector3 orbitCenter,
                                         Transform cameraTransform)
        {
            float rotationX = CalculateRotationX(rotation.x, orbitCenter, cameraTransform);
            float rotationY = CalculateRotationY(rotation.y, cameraTransform);

            float transitionTimeX = Mathf.Abs(rotationX) * (_maxTransitionTime / 90F);
            float transitionTimeY = Mathf.Abs(rotationY) * (_maxTransitionTime / 180F);
            float timeFactor = 1.0F / Mathf.Max(transitionTimeX, transitionTimeY);

            for (var t = 0.0F; t < 1.0F; t += Time.deltaTime * timeFactor)
            {
                var rotationFactor = Time.deltaTime * timeFactor;
                
                Vector3 axisX = cameraTransform.TransformVector(Vector3.right);
                cameraTransform.RotateAround(orbitCenter, axisX, rotationFactor * rotationX);
                cameraTransform.RotateAround(orbitCenter, Vector3.up, rotationFactor * rotationY);
                
                yield return null;
            }
        }

        private static float CalculateRotationX(float goalRotation,
                                                Vector3 orbitCenter,
                                                Transform cameraTransform)
        {
            Vector3 axis = cameraTransform.TransformVector(Vector3.right);
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