using UnityEngine;

namespace BeardedPlatypus.OrbitCamera.Core
{
    /// <summary>
    /// <see cref="OrbitCenter"/> implements <see cref="IOrbitCenter"/> as a
    /// <see cref="MonoBehaviour"/>.
    /// </summary>
    public sealed class OrbitCenter : MonoBehaviour, IOrbitCenter
    {
        /// <inheritdoc cref="IOrbitCenter"/>
        public Vector3 Location => transform.position;

        /// <inheritdoc cref="IOrbitCenter"/>
        public void TranslateBy(Vector3 translation) =>
            transform.Translate(translation, Space.World);

        /// <inheritdoc cref="IOrbitCenter"/>
        public void MoveTo(Vector3 newOrbitCenter) =>
            transform.position = newOrbitCenter;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(transform.position, 
                                new Vector3(0.05F, 0.05F, 0.05F));
        }
    }
}