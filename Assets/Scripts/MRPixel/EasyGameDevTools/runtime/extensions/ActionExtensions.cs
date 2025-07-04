using System;

namespace MRPixel.EasyGameDevTools.Runtime.Extensions
{
    public static class ActionExtensions
    {
        /// <summary>
        /// Safely invokes an Action if it is not null.
        /// </summary>
        /// <remarks>This method checks if the Action delegate is non-null before invoking it.</remarks>
        /// <returns>Nothing.</returns>
        public static void SafeInvoke(this Action action)
        {
            action?.Invoke();
        }
        
        /// <summary>
        /// Safely invokes an Action with one parameter if it is not null.
        /// </summary>
        /// <param name="t1">The first parameter passed to the Action.</param>
        /// <returns>Nothing.</returns>
        public static void SafeInvoke<T1>(this Action<T1> action, T1 t1)
        {
            action?.Invoke(t1);
        }
        
        /// <summary>
        /// Safely invokes an Action with two parameters if it is not null.
        /// </summary>
        /// <param name="t1">The first parameter passed to the Action.</param>
        /// <param name="t2">The second parameter passed to the Action.</param>
        /// <returns>Nothing.</returns>
        public static void SafeInvoke<T1, T2>(this Action<T1, T2> action, T1 t1, T2 t2)
        {
            action?.Invoke(t1, t2);
        }
        
        /// <summary>
        /// Safely invokes an Action with three parameters if it is not null.
        /// </summary>
        /// <param name="t1">The first parameter passed to the Action.</param>
        /// <param name="t2">The second parameter passed to the Action.</param>
        /// <param name="t3">The third parameter passed to the Action.</param>
        /// <returns>Nothing.</returns>
        public static void SafeInvoke<T1, T2, T3>(this Action<T1, T2, T3> action, T1 t1, T2 t2, T3 t3)
        {
            action?.Invoke(t1, t2, t3);
        }
        
        /// <summary>
        /// Safely invokes an array of Actions if they are not null.
        /// </summary>
        /// <remarks>This method iterates through the array and safely invokes each Action.</remarks>
        /// <returns>Nothing.</returns>
        public static void SafeInvoke(this Action[] actions)
        {
            for (var i = 0; i < actions.Length; i++)
            {
                var action = actions[i];
                action.SafeInvoke();
            }
        }

        /// <summary>
        /// Safely invokes an array of Actions with one parameter if they are not null.
        /// </summary>
        /// <param name="t1">The parameter passed to each Action.</param>
        /// <remarks>This method iterates through the array and safely invokes each Action with the specified parameter.</remarks>
        /// <returns>Nothing.</returns>
        public static void SafeInvoke<T1>(this Action<T1>[] actions, T1 t1)
        {
            for (var i = 0; i < actions.Length; i++)
            {
                var action = actions[i];
                action.SafeInvoke(t1);
            }
        }

        /// <summary>
        /// Safely invokes an array of Actions with two parameters if they are not null.
        /// </summary>
        /// <param name="t1">The first parameter passed to each Action.</param>
        /// <param name="t2">The second parameter passed to each Action.</param>
        /// <remarks>This method iterates through the array and safely invokes each Action with the specified parameters.</remarks>
        /// <returns>Nothing.</returns>
        public static void SafeInvoke<T1, T2>(this Action<T1, T2>[] actions, T1 t1, T2 t2)
        {
            for (var i = 0; i < actions.Length; i++)
            {
                var action = actions[i];
                action.SafeInvoke(t1, t2);
            }
        }

        /// <summary>
        /// Safely invokes an array of Actions with three parameters if they are not null.
        /// </summary>
        /// <param name="t1">The first parameter passed to each Action.</param>
        /// <param name="t2">The second parameter passed to each Action.</param>
        /// <param name="t3">The third parameter passed to each Action.</param>
        /// <remarks>This method iterates through the array and safely invokes each Action with the specified parameters.</remarks>
        /// <returns>Nothing.</returns>
        public static void SafeInvoke<T1, T2, T3>(this Action<T1, T2, T3>[] actions, T1 t1, T2 t2, T3 t3)
        {
            for (var i = 0; i < actions.Length; i++)
            {
                var action = actions[i];
                action.SafeInvoke(t1, t2, t3);
            }
        }
    }
}
