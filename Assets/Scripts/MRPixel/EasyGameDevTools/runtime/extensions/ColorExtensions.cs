using UnityEngine;

namespace MRPixel.EasyGameDevTools.Runtime.Extensions
{
    public static class ColorExtensions
    {
        private const float LuminanceRed = 0.299f;
        private const float LuminanceGreen = 0.587f;
        private const float LuminanceBlue = 0.114f;
        
        /// <summary>
        /// Returns a new color with the same RGB values and a modified alpha.
        /// </summary>
        /// <param name="color">The source color.</param>
        /// <param name="alpha">The new alpha value (0-1).</param>
        /// <returns>A new color with the specified alpha.</returns>
        public static Color SetAlpha(this Color color, float alpha)
        {
            return new Color(color.r, color.g, color.b, alpha);
        }

        
        /// <summary>
        /// Converts the color to grayscale using the luminance formula.
        /// </summary>
        /// <param name="color">The source color.</param>
        /// <returns>A grayscale version of the color.</returns>
        public static Color ToGrayscale(this Color color)
        {
            float gray = color.r * LuminanceRed + color.g * LuminanceGreen + color.b * LuminanceBlue;
            return new Color(gray, gray, gray, color.a);
        }

        /// <summary>
        /// Blends this color with another color by a given factor.
        /// </summary>
        /// <param name="color">The first color.</param>
        /// <param name="other">The second color to blend with.</param>
        /// <param name="t">Blend factor (0 = this color, 1 = other color).</param>
        /// <returns>The blended color.</returns>
        public static Color Blend(this Color color, Color other, float t)
        {
            return Color.Lerp(color, other, t);
        }
        
        /// <summary>
        /// Converts a hex color code string to a Unity Color.
        /// </summary>
        /// <param name="hex">Hex color code (e.g., "#RRGGBB" or "#RRGGBBAA").</param>
        /// <returns>The corresponding Color. Returns Color.clear if parsing fails.</returns>
        public static Color ColorFromHex(this string hex)
        {
            if (ColorUtility.TryParseHtmlString(hex, out var color))
                return color;
            return Color.clear;
        }
        
        /// <summary>
        /// Converts the Color to a hex string in the format #RRGGBB or #RRGGBBAA.
        /// </summary>
        /// <param name="color">The color to convert.</param>
        /// <param name="includeAlpha">Whether to include the alpha channel in the hex string.</param>
        /// <returns>The hex string representation of the color.</returns>
        public static string ToHex(this Color color, bool includeAlpha = false)
        {
            Color32 color32 = color;
            if (includeAlpha || color32.a < 255)
                return $"#{color32.r:X2}{color32.g:X2}{color32.b:X2}{color32.a:X2}";
            else
                return $"#{color32.r:X2}{color32.g:X2}{color32.b:X2}";
        }
        
        /// <summary>
        /// Returns the inverted (complementary) color.
        /// </summary>
        /// <param name="color">The source color.</param>
        /// <returns>The inverted color.</returns>
        public static Color Invert(this Color color)
        {
            return new Color(1f - color.r, 1f - color.g, 1f - color.b, color.a);
        }

        /// <summary>
        /// Checks if two colors are approximately equal within a given tolerance.
        /// </summary>
        /// <param name="color">The first color.</param>
        /// <param name="other">The color to compare with.</param>
        /// <param name="tolerance">The allowed difference per channel.</param>
        /// <returns>True if colors are approximately equal, false otherwise.</returns>
        public static bool IsApproximatelyEqual(this Color color, Color other, float tolerance = 0.01f)
        {
            return Mathf.Abs(color.r - other.r) < tolerance &&
                   Mathf.Abs(color.g - other.g) < tolerance &&
                   Mathf.Abs(color.b - other.b) < tolerance &&
                   Mathf.Abs(color.a - other.a) < tolerance;
        }
        
        /// <summary>
        /// Multiplies the RGB channels of the color by a given scalar.
        /// </summary>
        /// <param name="color">The source color.</param>
        /// <param name="multiplier">The multiplier for the RGB channels.</param>
        /// <returns>A new color with multiplied RGB values.</returns>
        public static Color MultiplyRGB(this Color color, float multiplier)
        {
            return new Color(color.r * multiplier, color.g * multiplier, color.b * multiplier, color.a);
        }

        /// <summary>
        /// Returns a new color with modified RGB channels while keeping the original alpha.
        /// </summary>
        /// <param name="color">The source color.</param>
        /// <param name="newRed">New red value.</param>
        /// <param name="newGreen">New green value.</param>
        /// <param name="newBlue">New blue value.</param>
        /// <returns>The new color with updated RGB values.</returns>
        public static Color WithRGB(this Color color, float newRed, float newGreen, float newBlue)
        {
            return new Color(newRed, newGreen, newBlue, color.a);
        }

        /// <summary>
        /// Determines if the color is considered dark based on its luminance.
        /// </summary>
        /// <param name="color">The source color.</param>
        /// <returns>True if the color is dark; otherwise, false.</returns>
        public static bool IsDark(this Color color)
        {
            // Calculate luminance using the same weights
            float luminance = color.r * LuminanceRed + color.g * LuminanceGreen + color.b * LuminanceBlue;
            return luminance < 0.5f;
        }

        /// <summary>
        /// Determines if the color is considered light based on its luminance.
        /// </summary>
        /// <param name="color">The source color.</param>
        /// <returns>True if the color is light; otherwise, false.</returns>
        public static bool IsLight(this Color color)
        {
            return !color.IsDark();
        }
        
        /// <summary>
        /// Creates a new Color instance from 0-255 RGB values.
        /// </summary>
        /// <param name="red">Red component (0-255).</param>
        /// <param name="green">Green component (0-255).</param>
        /// <param name="blue">Blue component (0-255).</param>
        /// <returns>A new Color with normalized channel values and full opacity.</returns>
        public static Color ColorFromRGB255(int red, int green, int blue)
        {
            return new Color(red / 255f, green / 255f, blue / 255f, 1f);
        }
        
        /// <summary>
        /// Converts 0–255 RGB values to a hex string.
        /// Returns a hex string with full opacity or includes alpha if specified.
        /// </summary>
        /// <param name="red">Red component (0-255).</param>
        /// <param name="green">Green component (0-255).</param>
        /// <param name="blue">Blue component (0-255).</param>
        /// <param name="includeAlpha">If true, includes the alpha channel (assumed as 255 if not provided).</param>
        /// <returns>A hex string representation e.g. "#RRGGBB" or "#RRGGBBAA".</returns>
        public static string ColorFromRGB255ToHex(int red, int green, int blue, bool includeAlpha = false)
        {
            Color color = new Color(red / 255f, green / 255f, blue / 255f, 1f);
            return color.ToHex(includeAlpha);
        }

        /// <summary>
        /// Converts 0–255 RGBA values to a hex string including the alpha channel.
        /// </summary>
        /// <param name="red">Red component (0-255).</param>
        /// <param name="green">Green component (0-255).</param>
        /// <param name="blue">Blue component (0-255).</param>
        /// <param name="alpha">Alpha component (0-255).</param>
        /// <returns>A hex string representation in the format "#RRGGBBAA".</returns>
        public static string ColorFromRGB255ToHex(int red, int green, int blue, int alpha)
        {
            Color color = new Color(red / 255f, green / 255f, blue / 255f, alpha / 255f);
            return color.ToHex(true);
        }
        
        /// <summary>
        /// Converts the Color's RGB values to HSV.
        /// The returned Vector3 contains Hue, Saturation, and Value.
        /// </summary>
        /// <param name="color">The source color.</param>
        /// <returns>A Vector3 where x = Hue, y = Saturation, and z = Value.</returns>
        public static Vector3 ToHSV(this Color color)
        {
            Color.RGBToHSV(color, out float h, out float s, out float v);
            return new Vector3(h, s, v);
        }
        
        /// <summary>
        /// Gets the hue component (0-1) of the color using HSV conversion.
        /// </summary>
        public static float GetHue(this Color color)
        {
            Color.RGBToHSV(color, out float h, out _, out _);
            return h;
        }

        /// <summary>
        /// Gets the saturation component (0-1) of the color using HSV conversion.
        /// </summary>
        public static float GetSaturation(this Color color)
        {
            Color.RGBToHSV(color, out _, out float s, out _);
            return s;
        }

        /// <summary>
        /// Gets the vibrance (value) component (0-1) of the color using HSV conversion.
        /// </summary>
        public static float GetVibrance(this Color color)
        {
            Color.RGBToHSV(color, out _, out _, out float v);
            return v;
        }
        
        /// <summary>
        /// Converts HSV values (represented as a Vector3) to a Color.
        /// x = Hue, y = Saturation, and z = Value.
        /// </summary>
        /// <param name="hsv">The HSV values as a Vector3.</param>
        /// <returns>The corresponding Color with full opacity.</returns>
        public static Color ToColor(this Vector3 hsv)
        {
            // Unity's HSVToRGB returns a Color using full opacity by default.
            return Color.HSVToRGB(hsv.x, hsv.y, hsv.z);
        }
    }
}
