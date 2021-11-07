using UnityEngine;

namespace BeardedPlatypus.Camera.Core
{
    /// <summary>
    /// <see cref="IZoomBehaviour"/> defines the interface with which the <see cref="Controller"/>
    /// performs the zoom behaviour.
    /// </summary>
    public interface IZoomBehaviour
    {
        /// <summary>
        /// OnZoom converts the <see cref="inputZoom"/> into a translation
        /// and applies it to the <see cref="cameraTransform"/>
        /// </summary>
        /// <param name="inputZoom">The input zoom value.</param>
        /// <param name="orbitCenter">The center around which to orbit.</param>
        /// <param name="cameraTransform">The transform of the camera to be adjusted</param>
        void OnZoom(float inputZoom,
                    IOrbitCenter orbitCenter,
                    Transform cameraTransform);
    }
}