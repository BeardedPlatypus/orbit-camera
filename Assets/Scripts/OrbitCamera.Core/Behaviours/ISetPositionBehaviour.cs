using UnityEngine;

namespace BeardedPlatypus.OrbitCamera.Core.Behaviours
{
    /// <summary>
    /// <see cref="ISetPositionBehaviour"/> defines the interface with which the
    /// <see cref="Controller"/> can set the position of the camera system.
    /// </summary>
    public interface ISetPositionBehaviour
    {
        /// <summary>
        /// Sets the specified <see cref="position"/> of the camera system.
        /// </summary>
        /// <param name="position">The new position of the camera system.</param>
        /// <param name="orbitCenter">The center around which to orbit.</param>
        /// <param name="cameraTransform">The transform of the camera to be adjusted.</param>
        void OnSetPosition(Vector3 position,
                           IOrbitCenter orbitCenter,
                           Transform cameraTransform);
    }
}