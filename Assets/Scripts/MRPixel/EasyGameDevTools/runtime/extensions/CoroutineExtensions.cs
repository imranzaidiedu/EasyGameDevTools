using System.Collections;
using UnityEngine;
using System;
using System.Threading;

namespace MRPixel.EasyGameDevTools.Runtime.Extensions
{
    public static class CoroutineExtensions
    {
        /// <summary>
        /// Starts a coroutine that executes the specified action after a delay, unless cancelled.
        /// </summary>
        /// <param name="mb">The MonoBehaviour to start the coroutine on.</param>
        /// <param name="delay">The delay in seconds before executing the action.</param>
        /// <param name="action">The action to execute after the delay.</param>
        /// <param name="token">A cancellation token to cancel the delayed execution.</param>
        /// <returns>The started Coroutine.</returns>
        public static Coroutine ExecuteAfterDelay(this MonoBehaviour mb, float delay, Action action, CancellationToken token)
        {
            return mb.StartCoroutine(ExecuteAfterDelayRoutine(delay, action, token));
        }

        /// <summary>
        /// Coroutine routine that waits for the specified delay and then executes the action, unless cancelled.
        /// </summary>
        /// <param name="delay">The delay in seconds before executing the action.</param>
        /// <param name="action">The action to execute after the delay.</param>
        /// <param name="token">A cancellation token to cancel the delayed execution.</param>
        /// <returns>An IEnumerator for coroutine execution.</returns>
        private static IEnumerator ExecuteAfterDelayRoutine(float delay, Action action, CancellationToken token)
        {
            float time = 0f;
            while (time < delay)
            {
                if (token.IsCancellationRequested)
                    yield break;

                time += Time.deltaTime;
                yield return null;
            }

            if (!token.IsCancellationRequested)
                action?.Invoke();
        }
        
        public static IEnumerator InvokeDelayed(this MonoBehaviour mb, float time, Action a) =>
            InvokeDelayed(mb, new WaitForSeconds(time), a);

        /// <summary>
        /// Invokes an action only after the yield instruction is complete
        /// </summary>
        /// <param name="mb">A monobehaviour on which a coroutine will be started</param>
        /// <param name="yieldInstruction">The instruction to be awaited before the action is invoked</param>
        /// <param name="action">The action to be invoked once the instruction is complete</param>
        /// <returns>A reference to the coroutine that was created</returns>
        public static IEnumerator InvokeDelayed(this MonoBehaviour mb, YieldInstruction yieldInstruction, Action action)
        {
            IEnumerator enumerator = action.EnumerateAfter(yieldInstruction);
            mb.StartCoroutine(enumerator);
            return enumerator;
        }

        /// <summary>
        /// Invokes an action only after the yield instruction is complete
        /// </summary>
        /// <param name="mb">A monobehaviour on which a coroutine will be started</param>
        /// <param name="yieldInstruction">The instruction to be awaited before the action is invoked</param>
        /// <param name="action">The action to be invoked once the instruction is complete</param>
        /// <returns>A reference to the coroutine that was created</returns>
        public static IEnumerator InvokeDelayed(this MonoBehaviour mb, CustomYieldInstruction yieldInstruction, Action action)
        {
            IEnumerator enumerator = action.EnumerateAfter(yieldInstruction);
            mb.StartCoroutine(enumerator);
            return enumerator;
        }

        /// <summary>
        /// Invokes an action only after the yield instruction is complete
        /// </summary>
        /// <param name="mb">A monobehaviour on which a coroutine will be started</param>
        /// <param name="yieldInstruction">The instruction to be awaited before the action is invoked</param>
        /// <param name="action">The action to be invoked once the instruction is complete</param>
        /// <returns>A reference to the coroutine that was created</returns>
        public static IEnumerator StartCoroutine(this MonoBehaviour mb, YieldInstruction yieldInstruction, Action action)
        {
            IEnumerator enumerator = action.EnumerateAfter(yieldInstruction);
            mb.StartCoroutine(enumerator);
            return enumerator;
        }

        /// <summary>
        /// Invokes an action only after the yield instruction is complete
        /// </summary>
        /// <param name="mb">A monobehaviour on which a coroutine will be started</param>
        /// <param name="yieldInstruction">The instruction to be awaited before the action is invoked</param>
        /// <param name="action">The action to be invoked once the instruction is complete</param>
        /// <returns>A reference to the coroutine that was created</returns>
        public static IEnumerator StartCoroutine(this MonoBehaviour mb, CustomYieldInstruction yieldInstruction, Action action)
        {
            IEnumerator enumerator = action.EnumerateAfter(yieldInstruction);
            mb.StartCoroutine(enumerator);
            return enumerator;
        }

        /// <summary>
        /// Returns an enumerator that fullfills the YieldInstruction then invokes the Action
        /// </summary>
        /// <param name="action">An action to be invoked after the YieldInstruction is complete</param>
        /// <param name="yieldInstruction">An instruction on what to wait for before invoking the Action</param>
        /// <returns>An IEnumerator that yield returns the YieldInstruction then invokes the Action</returns>
        public static IEnumerator EnumerateAfter(this Action action, YieldInstruction yieldInstruction)
        {
            yield return yieldInstruction;
            action.Invoke();
        }

        /// <summary>
        /// Returns an enumerator that fullfills the CustomYieldInstruction then invokes the Action
        /// </summary>
        /// <param name="action">An action to be invoked after the CustomYieldInstruction is complete</param>
        /// <param name="yieldInstruction">An instruction on what to wait for before invoking the Action</param>
        /// <returns>An IEnumerator that yield returns the CustomYieldInstruction then invokes the Action</returns>
        public static IEnumerator EnumerateAfter(this Action action, CustomYieldInstruction yieldInstruction)
        {
            yield return yieldInstruction;
            action.Invoke();
        }
    }
}
