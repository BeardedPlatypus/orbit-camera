using System.Collections;
using BeardedPlatypus.OrbitCamera.Core;
using BeardedPlatypus.OrbitCamera.Core.Behaviours;
using UnityEngine;

namespace BeardedPlatypus.OrbitCamera.Presets.SetPosition
{
    /// <summary>
    /// <see cref="SmoothSetPositionBehaviour"/> sets the provided position over
    /// the specified transition time.
    /// </summary>
    public sealed class SmoothSetPositionBehaviour : ISetPositionBehaviour
    {
        private readonly float _transitionTime;
        private readonly ICoroutineRunner _runner;

        /// <summary>
        /// Creates a new <see cref="SmoothSetPositionBehaviour"/> with the given
        /// dependencies.
        /// </summary>
        /// <param name="transitionTime">The transition time.</param>
        /// <param name="runner">The coroutine runner.</param>
        public SmoothSetPositionBehaviour(float transitionTime, ICoroutineRunner runner)
        {
            _transitionTime = transitionTime;
            _runner = runner;
        }

        /// <inheritdoc cref="ISetPositionBehaviour.OnSetPosition"/>
        public void OnSetPosition(Vector3 position, IOrbitCenter orbitCenter, Transform cameraTransform) =>
            _runner.Run(TranslateSmooth(position, orbitCenter, cameraTransform));

        private IEnumerator TranslateSmooth(Vector3 goalOrbitPosition,
                                            IOrbitCenter orbitCenter,
                                            Transform cameraTransform)
        {
            var orbitTranslation = goalOrbitPosition - orbitCenter.Location;
            float timeFactor = 1.0F / _transitionTime;
            
            for (var t = 0.0F; t < 1.0F; t += Time.deltaTime * timeFactor)
            {
                var localTranslation = Time.deltaTime * timeFactor * orbitTranslation;
                cameraTransform.Translate(localTranslation, Space.World);
                orbitCenter.TranslateBy(localTranslation);
                yield return null;
            }
        }
    }
}