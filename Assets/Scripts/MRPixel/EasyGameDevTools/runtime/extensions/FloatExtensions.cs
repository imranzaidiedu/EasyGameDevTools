using UnityEngine;

namespace MRPixel.EasyGameDevTools.Runtime.Extensions
{
    /// <summary>
    /// Extension methods for float operations.
    /// </summary>
    public static class FloatExtensions
    {
        /// <summary>
        /// Remaps a float value from one range to another.
        /// </summary>
        /// <param name="value">The value to remap.</param>
        /// <param name="from1">The lower bound of the original range.</param>
        /// <param name="to1">The upper bound of the original range.</param>
        /// <param name="from2">The lower bound of the target range.</param>
        /// <param name="to2">The upper bound of the target range.</param>
        /// <returns>The remapped value in the target range.</returns>
        public static float Remap(this float value, float from1, float to1, float from2, float to2)
        {
            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        }

        /// <summary>
        /// Clamps the float value between 0 and 1.
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <returns>The clamped value between 0 and 1.</returns>
        public static float Clamp01(this float value)
        {
            return Mathf.Clamp01(value);
        }

        /// <summary>
        /// Clamps the float value to a minimum value.
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="min">The minimum value.</param>
        /// <returns>The clamped value, not less than min.</returns>
        public static float ClampMin(this float value, float min)
        {
            return Mathf.Max(value, min);
        }

        /// <summary>
        /// Clamps the float value to a maximum value.
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>The clamped value, not greater than max.</returns>
        public static float ClampMax(this float value, float max)
        {
            return Mathf.Min(value, max);
        }
        
        /// <summary>
        /// Clamps the float value between the specified minimum and maximum values.
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>The clamped value, not less than min and not greater than max.</returns>
        public static float Clamp(this float value, float min, float max)
        {
            return Mathf.Clamp(value, min, max);
        }

        /// <summary>
        /// Converts degrees to radians.
        /// </summary>
        /// <param name="degrees">The angle in degrees.</param>
        /// <returns>The angle in radians.</returns>
        public static float ToRadians(this float degrees)
        {
            return degrees * Mathf.Deg2Rad;
        }

        /// <summary>
        /// Converts radians to degrees.
        /// </summary>
        /// <param name="radians">The angle in radians.</param>
        /// <returns>The angle in degrees.</returns>
        public static float ToDegrees(this float radians)
        {
            return radians * Mathf.Rad2Deg;
        }

        /// <summary>
        /// Rounds the float value to the nearest multiple of the specified value.
        /// </summary>
        /// <param name="value">The value to round.</param>
        /// <param name="nearest">The multiple to round to.</param>
        /// <returns>The value rounded to the nearest multiple.</returns>
        public static float RoundToNearest(this float value, float nearest)
        {
            return Mathf.Round(value / nearest) * nearest;
        }

        /// <summary>
        /// Checks if two float values are approximately equal within a given tolerance.
        /// </summary>
        /// <param name="a">The first value.</param>
        /// <param name="b">The second value.</param>
        /// <param name="tolerance">The allowed difference for equality. Default is 0.001.</param>
        /// <returns>True if the values are approximately equal; otherwise, false.</returns>
        public static bool Approximately(this float a, float b, float tolerance = 0.001f)
        {
            return Mathf.Abs(a - b) < tolerance;
        }

        /// <summary>
        /// Linearly interpolates between two values with clamped t.
        /// </summary>
        /// <param name="a">The start value.</param>
        /// <param name="b">The end value.</param>
        /// <param name="t">The interpolation factor, clamped between 0 and 1.</param>
        /// <returns>The interpolated value.</returns>
        public static float LerpClamped(this float a, float b, float t)
        {
            return Mathf.Lerp(a, b, Mathf.Clamp01(t));
        }

        /// <summary>
        /// Normalizes a float value within a given range to a value between 0 and 1.
        /// </summary>
        /// <param name="value">The value to normalize.</param>
        /// <param name="min">The minimum of the range.</param>
        /// <param name="max">The maximum of the range.</param>
        /// <returns>The normalized value between 0 and 1.</returns>
        public static float Normalize(this float value, float min, float max)
        {
            return Mathf.InverseLerp(min, max, value);
        }
        
        /// <summary>
        /// Compares two float values for equality within a specified epsilon.
        /// </summary>
        /// <param name="a">The first float value.</param>
        /// <param name="b">The second float value.</param>
        /// <returns>True if the values are equal within epsilon(1e-6); otherwise, false.</returns>
        public static bool EqualsEpsilon(this float a, float b)
        {
            return Mathf.Abs(a - b) <= Mathf.Epsilon;
        }
        
        /// <summary>
        /// Returns the percentage that value is between min and max.
        /// </summary>
        /// <param name="value">Current value.</param>
        /// <param name="min">Minimum value.</param>
        /// <param name="max">Maximum value.</param>
        /// <returns>Percentage as float between 0 and 1.</returns>
        public static float PercentBetween(this float value, float min, float max)
        {
            return (value - min) / (max - min);
        }
        
        /// <summary>
        /// Checks whether the float is approximately zero.
        /// </summary>
        /// <param name="value">The float to check.</param>
        /// <param name="tolerance">The tolerance considered as zero.</param>
        /// <returns>True if approximately zero.</returns>
        public static bool IsZero(this float value, float tolerance = 0.0001f)
        {
            return Mathf.Abs(value) < tolerance;
        }
        
        /// <summary>
        /// Determines whether the float value is within the inclusive range defined by min and max.
        /// </summary>
        /// <param name="value">The float value to check.</param>
        /// <param name="min">The minimum inclusive bound.</param>
        /// <param name="max">The maximum inclusive bound.</param>
        /// <returns>True if value is greater than or equal to min and less than or equal to max; otherwise, false.</returns>
        public static bool Within(this float value, float min, float max)
        {
            return value >= min && value <= max;
        }
    }
}