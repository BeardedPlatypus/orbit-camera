namespace BeardedPlatypus.Camera.Presets.Zoom
{
    /// <summary>
    /// <see cref="ILimitableZoomSettings"/> defines the settings related to the zoom behaviour
    /// of the Camera.
    /// </summary>
    public interface ILimitableZoomSettings
    {
        /// <summary>
        /// Gets the zoom factor.
        /// </summary>
        public float Factor { get; }
        
        /// <summary>
        /// Gets the range of valid values in world space distance.
        /// </summary>
        /// <remarks>
        /// It is expected that Min is a smaller value than Max and that both values
        /// are greater than or equal to zero.
        /// </remarks>
        public (float Min, float Max) Limit { get; }
    }
}