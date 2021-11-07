namespace BeardedPlatypus.Camera.Core.SettingsComponents
{
    /// <summary>
    /// <see cref="ITranslationSettings"/> defines the settings related to the
    /// translation behaviour of the Camera.
    /// </summary>
    public interface ITranslationSettings
    {
        /// <summary>
        /// Gets the translation factor.
        /// </summary>
        public float Factor { get; }
        
        /// <summary>
        /// Gets the range on the X-axis between which the Camera can translate in
        /// world coordinates.
        /// </summary>
        public (float Min, float Max) RangeX { get; }
        
        /// <summary>
        /// Gets the range on the X-axis between which the Camera can translate in
        /// world coordinates.
        /// </summary>
        public (float Min, float Max) RangeY { get; }
        
        /// <summary>
        /// Gets the range on the X-axis between which the Camera can translate in
        /// world coordinates.
        /// </summary>
        public (float Min, float Max) RangeZ { get; }
    }
}