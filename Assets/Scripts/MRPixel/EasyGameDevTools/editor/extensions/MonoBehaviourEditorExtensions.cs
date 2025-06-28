using UnityEngine;

namespace MRPixel.EasyGameDevTools.Editor.Extensions
{
#if UNITY_EDITOR
    public static class MonoBehaviourEditorExtensions
    {
        /// <summary>
        /// Marks the specified MonoBehaviour as dirty in the Unity Editor,
        /// indicating that it has been modified and needs to be saved.
        /// </summary>
        /// <param name="mb">The MonoBehaviour to mark as dirty.</param>
        public static void MarkDirty(this MonoBehaviour mb)
        {
            UnityEditor.EditorUtility.SetDirty(mb);
        }
    }
#endif
}
