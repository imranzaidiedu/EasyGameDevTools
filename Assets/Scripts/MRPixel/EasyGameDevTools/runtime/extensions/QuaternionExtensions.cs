using UnityEngine;

namespace MRPixel.EasyGameDevTools.Runtime.Extensions
{
    /// <summary>
    /// Extension methods for Quaternion operations.
    /// </summary>
    public static class QuaternionExtensions
    {
        /// <summary>
        /// Returns a Quaternion with the X Euler angle replaced.
        /// </summary>
        /// <param name="q">Original quaternion.</param>
        /// <param name="x">New X angle in degrees.</param>
        /// <returns>Modified quaternion with new X rotation.</returns>
        public static Quaternion WithEulerX(this Quaternion q, float x)
        {
            var e = q.eulerAngles;
            return Quaternion.Euler(x, e.y, e.z);
        }

        /// <summary>
        /// Returns a Quaternion with the Y Euler angle replaced.
        /// </summary>
        /// <param name="q">Original quaternion.</param>
        /// <param name="y">New Y angle in degrees.</param>
        /// <returns>Modified quaternion with new Y rotation.</returns>
        public static Quaternion WithEulerY(this Quaternion q, float y)
        {
            var e = q.eulerAngles;
            return Quaternion.Euler(e.x, y, e.z);
        }

        /// <summary>
        /// Returns a Quaternion with the Z Euler angle replaced.
        /// </summary>
        /// <param name="q">Original quaternion.</param>
        /// <param name="z">New Z angle in degrees.</param>
        /// <returns>Modified quaternion with new Z rotation.</returns>
        public static Quaternion WithEulerZ(this Quaternion q, float z)
        {
            var e = q.eulerAngles;
            return Quaternion.Euler(e.x, e.y, z);
        }

        /// <summary>
        /// Returns the angle in degrees between two Quaternions.
        /// </summary>
        /// <param name="from">Starting quaternion.</param>
        /// <param name="to">Target quaternion.</param>
        /// <returns>Angle between quaternions in degrees.</returns>
        public static float AngleTo(this Quaternion from, Quaternion to)
        {
            return Quaternion.Angle(from, to);
        }

        /// <summary>
        /// Rotates the quaternion toward another quaternion by a max angle.
        /// </summary>
        /// <param name="from">Starting quaternion.</param>
        /// <param name="to">Target quaternion.</param>
        /// <param name="maxDegreesDelta">Maximum angle to rotate in degrees.</param>
        /// <returns>Quaternion rotated toward the target.</returns>
        public static Quaternion RotateTowards(this Quaternion from, Quaternion to, float maxDegreesDelta)
        {
            return Quaternion.RotateTowards(from, to, maxDegreesDelta);
        }

        /// <summary>
        /// Checks if the angle between two quaternions is within tolerance.
        /// </summary>
        /// <param name="a">First quaternion.</param>
        /// <param name="b">Second quaternion.</param>
        /// <param name="tolerance">Angle tolerance in degrees.</param>
        /// <returns>True if within tolerance, otherwise false.</returns>
        public static bool IsCloseTo(this Quaternion a, Quaternion b, float tolerance = 1f)
        {
            return Quaternion.Angle(a, b) < tolerance;
        }

        /// <summary>
        /// Inverts the quaternion.
        /// </summary>
        /// <param name="q">Quaternion to invert.</param>
        /// <returns>Inverted quaternion.</returns>
        public static Quaternion Inverted(this Quaternion q)
        {
            return Quaternion.Inverse(q);
        }

        /// <summary>
        /// Multiplies a quaternion by a vector and returns the rotated vector.
        /// </summary>
        /// <param name="rotation">The quaternion rotation.</param>
        /// <param name="point">The vector to rotate.</param>
        /// <returns>Rotated vector.</returns>
        public static Vector3 RotatePoint(this Quaternion rotation, Vector3 point)
        {
            return rotation * point;
        }

        /// <summary>
        /// Returns a quaternion that only rotates around the Y axis (yaw).
        /// </summary>
        /// <param name="angle">Angle in degrees.</param>
        /// <returns>Quaternion rotation around Y axis.</returns>
        public static Quaternion Yaw(this float angle)
        {
            return Quaternion.Euler(0f, angle, 0f);
        }

        /// <summary>
        /// Returns a quaternion that only rotates around the X axis (pitch).
        /// </summary>
        /// <param name="angle">Angle in degrees.</param>
        /// <returns>Quaternion rotation around X axis.</returns>
        public static Quaternion Pitch(this float angle)
        {
            return Quaternion.Euler(angle, 0f, 0f);
        }

        /// <summary>
        /// Returns a quaternion that only rotates around the Z axis (roll).
        /// </summary>
        /// <param name="angle">Angle in degrees.</param>
        /// <returns>Quaternion rotation around Z axis.</returns>
        public static Quaternion Roll(this float angle)
        {
            return Quaternion.Euler(0f, 0f, angle);
        }
        
        /// <summary>
        /// Returns true if the quaternion has no rotation.
        /// </summary>
        /// <param name="q">Quaternion to check.</param>
        /// <returns>True if identity quaternion.</returns>
        public static bool IsIdentity(this Quaternion q)
        {
            return q == Quaternion.identity;
        }
    }
}
