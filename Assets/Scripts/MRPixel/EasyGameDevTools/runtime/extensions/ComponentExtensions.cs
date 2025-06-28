using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.SceneManagement;

namespace MRPixel.EasyGameDevTools.Runtime.Extensions
{
    public static class ComponentExtensions
    {
        /// <summary>
        /// Gets the component of type T if it exists on the GameObject; otherwise, adds it and returns the new component.
        /// </summary>
        /// <typeparam name="T">The type of component to get or add.</typeparam>
        /// <param name="go">The GameObject to search or add the component to.</param>
        /// <returns>The existing or newly added component of type T.</returns>
        public static T GetOrAddComponent<T>(this GameObject go) where T : Component
        {
            return go.TryGetComponent<T>(out var comp) ? comp : go.AddComponent<T>();
        }

        /// <summary>
        /// Gets the component of type T if it exists on the MonoBehaviour's GameObject; otherwise, adds it and returns the new component.
        /// </summary>
        /// <typeparam name="T">The type of component to get or add.</typeparam>
        /// <param name="mb">The MonoBehaviour whose GameObject to search or add the component to.</param>
        /// <returns>The existing or newly added component of type T.</returns>
        public static T GetOrAddComponent<T>(this MonoBehaviour mb) where T : Component
        {
            return mb.gameObject.GetOrAddComponent<T>();
        }

        /// <summary>
        /// Sets the active state of the MonoBehaviour's GameObject.
        /// </summary>
        /// <param name="mb">The MonoBehaviour whose GameObject to activate or deactivate.</param>
        /// <param name="state">True to activate, false to deactivate.</param>
        public static void SetActive(this MonoBehaviour mb, bool state)
        {
            mb.gameObject.SetActive(state);
        }
        
        /// <summary>
        /// Gets all components that implement an interface on the passed scene
        /// </summary>
        /// <typeparam name="T">The interface to be searched</typeparam>
        /// <param name="scene">The scene where the search should take place</param>
        /// <returns>A list with all component instances of type T on the passed scene</returns>
        public static List<Component> FindObjectsWithInterface(this Scene scene, Type type, bool includeInactive)
        {
            List<Component> results = new List<Component>();
            foreach (var root in scene.GetRootGameObjects())
            {
                foreach (var comp in root.GetComponentsInChildren<Component>(includeInactive))
                {
                    if (type.IsAssignableFrom(comp.GetType()))
                    {
                        results.Add(comp);
                    }
                }
            }
            return results;
        }

        /// <summary>
        /// Gets all components that implement an interface on the passed scene
        /// </summary>
        /// <typeparam name="T">The interface to be searched</typeparam>
        /// <param name="scene">The scene where the search should take place</param>
        /// <returns>A list with all component instances of type T on the passed scene</returns>
        public static List<T> FindObjectsWithInterface<T>(this Scene scene)
        {
            List<T> results = new List<T>();
            foreach (var root in scene.GetRootGameObjects())
            {
                foreach (var comp in root.GetComponentsInChildren<Component>(true))
                {
                    if (comp is T tComp)
                    {
                        results.Add(tComp);
                    }
                }
            }
            return results;
        }
    }
}
