using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace BeardedPlatypus.Camera.Samples
{
    // TODO: Figure out a better way to set up the UniRx subscriptions after the constructor.
    // TODO: Would we want to use the message bus for this to delay it?
    /// <summary>
    /// <see cref="ResetViewController"/> defines the reset behaviour of the reset view button.
    /// </summary>
    public sealed class ResetViewController
    {
        private readonly ResetDataScriptableObject _resetData;
        
        public ResetViewController(Button button, ResetDataScriptableObject resetData)
        {
            _resetData = resetData;
            ConfigureObservables(button);
        }
        
        /// <summary> Gets the reset orbit observable.</summary>
        /// <remarks>The reset rotation in degrees is raised.</remarks>
        public IObservable<Vector2> ResetOrbitObservable { get; private set; }
        
        /// <summary> Gets the reset position observable.</summary>
        /// <remarks>The reset position in world space is raised.</remarks>
        public IObservable<Vector3> ResetPositionObservable { get; private set; }
        
        /// <summary> Gets the reset zoom observable.</summary>
        /// <remarks>The reset zoom distance is raised.</remarks>
        public IObservable<float> ResetZoomObservable { get; private set; }

        private void ConfigureObservables(Button button)
        {
            var throttleTimeSpan = new TimeSpan(0, 0, 0, 0, _resetData.ThrottleTime);
            var clickStream = button.OnClickAsObservable().ThrottleFirst(throttleTimeSpan);

            ResetOrbitObservable = clickStream.Select(_ => _resetData.ResetOrbit);
            ResetPositionObservable = clickStream.Select(_ => _resetData.ResetPosition);
            ResetZoomObservable = clickStream.Select(_ => _resetData.ResetZoom);
        }
    }
}
