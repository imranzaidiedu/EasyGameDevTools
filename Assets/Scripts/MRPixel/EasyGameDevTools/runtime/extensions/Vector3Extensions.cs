using System.Collections.Generic;
using UnityEngine;

namespace MRPixel.EasyGameDevTools.Runtime.Extensions
{
    /// <summary>
    /// Extension methods for Vector3 operations.
    /// </summary>
    public static class Vector3Extensions
    {
        /// <summary>
        /// Returns a vector with a new X value.
        /// </summary>
        /// <param name="v">Original vector.</param>
        /// <param name="x">New X value.</param>
        /// <returns>Modified vector with updated X value.</returns>
        public static Vector3 SetX(this Vector3 v, float x) => new Vector3(x, v.y, v.z);

        /// <summary>
        /// Returns a vector with a new Y value.
        /// </summary>
        /// <param name="v">Original vector.</param>
        /// <param name="y">New Y value.</param>
        /// <returns>Modified vector with updated Y value.</returns>
        public static Vector3 SetY(this Vector3 v, float y) => new Vector3(v.x, y, v.z);

        /// <summary>
        /// Returns a vector with a new Z value.
        /// </summary>
        /// <param name="v">Original vector.</param>
        /// <param name="z">New Z value.</param>
        /// <returns>Modified vector with updated Z value.</returns>
        public static Vector3 SetZ(this Vector3 v, float z) => new Vector3(v.x, v.y, z);

        /// <summary>
        /// Returns a vector with updated X and Y values.
        /// </summary>
        /// <param name="v">Original vector.</param>
        /// <param name="x">New X value.</param>
        /// <param name="y">New Y value.</param>
        /// <returns>Modified vector with new X and Y.</returns>
        public static Vector3 SetXY(this Vector3 v, float x, float y) => new Vector3(x, y, v.z);

        /// <summary>
        /// Returns a vector with updated X and Z values.
        /// </summary>
        /// <param name="v">Original vector.</param>
        /// <param name="x">New X value.</param>
        /// <param name="z">New Z value.</param>
        /// <returns>Modified vector with new X and Z.</returns>
        public static Vector3 SetXZ(this Vector3 v, float x, float z) => new Vector3(x, v.y, z);

        /// <summary>
        /// Returns a vector with updated Y and Z values.
        /// </summary>
        /// <param name="v">Original vector.</param>
        /// <param name="y">New Y value.</param>
        /// <param name="z">New Z value.</param>
        /// <returns>Modified vector with new Y and Z.</returns>
        public static Vector3 SetYZ(this Vector3 v, float y, float z) => new Vector3(v.x, y, z);

        /// <summary>
        /// Returns the direction vector from this position to a target.
        /// </summary>
        /// <param name="from">Starting position.</param>
        /// <param name="to">Target position.</param>
        /// <returns>Normalized direction vector.</returns>
        public static Vector3 DirectionTo(this Vector3 from, Vector3 to) => (to - from).normalized;

        /// <summary>
        /// Projects this vector onto another vector.
        /// </summary>
        /// <param name="vector">Vector to project.</param>
        /// <param name="onto">Vector to project onto.</param>
        /// <returns>Projected vector.</returns>
        public static Vector3 ProjectOnto(this Vector3 vector, Vector3 onto) => Vector3.Project(vector, onto);

        /// <summary>
        /// Reflects a vector off a given normal.
        /// </summary>
        /// <param name="vector">Incident vector.</param>
        /// <param name="normal">Surface normal.</param>
        /// <returns>Reflected vector.</returns>
        public static Vector3 Reflect(this Vector3 vector, Vector3 normal) => Vector3.Reflect(vector, normal);

        /// <summary>
        /// Returns a new vector snapped to the nearest multiple of a step.
        /// </summary>
        /// <param name="v">Vector to snap.</param>
        /// <param name="step">Step size.</param>
        /// <returns>Snapped vector.</returns>
        public static Vector3 Snap(this Vector3 v, float step) => new Vector3(
            Mathf.Round(v.x / step) * step,
            Mathf.Round(v.y / step) * step,
            Mathf.Round(v.z / step) * step
        );

        /// <summary>
        /// Returns true if the vector is approximately equal to another.
        /// </summary>
        /// <param name="a">First vector.</param>
        /// <param name="b">Second vector.</param>
        /// <param name="tolerance">Tolerance for equality.</param>
        /// <returns>True if vectors are approximately equal.</returns>
        public static bool Approximately(this Vector3 a, Vector3 b, float tolerance = 0.001f) =>
            Vector3.Distance(a, b) < tolerance;
        
        /// <summary>
        /// Determines whether two Vector3 values are approximately equal using Mathf.Epsilon as the tolerance.
        /// </summary>
        /// <param name="a">The first Vector3 to compare.</param>
        /// <param name="b">The second Vector3 to compare.</param>
        /// <returns>True if the distance between the vectors is less than Mathf.Epsilon; otherwise, false.</returns>
        public static bool ApproximatelyEpsilon(this Vector3 a, Vector3 b) =>
            Vector3.Distance(a, b) < Mathf.Epsilon;

        /// <summary>
        /// Converts a Vector3 to Vector2 by dropping the Z component.
        /// </summary>
        /// <param name="v">Input Vector3.</param>
        /// <returns>Converted Vector2.</returns>
        public static Vector2 ToVector2(this Vector3 v) => new Vector2(v.x, v.y);

        /// <summary>
        /// Calculates the Manhattan distance between two Vector3 points.
        /// </summary>
        /// <param name="a">First point.</param>
        /// <param name="b">Second point.</param>
        /// <returns>Sum of absolute differences of components.</returns>
        public static float ManhattanDistance(this Vector3 a, Vector3 b) =>
            Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y) + Mathf.Abs(a.z - b.z);
        
        /// <summary>
        /// Finds the position closest to the given one.
        /// </summary>
        /// <param name="position">Position.</param>
        /// <param name="otherPositions">Other positions.</param>
        /// <returns>Closest position.</returns>
        public static Vector3 GetClosest(this Vector3 position, IEnumerable<Vector3> otherPositions)
        {
            var closest = Vector3.zero;
            var shortestDistance = Mathf.Infinity;

            foreach (var otherPosition in otherPositions)
            {
                var distance = (position - otherPosition).sqrMagnitude;

                if (distance < shortestDistance)
                {
                    closest = otherPosition;
                    shortestDistance = distance;
                }
            }

            return closest;
        }
        
        /// <summary>
        /// Sets each component to its value rounded down to the nearest integer.
        /// </summary>
        /// <param name="vector">Vector.</param>
        /// <returns>Vector with floored values.</returns>
        public static Vector3 Floor(this Vector3 vector)
        {
            return new Vector3(Mathf.Floor(vector.x), Mathf.Floor(vector.y), Mathf.Floor(vector.z));
        }
        
        /// <summary>
        /// Sets each component to its value rounded up to the nearest integer.
        /// </summary>
        /// <param name="vector">Vector.</param>
        /// <returns>Vector with ceiling values.</returns>
        public static Vector3 Ceil(this Vector3 vector)
        {
            return new Vector3(Mathf.Ceil(vector.x), Mathf.Ceil(vector.y), Mathf.Ceil(vector.z));
        }
        
        /// <summary>
        /// Sets each component to its absolute value.
        /// </summary>
        /// <param name="vector">Vector.</param>
        /// <returns>Vector with absolute values.</returns>
        public static Vector3 Abs(this Vector3 vector)
        {
            return new Vector3(Mathf.Abs(vector.x), Mathf.Abs(vector.y), Mathf.Abs(vector.z));
        }
        
        /// <summary>
        /// Returns a new Vector3 with optionally updated X, Y, and/or Z components.
        /// </summary>
        /// <param name="v">Original vector.</param>
        /// <param name="x">Optional new X value. If null, keeps the original X.</param>
        /// <param name="y">Optional new Y value. If null, keeps the original Y.</param>
        /// <param name="z">Optional new Z value. If null, keeps the original Z.</param>
        /// <returns>Modified vector with updated components as specified.</returns>
        public static Vector3 Set(this Vector3 v, float? x = null, float? y = null, float? z = null)
        {
            if (x.HasValue)
                v.x = x.Value;
            if (y.HasValue)
                v.y = y.Value;
            if (z.HasValue)
                v.z = z.Value;
            return v;
        }
        
        /// <summary>
        /// Multiplies each passed parameter with their corresponding place in the vector.
        /// Example: if v = (2, 1, 1) and x = 3, return will be (6, 1, 1)
        /// </summary>
        /// <param name="v">The original vector to be multiplied</param>
        /// <param name="x">The factor by which to multiply the x component to the vector</param>
        /// <param name="y">The factor by which to multiply the y component to the vector</param>
        /// <param name="z">The factor by which to multiply the z component to the vector</param>
        /// <returns></returns>
        public static Vector3 MultiplyIndividually(this Vector3 v, float? x = null, float? y = null, float? z = null)
        {
            if (x.HasValue)
                v.x *= x.Value;
            if (y.HasValue)
                v.y *= y.Value;
            if (z.HasValue)
                v.z *= z.Value;
            return v;
        }
        
        /// <summary>
        /// Multiplies each passed parameter with their corresponding place in the vector.
        /// Example: if v = (2, 1, 1) and x = 3, return will be (6, 1, 1)
        /// </summary>
        /// <param name="v">The original vector to be multiplied</param>
        /// <param name="x">The factor by which to multiply the x component to the vector</param>
        /// <param name="y">The factor by which to multiply the y component to the vector</param>
        /// <param name="z">The factor by which to multiply the z component to the vector</param>
        /// <returns></returns>
        public static Vector3 MultiplyIndividually(this Vector3 v, Vector3 other)
        {
            v.x *= other.x;
            v.y *= other.y;
            v.z *= other.z;
            return v;
        }
        
        /// <summary>
        /// Multiplies each passed parameter with their corresponding place in the vector.
        /// Example: if v = (2, 1, 1) and x = 3, return will be (6, 1, 1)
        /// </summary>
        /// <param name="v">The original vector to be multiplied</param>
        /// <param name="x">The factor by which to multiply the x component to the vector</param>
        /// <param name="y">The factor by which to multiply the y component to the vector</param>
        /// <param name="z">The factor by which to multiply the z component to the vector</param>
        /// <returns></returns>
        public static Vector3 DivideIndividually(this Vector3 v, float? x = null, float? y = null, float? z = null)
        {
            if (x.HasValue)
                v.x /= x.Value;
            if (y.HasValue)
                v.y /= y.Value;
            if (z.HasValue)
                v.z /= z.Value;
            return v;
        }
        
        /// <summary>
        /// Divide each passed parameter with their corresponding place in the vector.
        /// Example: if v = (2, 2, 2) and x = 2, return will be (1, 1, 1)
        /// </summary>
        /// <param name="v">The original vector to be multiplied</param>
        /// <param name="x">The factor by which to multiply the x component to the vector</param>
        /// <param name="y">The factor by which to multiply the y component to the vector</param>
        /// <param name="z">The factor by which to multiply the z component to the vector</param>
        /// <returns></returns>
        public static Vector3 DivideIndividually(this Vector3 v, Vector3 other)
        {
            v.x /= other.x;
            v.y /= other.y;
            v.z /= other.z;
            return v;
        }

        /// <summary>
        /// Sets the Y component of a Vector3 to zero.
        /// </summary>
        /// <param name="v">Input vector.</param>
        /// <returns>Vector with Y set to 0.</returns>
        public static Vector3 Flat(this Vector3 v) => new Vector3(v.x, 0f, v.z);
        
        /// <summary>
        /// Creates a Vector2 using the X component of the Vector3 for both X and Y.
        /// </summary>
        /// <param name="vector">The source Vector3.</param>
        /// <returns>A Vector2 (X, X).</returns>
        public static Vector2 ToVector2XX(this Vector3 vector) => new(vector.x, vector.x);

        /// <summary>
        /// Creates a Vector2 using the X and Y components of the Vector3.
        /// </summary>
        /// <param name="vector">The source Vector3.</param>
        /// <returns>A Vector2 (X, Y).</returns>
        public static Vector2 ToVector2XY(this Vector3 vector) => new(vector.x, vector.y);

        /// <summary>
        /// Creates a Vector2 using the X and Z components of the Vector3.
        /// </summary>
        /// <param name="vector">The source Vector3.</param>
        /// <returns>A Vector2 (X, Z).</returns>
        public static Vector2 ToVector2XZ(this Vector3 vector) => new(vector.x, vector.z);

        /// <summary>
        /// Creates a Vector2 using the Y and X components of the Vector3.
        /// </summary>
        /// <param name="vector">The source Vector3.</param>
        /// <returns>A Vector2 (Y, X).</returns>
        public static Vector2 ToVector2YX(this Vector3 vector) => new(vector.y, vector.x);

        /// <summary>
        /// Creates a Vector2 using the Y component of the Vector3 for both X and Y.
        /// </summary>
        /// <param name="vector">The source Vector3.</param>
        /// <returns>A Vector2 (Y, Y).</returns>
        public static Vector2 ToVector2YY(this Vector3 vector) => new(vector.y, vector.y);

        /// <summary>
        /// Creates a Vector2 using the Y and Z components of the Vector3.
        /// </summary>
        /// <param name="vector">The source Vector3.</param>
        /// <returns>A Vector2 (Y, Z).</returns>
        public static Vector2 ToVector2YZ(this Vector3 vector) => new(vector.y, vector.z);

        /// <summary>
        /// Creates a Vector2 using the Z and X components of the Vector3.
        /// </summary>
        /// <param name="vector">The source Vector3.</param>
        /// <returns>A Vector2 (Z, X).</returns>
        public static Vector2 ToVector2ZX(this Vector3 vector) => new(vector.z, vector.x);

        /// <summary>
        /// Creates a Vector2 using the Z and Y components of the Vector3.
        /// </summary>
        /// <param name="vector">The source Vector3.</param>
        /// <returns>A Vector2 (Z, Y).</returns>
        public static Vector2 ToVector2ZY(this Vector3 vector) => new(vector.z, vector.y);

        /// <summary>
        /// Creates a Vector2 using the Z component of the Vector3 for both X and Y.
        /// </summary>
        /// <param name="vector">The source Vector3.</param>
        /// <returns>A Vector2 (Z, Z).</returns>
        public static Vector2 ToVector2ZZ(this Vector3 vector) => new(vector.z, vector.z);
        
        /// <summary>
        /// Determines if the Vector3 is within the specified Bounds.
        /// </summary>
        /// <param name="v">The Vector3 to check.</param>
        /// <param name="bounds">The Bounds to check against.</param>
        /// <returns>True if the vector is within the bounds; otherwise, false.</returns>
        public static bool Within(this Vector3 v, Bounds bounds) => v.x.Within(bounds.min.x, bounds.max.x) && v.y.Within(bounds.min.y, bounds.max.y) && v.z.Within(bounds.min.z, bounds.max.z);

        /// <summary>
        /// Determines if the Vector3 is within the specified BoundsInt.
        /// </summary>
        /// <param name="v">The Vector3 to check.</param>
        /// <param name="bounds">The BoundsInt to check against.</param>
        /// <returns>True if the vector is within the bounds; otherwise, false.</returns>
        public static bool Within(this Vector3 v, BoundsInt bounds) => v.x.Within(bounds.min.x, bounds.max.x) && v.y.Within(bounds.min.y, bounds.max.y) && v.z.Within(bounds.min.z, bounds.max.z);
        
        /// <summary>
        /// Rotates the vector around the specified axis by the given angle in degrees.
        /// </summary>
        /// <param name="vector">The vector to rotate.</param>
        /// <param name="angleDegrees">The angle in degrees to rotate.</param>
        /// <param name="axis">The axis to rotate around (should be normalized).</param>
        /// <returns>The rotated vector.</returns>
        public static Vector3 RotateAroundAxis(this Vector3 vector, float angleDegrees, Vector3 axis)
        {
            return Quaternion.AngleAxis(angleDegrees, axis.normalized) * vector;
        }
        
        /// <summary>
        /// Clamps each component of the vector to the corresponding min and max values of the given Bounds.
        /// </summary>
        /// <param name="v">The vector to clamp.</param>
        /// <param name="bounds">The Bounds providing min and max values for each component.</param>
        /// <returns>A new Vector3 with each component clamped within the bounds.</returns>
        public static Vector3 Clamp(this Vector3 v, Bounds bounds)
        {
            v.x = v.x.Clamp(bounds.min.x, bounds.max.x);
            v.y = v.y.Clamp(bounds.min.y, bounds.max.y);
            v.z = v.z.Clamp(bounds.min.z, bounds.max.z);
            return v;
        }
    }
}
