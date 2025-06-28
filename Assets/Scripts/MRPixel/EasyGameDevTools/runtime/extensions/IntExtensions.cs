using UnityEngine;

namespace MRPixel.EasyGameDevTools.Runtime.Extensions
{
    /// <summary>
    /// Extension methods for integer operations.
    /// </summary>
    public static class IntExtensions
    {
        /// <summary>
        /// Determines whether the integer is even.
        /// </summary>
        /// <param name="value">The integer value to check.</param>
        /// <returns>True if the value is even; otherwise, false.</returns>
        public static bool IsEven(this int value)
        {
            return value % 2 == 0;
        }
        
        /// <summary>
        /// Determines whether the integer is odd.
        /// </summary>
        /// <param name="value">The integer value to check.</param>
        /// <returns>True if the value is odd; otherwise, false.</returns>
        public static bool IsOdd(this int value)
        {
            return value % 2 != 0;
        }

        /// <summary>
        /// Clamps the integer value between the specified minimum and maximum values.
        /// </summary>
        /// <param name="value">The integer value to clamp.</param>
        /// <param name="min">The minimum allowed value.</param>
        /// <param name="max">The maximum allowed value.</param>
        /// <returns>The clamped value, not less than min and not greater than max.</returns>
        public static int Clamp(this int value, int min, int max)
        {
            return value < min ? min : (value > max ? max : value);
        }

        /// <summary>
        /// Wraps the integer within a specified range.
        /// If the value is less than min, it wraps around to max; if greater than max, it wraps around to min.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int Wrap(this int value, int min, int max)
        {
            if (max <= min) return min;
            int range = max - min + 1;
            return (((value - min) % range + range) % range) + min;
        }

        /// <summary>
        /// Checks if the integer is a multiple of the given value.
        /// If the multiple is zero, returns false.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="multiple"></param>
        /// <returns></returns>
        public static bool IsMultipleOf(this int value, int multiple)
        {
            if (multiple == 0) return false;
            return value % multiple == 0;
        }

        /// <summary>
        /// Raises the integer to the power of the given exponent.
        /// If the exponent is negative, it returns 0.
        /// </summary>
        /// <param name="baseValue"></param>
        /// <param name="exponent"></param>
        /// <returns></returns>
        public static int Pow(this int baseValue, int exponent)
        {
            return (int)System.Math.Pow(baseValue, exponent);
        }

        /// <summary>
        /// Converts the integer to a boolean value.
        /// Returns true if the integer is non-zero, false if it is zero.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ToBool(this int value)
        {
            return value != 0;
        }
        
        /// <summary>
        /// Checks if the integer is within a specified range (inclusive).
        /// If the min is greater than max, it returns false.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static bool WithinRange(this int value, int min, int max)
        {
            return value >= min && value <= max;
        }
        
        /// <summary>
        /// Returns true if the integer is within the inclusive range.
        /// </summary>
        /// <param name="value">The value to evaluate.</param>
        /// <param name="min">Minimum allowed value.</param>
        /// <param name="max">Maximum allowed value.</param>
        /// <returns>True if within [min, max].</returns>
        public static bool IsBetween(this int value, int min, int max)
        {
            return value >= min && value <= max;
        }
        
        /// <summary>
        /// Returns true if the integer is a prime number.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>True if prime, otherwise false.</returns>
        public static bool IsPrime(this int value)
        {
            if (value <= 1) return false;
            if (value == 2) return true;
            if (value % 2 == 0) return false;
            for (int i = 3; i * i <= value; i += 2)
            {
                if (value % i == 0) return false;
            }
            return true;
        }
        
        /// <summary>
        /// Determines whether the integer value is within the inclusive range defined by min and max.
        /// </summary>
        /// <param name="value">The integer value to check.</param>
        /// <param name="min">The minimum inclusive bound.</param>
        /// <param name="max">The maximum inclusive bound.</param>
        /// <returns>True if value is greater than or equal to min and less than or equal to max; otherwise, false.</returns>
        public static bool Within(this int value, int min, int max)
        {
            return value >= min && value <= max;
        }
    }
}
