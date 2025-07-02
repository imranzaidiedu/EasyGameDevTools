using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MRPixel.EasyGameDevTools.Runtime.Extensions
{
    public static class AwaiterExtension
    {
        /// <summary>
        /// Creates an awaiter that completes after the specified duration.
        /// </summary>
        /// <param name="timeSpan">The duration to wait.</param>
        /// <returns>A TaskAwaiter that signals when the wait is complete.</returns>
        public static TaskAwaiter GetAwaiter(this TimeSpan timeSpan)
        {
            return Task.Delay(timeSpan).GetAwaiter();
        }

        /// <summary>
        /// Creates an awaiter that completes after the specified number of seconds.
        /// </summary>
        /// <param name="seconds">The number of seconds to wait.</param>
        /// <returns>A TaskAwaiter that signals when the wait is complete.</returns>
        public static TaskAwaiter GetAwaiter(this int seconds)
        {
            return Task.Delay(TimeSpan.FromSeconds(seconds)).GetAwaiter();
        }

        /// <summary>
        /// Creates an awaiter that completes after the specified number of seconds.
        /// </summary>
        /// <param name="seconds">The number of seconds, as a float, to wait.</param>
        /// <returns>A TaskAwaiter that signals when the wait is complete.</returns>
        public static TaskAwaiter GetAwaiter(this float seconds)
        {
            return Task.Delay(TimeSpan.FromSeconds(seconds)).GetAwaiter();
        }
    }
}
