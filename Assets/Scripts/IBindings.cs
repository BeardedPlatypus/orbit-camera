using System;
using UnityEngine;

namespace BeardedPlatypus.Camera
{
    /// <summary>
    /// <see cref="IBindings"/> defines the bindings used within the controller
    /// to control the camera location.
    /// </summary>
    public interface IBindings
    {
        /// <summary>
        /// Gets the Orbit as an observable <see cref="Vector2"/>.
        /// </summary>
        public IObservable<Vector2> Orbit { get; }
        
        /// <summary>
        /// Gets the Translation as an observable <see cref="Vector3"/>.
        /// </summary>
        public IObservable<Vector3> Translate { get; }
        
        /// <summary>
        /// Gets the Zoom as an observable <see cref="float"/>.
        /// </summary>
        public IObservable<float> Zoom { get; }
    }
}