using BeardedPlatypus.Camera.Core;
using BeardedPlatypus.Camera.Core.Behaviours;
using UnityEngine;

namespace BeardedPlatypus.Camera.Presets.Zoom
{
    /// <summary>
    /// <see cref="LimitableZoomBehaviour"/> implements the <see cref="IZoomBehaviour"/>
    /// where the zoom can be limited by the values contained in the
    /// <see cref="ILimitableZoomSettings"/>.
    /// </summary>
    public sealed class LimitableZoomBehaviour : IZoomBehaviour
    {
        private readonly ILimitableZoomSettings _settings;
        
        /// <summary>
        /// Creates a new <see cref="LimitableZoomBehaviour"/> with the given
        /// <see cref="ILimitableZoomSettings"/>.
        /// </summary>
        /// <param name="settings"></param>
        public LimitableZoomBehaviour(ILimitableZoomSettings settings)
        {
            _settings = settings;
        }
        
        /// <inheritdoc cref="IZoomBehaviour"/>
        public void OnZoom(float inputZoom, IOrbitCenter orbitCenter, Transform cameraTransform)
        {
            float currDistance = Vector3.Distance(cameraTransform.position, orbitCenter.Location);
            float minTranslationDistance = _settings.Limit.Min - currDistance;
            float maxTranslationDistance = _settings.Limit.Max - currDistance;
            float inputTranslation = -inputZoom * _settings.Factor;

            float translation = Mathf.Clamp(
                inputTranslation,
                minTranslationDistance,
                maxTranslationDistance
            );
            
            cameraTransform.Translate(new Vector3(0F, 0F, -translation));
        }
    }
}