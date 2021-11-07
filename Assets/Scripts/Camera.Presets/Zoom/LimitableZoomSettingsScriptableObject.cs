using UnityEngine;

namespace BeardedPlatypus.Camera.Presets.Zoom
{
    /// <summary>
    /// <see cref="LimitableZoomSettingsScriptableObject"/> provides the
    /// <see cref="ILimitableZoomSettings"/> as a <see cref="ScriptableObject"/> to be used
    /// within the camera setup.
    /// </summary>
    [CreateAssetMenu(fileName="LimitableZoomSettings", 
                     menuName="BeardedPlatypus/Camera/LimitableZoomSettings")]
    public class LimitableZoomSettingsScriptableObject : ScriptableObject,
                                                         ILimitableZoomSettings 
    {
        /// <summary>
        /// The zoom factor with which the zooming is scaled.
        /// </summary>
        [SerializeField] private float factor = 0.005F;

        /// <summary>
        /// The smallest allowed distance from the orbit center.
        /// </summary>
        [SerializeField] private float limitMin = 0.5F;
        
        /// <summary>
        /// The largest allowed distance from the orbit center.
        /// </summary>
        [SerializeField] private float limitMax = 5.0F;

        /// <inheritdoc cref="ILimitableZoomSettings"/>>
        public float Factor => factor;

        /// <inheritdoc cref="ILimitableZoomSettings"/>>
        public (float Min, float Max) Limit => (limitMin, limitMax);
    }
}