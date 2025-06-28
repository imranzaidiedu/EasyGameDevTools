using UnityEngine;

namespace MRPixel.EasyGameDevTools.Runtime.Extensions
{
    public static class GameObjectExtensions
    {
        /// <summary>
        /// Enables the MonoBehaviour's GameObject by setting it active.
        /// </summary>
        /// <param name="mb">The MonoBehaviour whose GameObject to enable.</param>
        public static void Enable(this MonoBehaviour mb)
        {
            mb.gameObject.SetActive(true);
        }

        /// <summary>
        /// Disables the MonoBehaviour's GameObject by setting it inactive.
        /// </summary>
        /// <param name="mb">The MonoBehaviour whose GameObject to disable.</param>
        public static void Disable(this MonoBehaviour mb)
        {
            mb.gameObject.SetActive(false);
        }

        /// <summary>
        /// Toggles the active state of the MonoBehaviour's GameObject.
        /// </summary>
        /// <param name="mb">The MonoBehaviour whose GameObject to toggle.</param>
        public static void ToggleActive(this MonoBehaviour mb)
        {
            mb.gameObject.SetActive(!mb.gameObject.activeSelf);
        }
    }
}
