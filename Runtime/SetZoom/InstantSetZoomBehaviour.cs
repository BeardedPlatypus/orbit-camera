using BeardedPlatypus.OrbitCamera.Core;
using BeardedPlatypus.OrbitCamera.Core.Behaviours;
using UnityEngine;

namespace BeardedPlatypus.OrbitCamera.Presets.SetZoom
{
    /// <summary>
    /// <see cref="InstantSetZoomBehaviour"/> provides the default implementation
    /// of the <see cref="ISetZoomBehaviour"/>. It will rotate the camera
    /// to the specified rotation immediately.
    /// </summary>
    public sealed class InstantSetZoomBehaviour : ISetZoomBehaviour
    {
        public void OnSetZoom(float zoom, IOrbitCenter orbitCenter, Transform cameraTransform)
        {
            float currDistance = Vector3.Distance(cameraTransform.position, orbitCenter.Location);
            cameraTransform.Translate(new Vector3(0F, 0F, -(zoom - currDistance)));
        }
    }
}