using System;
using UniRx;
using UnityEngine.InputSystem;

namespace BeardedPlatypus.OrbitCamera.Samples
{
    /// <summary>
    /// <see cref="InputActionExtensions"/> provides extensions for <see cref="InputAction"/>
    /// objects.
    /// </summary>
    public static class InputActionExtensions
    {
        /// <summary>
        /// Return the provided <paramref name="action"/> as an <see cref="IObservable{T}"/>.
        /// </summary>
        /// <param name="action">The action to convert.</param>
        /// <returns>The action as an <see cref="IObservable{T}"/></returns>
        public static IObservable<InputAction.CallbackContext> ActionAsObservable(this InputAction action) =>
            Observable.FromEvent<InputAction.CallbackContext>(
                addHandler => action.performed += addHandler,
                removeHandler => action.performed -= removeHandler);
    }
}
