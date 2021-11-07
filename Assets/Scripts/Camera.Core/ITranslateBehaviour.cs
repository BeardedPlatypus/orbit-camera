using UnityEngine;

namespace BeardedPlatypus.Camera.Core
{
    /// <summary>
    /// <see cref="ITranslateBehaviour"/> defines the interface with which the
    /// <see cref="Controller"/> performs the translation behaviour.
    /// </summary>
    public interface ITranslateBehaviour
    {
        /// <summary>
        /// OnTranslate converts the <see cref="inputTranslation"/> in the
        /// appropriate translation and applies it to both the
        /// <paramref name="cameraTransform"/> and <paramref name="orbitCenter"/>.
        /// </summary>
        /// <param name="inputTranslation"></param>
        /// <param name="orbitCenter"></param>
        /// <param name="cameraTransform"></param>
        void OnTranslate(Vector3 inputTranslation,
                         IOrbitCenter orbitCenter,
                         Transform cameraTransform);

    }
}