using UnityEngine;
using System;
using System.Collections;

namespace MRPixel.EasyGameDevTools.Runtime.Extensions
{
    public static class MonoBehaviourConditionExtensions
    {
        /// <summary>
        /// Starts a coroutine that waits until the result of the check function is null, then invokes onComplete.
        /// </summary>
        /// <typeparam name="T">The reference type to check for null.</typeparam>
        /// <param name="mb">The MonoBehaviour to start the coroutine on.</param>
        /// <param name="check">A function returning the object to check for null.</param>
        /// <param name="onComplete">Action to invoke when the object becomes null.</param>
        /// <returns>The started Coroutine.</returns>
        public static Coroutine WaitUntilNull<T>(this MonoBehaviour mb, Func<T> check, Action onComplete) where T : class
        {
            return mb.StartCoroutine(WaitUntilNullRoutine(check, onComplete));
        }

        /// <summary>
        /// Coroutine that waits until the result of the check function is null, then invokes onComplete.
        /// </summary>
        /// <typeparam name="T">The reference type to check for null.</typeparam>
        /// <param name="check">A function returning the object to check for null.</param>
        /// <param name="onComplete">Action to invoke when the object becomes null.</param>
        private static IEnumerator WaitUntilNullRoutine<T>(Func<T> check, Action onComplete) where T : class
        {
            yield return new WaitUntil(() => check() == null);
            onComplete?.Invoke();
        }

        /// <summary>
        /// Starts a coroutine that repeatedly invokes doAction until the condition returns true, waiting for the specified interval between invocations.
        /// </summary>
        /// <param name="mb">The MonoBehaviour to start the coroutine on.</param>
        /// <param name="condition">A function that returns true to stop the loop.</param>
        /// <param name="doAction">The action to invoke while the condition is false.</param>
        /// <param name="interval">Time in seconds to wait between invocations. Default is 0.1f.</param>
        /// <returns>The started Coroutine.</returns>
        public static Coroutine DoUntil(this MonoBehaviour mb, Func<bool> condition, Action doAction, float interval = 0.1f)
        {
            return mb.StartCoroutine(DoUntilRoutine(condition, doAction, interval));
        }

        /// <summary>
        /// Coroutine that repeatedly invokes action until the condition returns true, waiting for the specified interval between invocations.
        /// </summary>
        /// <param name="condition">A function that returns true to stop the loop.</param>
        /// <param name="action">The action to invoke while the condition is false.</param>
        /// <param name="interval">Time in seconds to wait between invocations.</param>
        private static IEnumerator DoUntilRoutine(Func<bool> condition, Action action, float interval)
        {
            while (!condition())
            {
                action?.Invoke();
                yield return new WaitForSeconds(interval);
            }
        }
    }
}
