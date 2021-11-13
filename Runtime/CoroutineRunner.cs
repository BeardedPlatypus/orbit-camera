using System.Collections;
using UnityEngine;

namespace BeardedPlatypus.OrbitCamera.Core
{
    /// <summary>
    /// <see cref="CoroutineRunner"/> implements the <see cref="ICoroutineRunner"/> interface.
    /// </summary>
    public sealed class CoroutineRunner : MonoBehaviour, ICoroutineRunner
    {
        /// <inheritdoc cref="ICoroutineRunner.Run"/>
        public Coroutine Run(IEnumerator coroutine) => StartCoroutine(coroutine);
    }
}