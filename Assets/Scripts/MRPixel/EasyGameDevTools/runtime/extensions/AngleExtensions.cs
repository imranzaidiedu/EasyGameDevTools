using UnityEngine;

namespace MRPixel.EasyGameDevTools.Runtime.Extensions
{
    /// <summary>
    /// Extension methods for angle-related operations.
    /// </summary>
    public static class AngleExtensions
    {
        /// <summary>
        /// Wraps the angle to the 0-360 degree range.
        /// </summary>
        /// <param name="angle">Angle in degrees.</param>
        /// <returns>Wrapped angle between 0 and 360 degrees.</returns>
        public static float WrapAngle360(this float angle)
        {
            angle %= 360f;
            if (angle < 0f) angle += 360f;
            return angle;
        }

        /// <summary>
        /// Wraps the angle to the -180 to 180 degree range.
        /// </summary>
        /// <param name="angle">Angle in degrees.</param>
        /// <returns>Wrapped angle between -180 and 180 degrees.</returns>
        public static float WrapAngle180(this float angle)
        {
            angle = WrapAngle360(angle);
            if (angle > 180f) angle -= 360f;
            return angle;
        }

        /// <summary>
        /// Calculates the smallest difference between two angles in degrees.
        /// </summary>
        /// <param name="from">The starting angle in degrees.</param>
        /// <param name="to">The target angle in degrees.</param>
        /// <returns>Minimum angle difference in degrees.</returns>
        public static float DeltaAngle(this float from, float to)
        {
            return Mathf.DeltaAngle(from, to);
        }

        /// <summary>
        /// Linearly interpolates between two angles, considering the shortest path.
        /// </summary>
        /// <param name="from">Start angle in degrees.</param>
        /// <param name="to">End angle in degrees.</param>
        /// <param name="t">Interpolation factor (0 to 1).</param>
        /// <returns>Interpolated angle in degrees.</returns>
        public static float LerpAngle(this float from, float to, float t)
        {
            return Mathf.LerpAngle(from, to, t);
        }

        /// <summary>
        /// Checks if an angle is within a specified range, accounting for wrapping.
        /// </summary>
        /// <param name="angle">Angle to check in degrees.</param>
        /// <param name="min">Minimum angle in degrees.</param>
        /// <param name="max">Maximum angle in degrees.</param>
        /// <returns>True if the angle is between min and max.</returns>
        public static bool IsAngleBetween(this float angle, float min, float max)
        {
            float normalizedAngle = angle.WrapAngle360();
            float normalizedMin = min.WrapAngle360();
            float normalizedMax = max.WrapAngle360();

            if (normalizedMin < normalizedMax)
                return normalizedAngle >= normalizedMin && normalizedAngle <= normalizedMax;
            else
                return normalizedAngle >= normalizedMin || normalizedAngle <= normalizedMax;
        }

        /// <summary>
        /// Moves an angle toward a target by a specified max delta.
        /// </summary>
        /// <param name="current">Current angle in degrees.</param>
        /// <param name="target">Target angle in degrees.</param>
        /// <param name="maxDelta">Maximum angle step in degrees.</param>
        /// <returns>Updated angle moved towards target.</returns>
        public static float MoveTowardsAngle(this float current, float target, float maxDelta)
        {
            return Mathf.MoveTowardsAngle(current, target, maxDelta);
        }

        /// <summary>
        /// Returns true if two angles are approximately equal within a given tolerance.
        /// </summary>
        /// <param name="a">First angle in degrees.</param>
        /// <param name="b">Second angle in degrees.</param>
        /// <param name="tolerance">Allowed difference.</param>
        /// <returns>True if the angle difference is within tolerance.</returns>
        public static bool ApproximatelyEqualsAngle(this float a, float b, float tolerance = 0.1f)
        {
            return Mathf.Abs(Mathf.DeltaAngle(a, b)) < tolerance;
        }
    }
}
