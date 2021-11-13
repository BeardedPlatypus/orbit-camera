using UnityEngine;

namespace BeardedPlatypus.OrbitCamera.Core.Behaviours
{
    /// <summary>
    /// <see cref="ISetOrbitBehaviour"/> defines the interface with which the
    /// <see cref="Controller"/> can set the orbit given a rotation.
    /// </summary>
    public interface ISetOrbitBehaviour
    {
        /// <summary>
        /// Sets the specified <see cref="rotation"/> on the
        /// <paramref name="cameraTransform"/>.
        /// </summary>
        /// <param name="rotation">The rotation in degrees.</param>
        /// <param name="orbitCenter">The center around which to orbit.</param>
        /// <param name="cameraTransform">The transform of the camera to be adjusted.</param>
        void OnSetOrbit(Vector2 rotation,
                        IOrbitCenter orbitCenter,
                        Transform cameraTransform);
    }
}