using UnityEngine;

namespace BeardedPlatypus.Camera.Core.Behaviours
{
    /// <summary>
    /// <see cref="ISetZoomBehaviour"/> defines the interface with which the
    /// <see cref="Controller"/> can set the zoom of the camera system.
    /// </summary>
    public interface ISetZoomBehaviour
    {
        /// <summary>
        /// Sets the specified <see cref="zoom"/> of the camera system.
        /// </summary>
        /// <param name="zoom">The new zoom of the camera system.</param>
        /// <param name="orbitCenter">The center around which to orbit.</param>
        /// <param name="cameraTransform">The transform of the camera to be adjusted.</param>
        void OnSetZoom(float zoom,
                       IOrbitCenter orbitCenter,
                       Transform cameraTransform);
    }
}