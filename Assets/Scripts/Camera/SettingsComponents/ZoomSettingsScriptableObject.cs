using UnityEngine;

namespace BeardedPlatypus.Camera.SettingsComponents
{
    /// <summary>
    /// <see cref="ZoomSettingsScriptableObject"/> provides the
    /// <see cref="IZoomSettings"/> as a <see cref="ScriptableObject"/> to be used
    /// within the camera setup.
    /// </summary>
    [CreateAssetMenu(fileName="ZoomSettings", menuName="BeardedPlatypus/Camera/ZoomSettings")]
    public sealed class ZoomSettingsScriptableObject : ScriptableObject, IZoomSettings
    {
        /// <summary>
        /// The zoom factor with which the zooming is scaled.
        /// </summary>
        [SerializeField] private float factor = 0.005F;

        /// <summary>
        /// The smallest allowed distance from the orbit center.
        /// </summary>
        [SerializeField] private float rangeMin = 0.5F;
        
        /// <summary>
        /// The largest allowed distance from the orbit center.
        /// </summary>
        [SerializeField] private float rangeMax = 5.0F;

        /// <inheritdoc cref="IZoomSettings"/>>
        public float Factor => factor;

        /// <inheritdoc cref="IZoomSettings"/>>
        public (float Min, float Max) Range => (rangeMin, rangeMax);
    }
}