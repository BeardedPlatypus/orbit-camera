namespace BeardedPlatypus.Camera.CameraSettings
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
        public (float Min, float Max) RangeX { get; }
        
        /// <summary>
        /// Gets the range of valid rotations values around the y-axis in degrees.
        /// </summary>
        public (float Min, float Max) RangeY { get; }
    }
}