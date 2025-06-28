using System.Collections.Generic;
using UnityEngine;
using System;

namespace MRPixel.EasyGameDevTools.Runtime.Extensions
{
    /// <summary>
    /// Extension methods for Vector2 operations.
    /// </summary>
    public static class Vector2Extensions
    {
        /// <summary>
        /// Rotates the vector by the specified angle in degrees.
        /// </summary>
        /// <param name="v">Original vector.</param>
        /// <param name="degrees">Angle to rotate in degrees.</param>
        /// <returns>Rotated vector.</returns>
        public static Vector2 Rotate(this Vector2 v, float degrees)
        {
            float radians = degrees * Mathf.Deg2Rad;
            float sin = Mathf.Sin(radians);
            float cos = Mathf.Cos(radians);
            float tx = v.x;
            float ty = v.y;
            return new Vector2(cos * tx - sin * ty, sin * tx + cos * ty);
        }

        /// <summary>
        /// Returns a perpendicular vector (90 degrees counter-clockwise).
        /// </summary>
        /// <param name="v">Input vector.</param>
        /// <returns>Perpendicular vector.</returns>
        public static Vector2 Perpendicular(this Vector2 v)
        {
            return new Vector2(-v.y, v.x);
        }

        /// <summary>
        /// Returns the angle in degrees between two vectors.
        /// </summary>
        /// <param name="from">From vector.</param>
        /// <param name="to">To vector.</param>
        /// <returns>Angle between vectors in degrees.</returns>
        public static float AngleTo(this Vector2 from, Vector2 to)
        {
            return Vector2.Angle(from, to);
        }

        /// <summary>
        /// Returns the signed angle in degrees between two vectors.
        /// </summary>
        /// <param name="from">From vector.</param>
        /// <param name="to">To vector.</param>
        /// <returns>Signed angle in degrees.</returns>
        public static float SignedAngleTo(this Vector2 from, Vector2 to)
        {
            return Vector2.SignedAngle(from, to);
        }

        /// <summary>
        /// Projects a vector onto another vector.
        /// </summary>
        /// <param name="vector">The vector to project.</param>
        /// <param name="onto">The vector to project onto.</param>
        /// <returns>Projected vector.</returns>
        public static Vector2 ProjectOnto(this Vector2 vector, Vector2 onto)
        {
            return Vector2.Dot(vector, onto.normalized) * onto.normalized;
        }

        /// <summary>
        /// Reflects the vector off the given normal.
        /// </summary>
        /// <param name="vector">Incident vector.</param>
        /// <param name="normal">Surface normal.</param>
        /// <returns>Reflected vector.</returns>
        public static Vector2 Reflect(this Vector2 vector, Vector2 normal)
        {
            return Vector2.Reflect(vector, normal);
        }

        /// <summary>
        /// Returns true if the vector is approximately equal to another vector.
        /// </summary>
        /// <param name="a">First vector.</param>
        /// <param name="b">Second vector.</param>
        /// <param name="tolerance">Tolerance threshold.</param>
        /// <returns>True if vectors are approximately equal.</returns>
        public static bool Approximately(this Vector2 a, Vector2 b, float tolerance = 0.001f)
        {
            return Vector2.Distance(a, b) < tolerance;
        }
        
        /// <summary>
        /// Returns true if the distance between two vectors is less than Mathf.Epsilon, indicating they are extremely close.
        /// </summary>
        /// <param name="a">First vector.</param>
        /// <param name="b">Second vector.</param>
        /// <returns>True if the vectors are within Mathf.Epsilon of each other.</returns>
        public static bool ApproximatelyEpsilon(this Vector2 a, Vector2 b)
        {
            return Vector2.Distance(a, b) < Mathf.Epsilon;
        }

        /// <summary>
        /// Snaps the vector to the nearest multiple of a step value.
        /// </summary>
        /// <param name="v">Input vector.</param>
        /// <param name="step">Snap step value.</param>
        /// <returns>Snapped vector.</returns>
        public static Vector2 Snap(this Vector2 v, float step)
        {
            return new Vector2(
                Mathf.Round(v.x / step) * step,
                Mathf.Round(v.y / step) * step
            );
        }

        /// <summary>
        /// Returns a normalized direction from one point to another.
        /// </summary>
        /// <param name="from">Start point.</param>
        /// <param name="to">End point.</param>
        /// <returns>Normalized direction vector.</returns>
        public static Vector2 DirectionTo(this Vector2 from, Vector2 to)
        {
            return (to - from).normalized;
        }
        
        /// <summary>
        /// Adds a scalar value to both components of the vector.
        /// </summary>
        /// <param name="v">The original vector.</param>
        /// <param name="f">The value to add to both x and y components.</param>
        /// <returns>A new Vector2 with both components increased by the given value.</returns>
        /// <summary>
        public static Vector2 Add(this Vector2 v, float f)
        {
            v.x += f;
            v.y += f;
            return v;
        }
        
        /// <summary>
        /// Rounds the x and y components of the Vector2 to the nearest integers and returns a Vector2Int.
        /// </summary>
        /// <param name="vector">The Vector2 to round.</param>
        /// <returns>A Vector2Int with each component rounded to the nearest integer.</returns>
        public static Vector2Int RoundToInt(this Vector2 vector) => new Vector2Int(Mathf.RoundToInt(vector.x), Mathf.RoundToInt(vector.y));

        /// <summary>
        /// Returns a vector composed of the Cos and the Sin of an angle in the form (Cos, Sin)
        /// </summary>
        /// <param name="angleDeg">an angle in degrees</param>
        public static Vector2 DegToVector(this float angleDeg) => RadToVector(angleDeg * Mathf.Deg2Rad);

        /// <summary>
        /// Returns a vector composed of the Cos and the Sin of an angle in the form (Cos, Sin)
        /// </summary>
        /// <param name="angleDeg">an angle in degrees</param>
        public static Vector2 DegToVector(this float angleDeg, float magnitude) => RadToVector(angleDeg * Mathf.Deg2Rad, magnitude);

        /// <summary>
        /// Returns a vector composed of the Cos and the Sin of an angle in the form (Cos, Sin)
        /// </summary>
        /// <param name="angleRad">an angle in radians</param>
        public static Vector2 RadToVector(this float angleRad) => new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));

        /// <summary>
        /// Returns a vector composed of the Cos and the Sin of an angle in the form (Cos, Sin)
        /// </summary>
        /// <param name="angleRad">an angle in radians</param>
        public static Vector2 RadToVector(this float angleRad, float magnitude) => new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad)) * magnitude;

        /// <summary>
        /// Returns the angle in radians whose Tan is y/x.
        /// </summary>
        /// <returns>The angle between the x-axis and a 2D vector starting at zero and terminating at(x, y)</returns>
        public static float VectorToRad(this Vector2 vector) => Mathf.Atan2(vector.y, vector.x);

        /// <summary>
        /// Returns the angle in radians whose Tan is y/x.
        /// </summary>
        /// <returns>The angle between the x-axis and a 2D vector starting at zero and terminating at(x, y)</returns>
        public static float GetAngleRad(this Vector2 vector) => Mathf.Atan2(vector.y, vector.x);

        /// <summary>
        /// Returns the angle in degrees whose Tan is y/x.
        /// </summary>
        /// <returns>The angle between the x-axis and a 2D vector starting at zero and terminating at(x, y)</returns>
        public static float VectorToDeg(this Vector2 vector) => VectorToRad(vector) * Mathf.Rad2Deg;

        /// <summary>
        /// Returns the angle in degrees whose Tan is y/x.
        /// </summary>
        /// <returns>The angle between the x-axis and a 2D vector starting at zero and terminating at(x, y)</returns>
        public static float GetAngleDeg(this Vector2 vector) => VectorToRad(vector) * Mathf.Rad2Deg;

        /// <summary>
        /// Rotates a vector by a certain angle
        /// </summary>
        /// <param name="vector">The vector to be rotated</param>
        /// <param name="rad">The angle in radians</param>
        /// <returns>The resulting rotated vector</returns>
        public static Vector2 RotateRadians(this Vector2 vector, float rad) => vector == default ? vector : (vector.VectorToRad() + rad).RadToVector(vector.magnitude);

        /// <summary>
        /// Rotates a vector by a certain angle
        /// </summary>
        /// <param name="vector">The vector to be rotated</param>
        /// <param name="deg">The angle in degrees</param>
        /// <returns>The resulting rotated vector</returns>
        public static Vector2 RotateDegrees(this Vector2 vector, float deg) => RotateRadians(vector, deg * Mathf.Deg2Rad);

        /// <summary>
        /// Returns a new Vector2 with optionally updated x and/or y components.
        /// </summary>
        /// <param name="v">The original vector.</param>
        /// <param name="x">Optional new x value. If null, x is unchanged.</param>
        /// <param name="y">Optional new y value. If null, y is unchanged.</param>
        /// <returns>A new Vector2 with updated components as specified.</returns>
        public static Vector2 Set(this Vector2 v, float? x = null, float? y = null)
        {
            if (x.HasValue)
                v.x = x.Value;
            if (y.HasValue)
                v.y = y.Value;
            return v;
        }

        /// <summary>
        /// Multiplies each passed parameter with their corresponding place in the vector.
        /// Example: if v = (2, 1) and x = 3, return will be (6, 1)
        /// </summary>
        /// <param name="v">The original vector to be multiplied</param>
        /// <param name="x">The factor by which to multiply the x component to the vector</param>
        /// <param name="y">The factor by which to multiply the y component to the vector</param>
        /// <returns></returns>
        public static Vector2 MultiplyIndividually(this Vector2 v, float? x = null, float? y = null)
        {
            if (x.HasValue)
                v.x *= x.Value;
            if (y.HasValue)
                v.y *= y.Value;
            return v;
        }

        /// <summary>
        /// Multiplies each passed parameter with their corresponding place in the vector.
        /// Example: if v = (2, 1) and x = 3, return will be (6, 1)
        /// </summary>
        /// <param name="v">The original vector to be multiplied</param>
        /// <param name="x">The factor by which to multiply the x component to the vector</param>
        /// <param name="y">The factor by which to multiply the y component to the vector</param>
        /// <returns></returns>
        public static Vector2 MultiplyIndividually(this Vector2 v, Vector2 other)
        {
            v.x *= other.x;
            v.y *= other.y;
            return v;
        }
        
        /// <summary>
        /// Multiplies each passed parameter with their corresponding place in the vector.
        /// Example: if v = (2, 1) and x = 3, return will be (6, 1)
        /// </summary>
        /// <param name="v">The original vector to be multiplied</param>
        /// <param name="x">The factor by which to multiply the x component to the vector</param>
        /// <param name="y">The factor by which to multiply the y component to the vector</param>
        /// <returns></returns>
        public static Vector2 DivideIndividually(this Vector2 v, float? x = null, float? y = null)
        {
            if (x.HasValue)
                v.x /= x.Value;
            if (y.HasValue)
                v.y /= y.Value;
            return v;
        }
        
        /// <summary>
        /// Divide each passed parameter with their corresponding place in the vector.
        /// Example: if v = (2, 2) and x = 2, return will be (1, 1)
        /// </summary>
        /// <param name="v">The original vector to be multiplied</param>
        /// <param name="x">The factor by which to multiply the x component to the vector</param>
        /// <param name="y">The factor by which to multiply the y component to the vector</param>
        /// <returns></returns>
        public static Vector2 DivideIndividually(this Vector2 v, Vector2 other)
        {
            v.x /= other.x;
            v.y /= other.y;
            return v;
        }
        
        
        /// <summary>
        /// Returns a new Vector2 that is rotated 90 degrees clockwise from the input vector.
        /// </summary>
        /// <param name="v">The original vector.</param>
        /// <returns>The vector rotated 90 degrees clockwise.</returns>
        public static Vector2 RotateClockwise(this Vector2 v) => new Vector2(v.y, -v.x);
        
        /// <summary>
        /// Returns a new Vector2 that is rotated 90 degrees counter-clockwise from the input vector.
        /// </summary>
        /// <param name="v">The original vector.</param>
        /// <returns>The vector rotated 90 degrees counter-clockwise.</returns>
        public static Vector2 RotateCounterClockwise(this Vector2 v) => new Vector2(-v.y, v.x);

        /// <summary>
        /// Rotates the vector by a certain amount of degrees around the Y-axis.
        /// </summary>
        /// <param name="v">The original vector to be rotated (not affected by this)</param>
        /// <param name="degrees">The angle in degrees to rotate the vector</param>
        /// <returns>The resulting rotated vector</returns>
        public static Vector2 RotateY(this Vector2 v, float degrees) => Quaternion.Euler(0, 0, degrees) * v;

        /// <summary>
        /// Clamps the x and y components of the Vector2 to the specified Rect bounds.
        /// </summary>
        /// <param name="v">The original vector to clamp.</param>
        /// <param name="rect">The Rect providing the min and max bounds for x and y.</param>
        /// <returns>A Vector2 with x and y clamped to the Rect bounds.</returns>
        public static Vector2 Clamp(this Vector2 v, Rect rect)
        {
            v.x = v.x.Clamp(rect.xMin, rect.xMax);
            v.y = v.y.Clamp(rect.yMin, rect.yMax);
            return v;
        }

        /// <summary>
        /// Clamps the x and y components of the Vector2 to the specified Bounds.
        /// </summary>
        /// <param name="v">The original vector to clamp.</param>
        /// <param name="bounds">The Bounds providing the min and max bounds for x and y.</param>
        /// <returns>A Vector2 with x and y clamped to the Bounds limits.</returns>
        public static Vector2 Clamp(this Vector2 v, Bounds bounds)
        {
            v.x = v.x.Clamp(bounds.min.x, bounds.max.x);
            v.y = v.y.Clamp(bounds.min.y, bounds.max.y);
            return v;
        }

        /// <summary>
        /// Checks if the vector is within the specified Bounds.
        /// </summary>
        /// <param name="v">The vector to check.</param>
        /// <param name="bounds">The Bounds to check against.</param>
        /// <returns>True if the vector is within the bounds, otherwise false.</returns>
        public static bool Within(this Vector2 v, Bounds bounds) => v.x.Within(bounds.min.x, bounds.max.x) && v.y.Within(bounds.min.y, bounds.max.y);

        /// <summary>
        /// Checks if the vector is within the specified BoundsInt.
        /// </summary>
        /// <param name="v">The vector to check.</param>
        /// <param name="bounds">The BoundsInt to check against.</param>
        /// <returns>True if the vector is within the bounds, otherwise false.</returns>
        public static bool Within(this Vector2 v, BoundsInt bounds) => v.x.Within(bounds.min.x, bounds.max.x) && v.y.Within(bounds.min.y, bounds.max.y);
    }
}
