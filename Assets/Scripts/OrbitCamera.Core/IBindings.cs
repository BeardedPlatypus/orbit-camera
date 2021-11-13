using System;
using UnityEngine;

namespace BeardedPlatypus.OrbitCamera.Core
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
        
        /// <summary>
        /// Set the orbit rotation to the observed x and y values.
        /// </summary>
        /// <remarks>
        /// The x-component corresponds with the rotation around the x-axis in degrees.
        /// The y-component corresponds with the rotation around the y-axis in degrees.
        /// </remarks>
        public IObservable<Vector2> SetOrbit { get; }
        
        /// <summary>
        /// Set the observed position to the observed three dimensional point.
        /// </summary>
        /// <remarks>
        /// This will set the position of the orbit center. While preserving the
        /// current orbit.
        /// </remarks>
        public IObservable<Vector3> SetPosition { get; }
        
        /// <summary>
        /// Set the zoom distance to the observed value.
        /// </summary>
        public IObservable<float> SetZoom { get; }
    }
}