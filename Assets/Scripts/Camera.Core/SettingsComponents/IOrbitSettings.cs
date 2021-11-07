namespace BeardedPlatypus.Camera.Core.SettingsComponents
{
    /// <summary>
    /// <see cref="IOrbitSettings"/> defines the settings related to the orbit
    /// behaviour of the Camera.
    /// </summary>
    public interface IOrbitSettings
    {
        /// <summary>
        /// Gets the orbit factor.
        /// </summary>
        public float Factor { get; }

        /// <summary>
        /// Gets the range of valid rotations values around the x-axis in degrees.
        /// </summary>
        /// <remarks>
        /// It is expected that RangeX.Min is smaller than RangeX.Max, and that the
        /// these values are between -90 and 90 degrees.
        /// </remarks>
        public (float Min, float Max) RangeX { get; }
        
        /// <summary>
        /// Gets the range of valid rotations values around the y-axis in degrees.
        /// </summary>
        /// <remarks>
        /// It is expected that RangeX.Min is smaller than RangeX.Max, and that the
        /// these values are either negative and positive infinity or between
        /// -180 and 180 degrees.
        /// </remarks>
        public (float Min, float Max) RangeY { get; }
    }
}