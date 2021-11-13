using System.Collections;
using BeardedPlatypus.OrbitCamera.Core;
using BeardedPlatypus.OrbitCamera.Core.Behaviours;
using UnityEngine;

namespace BeardedPlatypus.OrbitCamera.Presets.SetZoom
{
    /// <summary>
    /// <see cref="SmoothSetZoomBehaviour"/> sets the provided zoom over
    /// the specified transition time.
    /// </summary>
    public sealed class SmoothSetZoomBehaviour : ISetZoomBehaviour
    {
        private readonly float _transitionTime;
        private readonly ICoroutineRunner _runner;

        /// <summary>
        /// Creates a new <see cref="SmoothSetZoomBehaviour"/> with the given
        /// dependencies.
        /// </summary>
        /// <param name="transitionTime">The transition time.</param>
        /// <param name="runner">The coroutine runner.</param>
        public SmoothSetZoomBehaviour(float transitionTime, ICoroutineRunner runner)
        {
            _transitionTime = transitionTime;
            _runner = runner;
        }

        /// <inheritdoc cref="ISetZoomBehaviour.OnSetZoom"/>
        public void OnSetZoom(float zoom, IOrbitCenter orbitCenter, Transform cameraTransform) =>
            _runner.Run(ZoomSmooth(zoom, orbitCenter, cameraTransform));

        private IEnumerator ZoomSmooth(float zoom, IOrbitCenter orbitCenter, Transform cameraTransform)
        {
            float currDistance = Vector3.Distance(cameraTransform.position, orbitCenter.Location);
            float goalDistance = zoom - currDistance;
            float timeFactor = 1.0F / _transitionTime;
            
            for (var t = 0.0F; t < 1.0F; t += Time.deltaTime * timeFactor)
            {
                var localTranslation = new Vector3(0F, 0F, Time.deltaTime * timeFactor * goalDistance);
                cameraTransform.Translate(-localTranslation);
                yield return null;
            }
        }
    }
}