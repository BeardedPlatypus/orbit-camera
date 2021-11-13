using UnityEngine;

namespace BeardedPlatypus.OrbitCamera.Presets.Common
{
    /// <summary>
    /// <see cref="RotationCalculator"/> provides several convenience methods
    /// for calculating rotations.
    /// </summary>
    internal static class RotationCalculator
    {
        /// <summary>
        /// Calculates the rotation around the local x axis of point
        /// <paramref name="position"/> orbiting around <paramref name="orbitCenter"/>.
        /// </summary>
        /// <param name="position">The position of the point.</param>
        /// <param name="orbitCenter">The center around which we orbit.</param>
        /// <returns>
        /// The rotation in degrees.
        /// </returns>
        public static float CalculateRotationAroundX(Vector3 position,
                                                     Vector3 orbitCenter)
        {
            float distance = Vector3.Distance(position, orbitCenter);
            return Mathf.Asin((position.y - orbitCenter.y) / distance) * Mathf.Rad2Deg;
        }
        
        /// <summary>
        /// Calculates the rotation around the y-axis between -180 and 180 degrees.
        /// </summary>
        /// <param name="transform">The transform from which to obtain the rotation.</param>
        /// <returns>
        /// The rotation in degrees.
        /// </returns>
        public static float CalculateRotationAroundY(Transform transform)
        {
            float rot = transform.rotation.eulerAngles.y;
            // We evaluate the range between -180F and 180F, however
            // The euler values will be reported between 0 - 360, as 
            // such we need shift our scale.
            return rot <= 180F ? rot : rot - 360.0F;
        }
    }
}