using System.Collections;
using UnityEngine;

namespace BeardedPlatypus.Camera.Core
{
    /// <summary>
    /// <see cref="ICoroutineRunner"/> is a convenience interface to run
    /// co-routines from non-monobehaviour classes.
    /// </summary>
    public interface ICoroutineRunner
    {
        /// <summary>
        /// Start the provided <paramref name="coroutine"/>.
        /// </summary>
        /// <param name="coroutine">The coroutine to run.</param>
        Coroutine Run(IEnumerator coroutine);
    }
}