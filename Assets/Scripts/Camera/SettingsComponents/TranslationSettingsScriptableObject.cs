using UnityEngine;

namespace BeardedPlatypus.Camera.SettingsComponents
{
    /// <summary>
    /// <see cref="TranslationSettingsScriptableObject"/> provides the
    /// <see cref="ITranslationSettings"/> as a <see cref="ScriptableObject"/> to be
    /// used within the camera setup.
    /// </summary>
    [CreateAssetMenu(fileName="TranslationSettings", menuName="BeardedPlatypus/Camera/TranslationSettings")]
    public sealed class TranslationSettingsScriptableObject : ScriptableObject, ITranslationSettings
    {
        /// <summary>
        /// The orbit factor with which orbiting rotation is scaled.
        /// </summary>
        [SerializeField] private float factor = 0.005F;
        
        /// <summary>
        /// The smallest allowed position on the y-axis.
        /// </summary>
        [SerializeField] private float rangeXMin = float.NegativeInfinity;
        
        /// <summary>
        /// The largest allowed position on the y-axis.
        /// </summary>
        [SerializeField] private float rangeXMax = float.PositiveInfinity;
        
        /// <summary>
        /// The smallest allowed position on the y-axis.
        /// </summary>
        [SerializeField] private float rangeYMin = float.NegativeInfinity;
        
        /// <summary>
        /// The largest allowed position on the y-axis.
        /// </summary>
        [SerializeField] private float rangeYMax = float.PositiveInfinity;
        
        /// <summary>
        /// The smallest allowed position on the y-axis.
        /// </summary>
        [SerializeField] private float rangeZMin = float.NegativeInfinity;
        
        /// <summary>
        /// The largest allowed position on the y-axis.
        /// </summary>
        [SerializeField] private float rangeZMax = float.PositiveInfinity;

        /// <inheritdoc cref="ITranslationSettings"/>
        public float Factor => factor;
        /// <inheritdoc cref="ITranslationSettings"/>
        public (float Min, float Max) RangeX => (rangeXMin, rangeXMax);
        /// <inheritdoc cref="ITranslationSettings"/>
        public (float Min, float Max) RangeY => (rangeYMin, rangeYMax);
        /// <inheritdoc cref="ITranslationSettings"/>
        public (float Min, float Max) RangeZ => (rangeZMin, rangeZMax);
    }
}