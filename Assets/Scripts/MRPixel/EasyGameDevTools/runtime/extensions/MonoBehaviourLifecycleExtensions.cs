using UnityEngine;

namespace MRPixel.EasyGameDevTools.Runtime.Extensions
{
    public static class MonoBehaviourLifecycleExtensions
    {
        /// <summary>
        /// Enables or disables a component of type T attached to the MonoBehaviour's GameObject.
        /// </summary>
        /// <typeparam name="T">The type of Behaviour to enable or disable.</typeparam>
        /// <param name="mb">The MonoBehaviour whose component to modify.</param>
        /// <param name="state">True to enable, false to disable. Default is true.</param>
        public static void EnableBehaviour<T>(this MonoBehaviour mb, bool state = true) where T : Behaviour
        {
            var comp = mb.GetComponent<T>();
            if (comp != null)
                comp.enabled = state;
        }

        /// <summary>
        /// Disables a component of type T attached to the MonoBehaviour's GameObject.
        /// </summary>
        /// <typeparam name="T">The type of Behaviour to disable.</typeparam>
        /// <param name="mb">The MonoBehaviour whose component to disable.</param>
        public static void DisableBehaviour<T>(this MonoBehaviour mb) where T : Behaviour
        {
            mb.EnableBehaviour<T>(false);
        }

        /// <summary>
        /// Checks if the MonoBehaviour is not null and is both active and enabled.
        /// </summary>
        /// <param name="mb">The MonoBehaviour to check.</param>
        /// <returns>True if the MonoBehaviour is not null and is active and enabled; otherwise, false.</returns>
        public static bool IsActiveAndEnabledSafe(this MonoBehaviour mb)
        {
            return mb != null && mb.isActiveAndEnabled;
        }

        /// <summary>
        /// Checks if the MonoBehaviour is not null and its GameObject is part of a valid scene.
        /// </summary>
        /// <param name="mb">The MonoBehaviour to check.</param>
        /// <returns>True if the MonoBehaviour is in a valid scene; otherwise, false.</returns>
        public static bool IsInScene(this MonoBehaviour mb)
        {
            return mb != null && mb.gameObject.scene.IsValid();
        }
    }
}
