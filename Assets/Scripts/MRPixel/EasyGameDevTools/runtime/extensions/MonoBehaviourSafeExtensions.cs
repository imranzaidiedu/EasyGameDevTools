using UnityEngine;
using System;

namespace MRPixel.EasyGameDevTools.Runtime.Extensions
{
    public static class MonoBehaviourSafeExtensions
    {
        /// <summary>
        /// Checks if the MonoBehaviour or its GameObject has been destroyed.
        /// </summary>
        /// <param name="mb">The MonoBehaviour instance to check.</param>
        /// <returns>True if the MonoBehaviour or its GameObject is destroyed; otherwise, false.</returns>
        public static bool IsDestroyed(this MonoBehaviour mb)
        {
            return mb == null || mb.gameObject == null;
        }

        /// <summary>
        /// Safely invokes the specified action if the MonoBehaviour and its GameObject are not destroyed.
        /// </summary>
        /// <param name="mb">The MonoBehaviour instance.</param>
        /// <param name="action">The action to invoke.</param>
        public static void SafeInvoke(this MonoBehaviour mb, Action action)
        {
            if (!mb.IsDestroyed())
                action?.Invoke();
        }
    }
}
