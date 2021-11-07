using UnityEngine;

namespace BeardedPlatypus.Camera.Presets.Translate
{
    /// <summary>
    /// <see cref="LimitableTranslateSettingsScriptableObject"/> provides the
    /// <see cref="ILimitableTranslateSettings"/> as a <see cref="ScriptableObject"/> to be
    /// used within the camera setup.
    /// </summary>
    [CreateAssetMenu(fileName="LimitableTranslateSettings", 
                     menuName="BeardedPlatypus/Camera/LimitableTranslateSettings")]
    public sealed class LimitableTranslateSettingsScriptableObject : ScriptableObject, 
                                                                     ILimitableTranslateSettings
    {
        /// <summary>
        /// The orbit factor with which orbiting rotation is scaled.
        /// </summary>
        [SerializeField] private float factor = 0.005F;
        
        /// <summary>
        /// The center from which the limits are calculated.
        /// </summary>
        [SerializeField] private Vector3 center = Vector3.zero;
        
        // TODO: Consider replacing this with vectors.
        /// <summary>
        /// The smallest allowed position on the y-axis.
        /// </summary>
        [SerializeField] private float limitXMin = float.NegativeInfinity;
        
        /// <summary>
        /// The largest allowed position on the y-axis.
        /// </summary>
        [SerializeField] private float limitXMax = float.PositiveInfinity;
        
        /// <summary>
        /// The smallest allowed position on the y-axis.
        /// </summary>
        [SerializeField] private float limitYMin = float.NegativeInfinity;
        
        /// <summary>
        /// The largest allowed position on the y-axis.
        /// </summary>
        [SerializeField] private float limitYMax = float.PositiveInfinity;
        
        /// <summary>
        /// The smallest allowed position on the y-axis.
        /// </summary>
        [SerializeField] private float limitZMin = float.NegativeInfinity;
        
        /// <summary>
        /// The largest allowed position on the y-axis.
        /// </summary>
        [SerializeField] private float limitZMax = float.PositiveInfinity;

        /// <inheritdoc cref="ITranslationSettings"/>
        public float Factor => factor;

        /// <inheritdoc cref="ITranslationSettings"/>
        public Vector3 Center => center;

        /// <inheritdoc cref="ITranslationSettings"/>
        public ((float Min, float Max) X, (float Min, float Max) Y, (float Min, float Max) Z) Limit =>
            ((limitXMin, limitXMax), (limitYMin, limitYMax), (limitZMin, limitZMax));
    }
}