using UnityEngine;

namespace BeardedPlatypus.Camera.Core.SettingsComponents
{
    /// <summary>
    /// <see cref="OrbitSettingsScriptableObject"/> provides the <see cref="IOrbitSettings"/>
    /// as a <see cref="ScriptableObject"/> to be used within the camera setup.
    /// </summary>
    [CreateAssetMenu(fileName="OrbitSettings", menuName="BeardedPlatypus/Camera/OrbitSettings")]
    public sealed class OrbitSettingsScriptableObject : ScriptableObject, IOrbitSettings
    {
        /// <summary>
        /// The orbit factor with which orbiting rotation is scaled.
        /// </summary>
        [SerializeField] private float factor = 0.05F;
        
        // TODO: Extend the logic such that only values between these are accepted.
        
        /// <summary>
        /// The smallest allowed rotation around the x-axis in degrees.
        /// </summary>
        [SerializeField] private float rangeXMin = -90.0F;
        
        /// <summary>
        /// The largest allowed rotation around the x-axis in degrees.
        /// </summary>
        [SerializeField] private float rangeXMax = 90.0F;
        
        /// <summary>
        /// The smallest allowed rotation around the y-axis in degrees.
        /// </summary>
        [SerializeField] private float rangeYMin = float.NegativeInfinity;
        
        /// <summary>
        /// The largest allowed rotation around the y-axis in degrees.
        /// </summary>
        [SerializeField] private float rangeYMax = float.PositiveInfinity;

        /// <inheritdoc cref="IOrbitSettings" />
        public float Factor => factor;
        /// <inheritdoc cref="IOrbitSettings" />
        public (float Min, float Max) RangeX => (rangeXMin, rangeXMax);
        /// <inheritdoc cref="IOrbitSettings" />
        public (float Min, float Max) RangeY => (rangeYMin, rangeYMax);
    }
}
