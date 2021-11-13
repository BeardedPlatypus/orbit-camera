using UnityEngine;

namespace BeardedPlatypus.OrbitCamera.Presets.Orbit
{
    /// <summary>
    /// <see cref="LimitableOrbitSettingsScriptableObject"/> provides the
    /// <see cref="ILimitableOrbitSettings"/> as a <see cref="ScriptableObject"/>
    /// to be used within the camera setup.
    /// </summary>
    [CreateAssetMenu(fileName="LimitableOrbitSettings", 
                     menuName="BeardedPlatypus/Camera/LimitableOrbitSettings")]
    public sealed class LimitableOrbitSettingsScriptableObject : ScriptableObject, 
                                                                 ILimitableOrbitSettings
    {
        /// <summary>
        /// The orbit factor with which orbiting rotation is scaled.
        /// </summary>
        [SerializeField] private float factor = 0.05F;
        
        /// <summary>
        /// The smallest allowed rotation around the x-axis in degrees.
        /// </summary>
        [SerializeField] private float limitXMin = -90.0F;
        
        /// <summary>
        /// The largest allowed rotation around the x-axis in degrees.
        /// </summary>
        [SerializeField] private float limitXMax = 90.0F;
        
        /// <summary>
        /// The smallest allowed rotation around the y-axis in degrees.
        /// </summary>
        [SerializeField] private float limitYMin = float.NegativeInfinity;
        
        /// <summary>
        /// The largest allowed rotation around the y-axis in degrees.
        /// </summary>
        [SerializeField] private float limitYMax = float.PositiveInfinity;

        /// <inheritdoc cref="ILimitableOrbitSettings" />
        public float Factor => factor;

        /// <inheritdoc cref="ILimitableOrbitSettings" />
        public ((float Min, float Max) X, (float Min, float Max) Y) Limit =>
            ((limitXMin, limitXMax), (limitYMin, limitYMax));
    }
}