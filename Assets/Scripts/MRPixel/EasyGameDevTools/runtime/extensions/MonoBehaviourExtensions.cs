using System;
using System.Collections;
using UnityEngine;

namespace MRPixel.EasyGameDevTools.Runtime.Extensions
{
     public static class MonoBehaviourExtensions
    {
        /// <summary>
        /// Invokes the specified action after a delay.
        /// </summary>
        /// <param name="mb">The MonoBehaviour instance.</param>
        /// <param name="action">The action to invoke.</param>
        /// <param name="delay">The delay in seconds before invoking the action.</param>
        public static void InvokeDelayed(this MonoBehaviour mb, Action action, float delay)
        {
            mb.StartCoroutine(InvokeRoutine(action, delay));
        }

        /// <summary>
        /// Coroutine that waits for the specified delay and then invokes the action.
        /// </summary>
        /// <param name="action">The action to invoke.</param>
        /// <param name="delay">The delay in seconds.</param>
        private static IEnumerator InvokeRoutine(Action action, float delay)
        {
            yield return new WaitForSeconds(delay);
            action?.Invoke();
        }

        /// <summary>
        /// Starts a coroutine that waits for the specified time and then executes the action.
        /// </summary>
        /// <param name="mb">The MonoBehaviour instance.</param>
        /// <param name="seconds">The time to wait in seconds.</param>
        /// <param name="action">The action to execute after waiting.</param>
        /// <returns>The started coroutine.</returns>
        public static Coroutine WaitAndDo(this MonoBehaviour mb, float seconds, Action action)
        {
            return mb.StartCoroutine(WaitRoutine(seconds, action));
        }

        /// <summary>
        /// Coroutine that waits for the specified time and then executes the action.
        /// </summary>
        /// <param name="seconds">The time to wait in seconds.</param>
        /// <param name="action">The action to execute after waiting.</param>
        private static IEnumerator WaitRoutine(float seconds, Action action)
        {
            yield return new WaitForSeconds(seconds);
            action?.Invoke();
        }

        /// <summary>
        /// Starts a coroutine that waits until the specified condition is true and then executes the action.
        /// </summary>
        /// <param name="mb">The MonoBehaviour instance.</param>
        /// <param name="condition">The condition to evaluate.</param>
        /// <param name="onTrue">The action to execute when the condition is true.</param>
        /// <returns>The started coroutine.</returns>
        public static Coroutine WaitUntil(this MonoBehaviour mb, Func<bool> condition, Action onTrue)
        {
            return mb.StartCoroutine(WaitUntilRoutine(condition, onTrue));
        }

        /// <summary>
        /// Coroutine that waits until the specified condition is true and then executes the action.
        /// </summary>
        /// <param name="condition">The condition to evaluate.</param>
        /// <param name="onTrue">The action to execute when the condition is true.</param>
        private static IEnumerator WaitUntilRoutine(Func<bool> condition, Action onTrue)
        {
            yield return new WaitUntil(condition);
            onTrue?.Invoke();
        }
    }
}