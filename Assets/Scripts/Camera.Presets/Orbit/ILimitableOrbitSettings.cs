using Camera.Presets.Orbit;

namespace BeardedPlatypus.Camera.Presets.Orbit
{
    /// <summary>
    /// <see cref="ILimitableOrbitSettings"/> defines the settings related to the
    /// <see cref="LimitableOrbitBehaviour"/>.
    /// </summary>
    public interface ILimitableOrbitSettings
    {
        /// <summary>
        /// Gets the orbit factor.
        /// </summary>
        public float Factor { get; }

        /// <summary>
        /// Gets the x and y axis rotation limits in degrees.
        /// </summary>
        /// <remarks>
        /// It is expected that Limit.X.Min is smaller than Limit.X.Max, and that the
        /// these values are between -90 and 90 degrees.
        /// It is expected that Limit.Y.Min is smaller than Limit.Y.Max, and that
        /// these values are either infinite or between -180 and 180 degrees.
        /// </remarks>
        public ((float Min, float Max) X, (float Min, float Max) Y) Limit { get; }
    }
}