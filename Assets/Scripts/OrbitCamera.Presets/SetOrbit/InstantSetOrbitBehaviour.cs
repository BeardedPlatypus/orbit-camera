﻿using BeardedPlatypus.OrbitCamera.Core;
using BeardedPlatypus.OrbitCamera.Core.Behaviours;
using BeardedPlatypus.OrbitCamera.Presets.Common;
using UnityEngine;

namespace BeardedPlatypus.OrbitCamera.Presets.SetOrbit
{
    /// <summary>
    /// <see cref="InstantSetOrbitBehaviour"/> provides the default implementation
    /// of the <see cref="ISetOrbitBehaviour"/>. It will rotate the camera
    /// to the specified rotation immediately.
    /// </summary>
    public sealed class InstantSetOrbitBehaviour : ISetOrbitBehaviour
    {
        /// <inheritdoc cref="ISetOrbitBehaviour"/>>
        public void OnSetOrbit(Vector2 rotation, IOrbitCenter orbitCenter, Transform cameraTransform)
        {
            RotateAroundX(rotation.x, orbitCenter.Location, cameraTransform);
            RotateAroundY(rotation.y, orbitCenter.Location, cameraTransform);
        }

        private static void RotateAroundX(float rotation, Vector3 orbitCenter, Transform cameraTransform)
        {
            Vector3 axis = cameraTransform.TransformVector(Vector3.right);
            float currentRotation = RotationCalculator.CalculateRotationAroundX(cameraTransform.position,
                                                                                orbitCenter);
            cameraTransform.RotateAround(orbitCenter, axis, rotation - currentRotation);
        }

        private static void RotateAroundY(float rotation, Vector3 orbitCenter, Transform cameraTransform) => 
            cameraTransform.RotateAround(orbitCenter, 
                                         Vector3.up, 
                                         rotation - cameraTransform.eulerAngles.y);
    }
}