using BeardedPlatypus.Camera.SettingsComponents;
using JetBrains.Annotations;

namespace BeardedPlatypus.Camera
{
    /// <summary>
    /// <see cref="Settings"/> define the settings for each of the different
    /// transformation options of the camera.
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// Creates a new <see cref="Settings"/> with the given camera setting
        /// components.
        /// </summary>
        /// <param name="orbitSettings">The orbit settings.</param>
        /// <param name="translationSettings">The translation settings.</param>
        /// <param name="zoomSettings">The zoom settings.</param>
        /// <remarks>
        /// The parameters can be set to <c>null</c>. When this is done it assumed
        /// that this specific component should not be active.
        /// </remarks>
        public Settings([CanBeNull] IOrbitSettings orbitSettings,
                        [CanBeNull] ITranslationSettings translationSettings,
                        [CanBeNull] IZoomSettings zoomSettings)
        {
            Orbit = orbitSettings;
            Translate = translationSettings;
            Zoom = zoomSettings;
        }
        
        /// <summary>
        /// Gets the <see cref="IOrbitSettings"/> of this <see cref="Settings"/>.
        /// </summary>
        /// <remarks>
        /// If this value is set to <c>null</c> it is assumed to be not used.
        /// </remarks>
        [CanBeNull] public IOrbitSettings Orbit { get; }
        
        /// <summary>
        /// Gets the <see cref="ITranslationSettings"/> of this <see cref="Settings"/>.
        /// </summary>
        /// <remarks>
        /// If this value is set to <c>null</c> it is assumed to be not used.
        /// </remarks>
        [CanBeNull] public ITranslationSettings Translate { get; }
        
        /// <summary>
        /// Gets the <see cref="IZoomSettings"/> of this <see cref="Settings"/>.
        /// </summary>
        /// <remarks>
        /// If this value is set to <c>null</c> it is assumed to be not used.
        /// </remarks>
        [CanBeNull] public IZoomSettings Zoom { get; }
    }
}