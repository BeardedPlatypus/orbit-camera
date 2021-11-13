using UnityEngine;

namespace BeardedPlatypus.OrbitCamera.Core
{
    /// <summary>
    /// <see cref="IOrbitCenter"/> defines the orbit center of a camera.
    /// </summary>
    public interface IOrbitCenter
    {
        /// <summary>
        /// Gets the location of this <see cref="IOrbitCenter"/>.
        /// </summary>
        Vector3 Location { get; }

        /// <summary>
        /// Translate this <see cref="IOrbitCenter"/> by the specified
        /// <see cref="translation"/>.
        /// </summary>
        /// <param name="translation"></param>
        void TranslateBy(Vector3 translation);

        /// <summary>
        /// Move this <see cref="IOrbitCenter"/> to <paramref name="newOrbitCenter"/>.
        /// </summary>
        /// <param name="newOrbitCenter">The new orbit center location.</param>
        void MoveTo(Vector3 newOrbitCenter);
    }
}