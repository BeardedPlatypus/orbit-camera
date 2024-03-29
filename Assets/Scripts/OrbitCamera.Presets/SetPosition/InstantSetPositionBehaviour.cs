﻿using BeardedPlatypus.OrbitCamera.Core;
using BeardedPlatypus.OrbitCamera.Core.Behaviours;
using UnityEngine;

namespace BeardedPlatypus.OrbitCamera.Presets.SetPosition
{
    /// <summary>
    /// <see cref="InstantSetPositionBehaviour"/> provides the default implementation
    /// of the <see cref="ISetPositionBehaviour"/>. It will rotate the camera
    /// to the specified rotation immediately.
    /// </summary>
    public sealed class InstantSetPositionBehaviour : ISetPositionBehaviour
    {
        public void OnSetPosition(Vector3 position, IOrbitCenter orbitCenter, Transform cameraTransform)
        {
            var cameraOffset = cameraTransform.position - orbitCenter.Location;
            orbitCenter.MoveTo(position);
            cameraTransform.SetPositionAndRotation(position + cameraOffset, cameraTransform.rotation);
        }
    }
}