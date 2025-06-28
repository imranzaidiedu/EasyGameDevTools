using UnityEngine;

namespace MRPixel.EasyGameDevTools.Runtime.Extensions
{
    public static class MonoBehaviourPrefsExtensions
    {
        /// <summary>
        /// Saves an integer value to PlayerPrefs with the specified key.
        /// </summary>
        /// <param name="mb">The MonoBehaviour calling this method.</param>
        /// <param name="key">The key to store the value under.</param>
        /// <param name="value">The integer value to save.</param>
        public static void SaveInt(this MonoBehaviour mb, string key, int value) => PlayerPrefs.SetInt(key, value);

        /// <summary>
        /// Saves a float value to PlayerPrefs with the specified key.
        /// </summary>
        /// <param name="mb">The MonoBehaviour calling this method.</param>
        /// <param name="key">The key to store the value under.</param>
        /// <param name="value">The float value to save.</param>
        public static void SaveFloat(this MonoBehaviour mb, string key, float value) => PlayerPrefs.SetFloat(key, value);

        /// <summary>
        /// Saves a string value to PlayerPrefs with the specified key.
        /// </summary>
        /// <param name="mb">The MonoBehaviour calling this method.</param>
        /// <param name="key">The key to store the value under.</param>
        /// <param name="value">The string value to save.</param>
        public static void SaveString(this MonoBehaviour mb, string key, string value) => PlayerPrefs.SetString(key, value);

        /// <summary>
        /// Loads an integer value from PlayerPrefs with the specified key.
        /// </summary>
        /// <param name="mb">The MonoBehaviour calling this method.</param>
        /// <param name="key">The key to retrieve the value from.</param>
        /// <param name="defaultValue">The default value if the key does not exist.</param>
        /// <returns>The loaded integer value.</returns>
        public static int LoadInt(this MonoBehaviour mb, string key, int defaultValue = 0) => PlayerPrefs.GetInt(key, defaultValue);

        /// <summary>
        /// Loads a float value from PlayerPrefs with the specified key.
        /// </summary>
        /// <param name="mb">The MonoBehaviour calling this method.</param>
        /// <param name="key">The key to retrieve the value from.</param>
        /// <param name="defaultValue">The default value if the key does not exist.</param>
        /// <returns>The loaded float value.</returns>
        public static float LoadFloat(this MonoBehaviour mb, string key, float defaultValue = 0f) => PlayerPrefs.GetFloat(key, defaultValue);

        /// <summary>
        /// Loads a string value from PlayerPrefs with the specified key.
        /// </summary>
        /// <param name="mb">The MonoBehaviour calling this method.</param>
        /// <param name="key">The key to retrieve the value from.</param>
        /// <param name="defaultValue">The default value if the key does not exist.</param>
        /// <returns>The loaded string value.</returns>
        public static string LoadString(this MonoBehaviour mb, string key, string defaultValue = "") => PlayerPrefs.GetString(key, defaultValue);
    }
}