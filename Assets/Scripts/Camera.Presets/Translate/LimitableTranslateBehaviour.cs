using BeardedPlatypus.Camera.Core;
using UnityEngine;

namespace BeardedPlatypus.Camera.Presets.Translate
{
    /// <summary>
    /// <see cref="LimitableTranslateBehaviour"/> implements the <see cref="ITranslateBehaviour"/>
    /// where the translation in world space can be limited by the values contained in
    /// the <see cref="ILimitableTranslateSettings"/>.
    /// </summary>
    public sealed class LimitableTranslateBehaviour : ITranslateBehaviour
    {
        private readonly ILimitableTranslateSettings _settings;

        /// <summary>
        /// Creates a new <see cref="LimitableTranslateBehaviour"/> with the given
        /// <see cref="ILimitableTranslateSettings"/>.
        /// </summary>
        /// <param name="settings"></param>
        public LimitableTranslateBehaviour(ILimitableTranslateSettings settings)
        {
            _settings = settings;
        }

        /// <inheritdoc cref="ITranslateBehaviour"/>
        public void OnTranslate(Vector3 inputTranslation, 
                                IOrbitCenter orbitCenter, 
                                Transform cameraTransform)
        {
            Vector3 xComponent = cameraTransform.TransformVector(
                new Vector3(-inputTranslation.x * _settings.Factor, 0F, 0F));
            Vector3 yComponent = new Vector3(0F, inputTranslation.y * _settings.Factor);
            Vector3 zComponent = CalculateZComponent(cameraTransform) * 
                                 (_settings.Factor * -inputTranslation.z);

            Vector3 worldComponents = xComponent + yComponent + zComponent;

            float xMin = _settings.Limit.X.Min - orbitCenter.Location.x;
            float xMax = _settings.Limit.X.Max - orbitCenter.Location.x;
            float yMin = _settings.Limit.Y.Min - orbitCenter.Location.y;
            float yMax = _settings.Limit.Y.Max - orbitCenter.Location.y;
            float zMin = _settings.Limit.Z.Min - orbitCenter.Location.z;
            float zMax = _settings.Limit.Z.Max - orbitCenter.Location.z;

            Vector3 translation = new Vector3(Mathf.Clamp(worldComponents.x, xMin, xMax),
                                              Mathf.Clamp(worldComponents.y, yMin, yMax),
                                              Mathf.Clamp(worldComponents.z, zMin, zMax));

            orbitCenter.TranslateBy(translation);
            cameraTransform.Translate(translation, Space.World);
        }

        private static Vector3 CalculateZComponent(Transform transform)
        {
            Vector3 zVector = transform.TransformVector(new Vector3(0F, 1F, 1F));
            zVector.y = 0F;
            zVector.Normalize();

            return zVector;
        }
    }
}