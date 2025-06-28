using UnityEngine;

namespace MRPixel.EasyGameDevTools.Runtime.Extensions
{
    public static class MonoBehaviourInstantiateExtensions
    {
        /// <summary>
        /// Instantiates a component prefab at a specific position and rotation.
        /// </summary>
        /// <typeparam name="T">The type of Component to instantiate.</typeparam>
        /// <param name="mb">The MonoBehaviour calling this method.</param>
        /// <param name="prefab">The component prefab to instantiate.</param>
        /// <param name="position">The world position for the instantiated object.</param>
        /// <param name="rotation">The world rotation for the instantiated object.</param>
        /// <returns>The instantiated component of type T.</returns>
        public static T InstantiateAt<T>(this MonoBehaviour mb, T prefab, Vector3 position, Quaternion rotation) where T : Component
        {
            return GameObject.Instantiate(prefab, position, rotation);
        }
    }
}
