using UnityEngine;

namespace BeardedPlatypus.Camera.Core.Behaviours
{
    /// <summary>
    /// <see cref="IOrbitBehaviour"/> defines the interface with which the <see cref="Controller"/>
    /// performs the orbit behaviour.
    /// </summary>
    public interface IOrbitBehaviour
    {
        /// <summary>
        /// Converts the <see cref="inputDirection"/> into a rotation
        /// and applies it to the <see cref="cameraTransform"/>
        /// </summary>
        /// <param name="inputDirection">The input direction.</param>
        /// <param name="orbitCenter">The center around which to orbit.</param>
        /// <param name="cameraTransform">The transform of the camera to be adjusted.</param>
        void OnOrbit(Vector2 inputDirection,
                     IOrbitCenter orbitCenter,
                     Transform cameraTransform);
    }
}
