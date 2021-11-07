using UnityEngine;

namespace BeardedPlatypus.Camera.Presets.Translate
{
    /// <summary>
    /// <see cref="ILimitableTranslateSettings"/> defines the settings related to the
    /// <see cref="LimitableTranslateBehaviour"/>.
    /// </summary>
    public interface ILimitableTranslateSettings
    {
        /// <summary>
        /// Gets the translation factor.
        /// </summary>
        public float Factor { get; }
        
        /// <summary>
        /// Gets the center around which the limits are calculated.
        /// </summary>
        public Vector3 Center { get; }

        /// <summary>
        /// Gets the x, y, and z axis translation limits in world space.
        /// </summary>
        public ((float Min, float Max) X, 
                (float Min, float Max) Y, 
                (float Min, float Max) Z) Limit { get; }
    }
}