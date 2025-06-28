using System.Collections;
using UnityEngine;
using System.Linq;

namespace MRPixel.EasyGameDevTools.Runtime.Extensions
{
    public static class MonoBehaviourTransformExtensions
    {
        /// <summary>
        /// Resets the local position, rotation, and scale of the MonoBehaviour's transform to their default values.
        /// </summary>
        /// <param name="mb">The MonoBehaviour whose transform to reset.</param>
        public static void ResetTransform(this MonoBehaviour mb)
        {
            var t = mb.transform;
            t.localPosition = Vector3.zero;
            t.localRotation = Quaternion.identity;
            t.localScale = Vector3.one;
        }

        /// <summary>
        /// Resets the world position of the MonoBehaviour's transform to Vector3.zero.
        /// </summary>
        /// <param name="mb">The MonoBehaviour whose position to reset.</param>
        public static void ResetPosition(this MonoBehaviour mb)
        {
            mb.transform.position = Vector3.zero;
        }

        /// <summary>
        /// Resets the world rotation of the MonoBehaviour's transform to Quaternion.identity.
        /// </summary>
        /// <param name="mb">The MonoBehaviour whose rotation to reset.</param>
        public static void ResetRotation(this MonoBehaviour mb)
        {
            mb.transform.rotation = Quaternion.identity;
        }

        /// <summary>
        /// Resets the local position of the MonoBehaviour's transform to Vector3.zero.
        /// </summary>
        /// <param name="mb">The MonoBehaviour whose local position to reset.</param>
        public static void ResetLocalPosition(this MonoBehaviour mb)
        {
            mb.transform.localPosition = Vector3.zero;
        }

        /// <summary>
        /// Resets the local rotation of the MonoBehaviour's transform to Quaternion.identity.
        /// </summary>
        /// <param name="mb">The MonoBehaviour whose local rotation to reset.</param>
        public static void ResetLocalRotation(this MonoBehaviour mb)
        {
            mb.transform.localRotation = Quaternion.identity;
        }

        /// <summary>
        /// Rotates the MonoBehaviour's transform to look at a 2D target position.
        /// </summary>
        /// <param name="mb">The MonoBehaviour to rotate.</param>
        /// <param name="target">The 2D target position to look at.</param>
        public static void LookAt2D(this MonoBehaviour mb, Vector2 target)
        {
            Vector2 dir = (target - (Vector2)mb.transform.position).normalized;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            mb.transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        /// <summary>
        /// Sets the world position of the MonoBehaviour's transform.
        /// </summary>
        /// <param name="mb">The MonoBehaviour whose position to set.</param>
        /// <param name="position">The new world position.</param>
        public static void SetPosition(this MonoBehaviour mb, Vector3 position)
        {
            mb.transform.position = position;
        }

        /// <summary>
        /// Sets the local position of the MonoBehaviour's transform.
        /// </summary>
        /// <param name="mb">The MonoBehaviour whose local position to set.</param>
        /// <param name="position">The new local position.</param>
        public static void SetLocalPosition(this MonoBehaviour mb, Vector3 position)
        {
            mb.transform.localPosition = position;
        }

        /// <summary>
        /// Moves the MonoBehaviour's transform to a specified position, either in world or local space.
        /// </summary>
        /// <param name="mb">The MonoBehaviour to move.</param>
        /// <param name="position">The target position.</param>
        /// <param name="isLocal">If true, moves in local space; otherwise, in world space.</param>
        public static void MoveTo(this MonoBehaviour mb, Vector3 position, bool isLocal = false)
        {
            if (isLocal)
                mb.transform.localPosition = position;
            else
                mb.transform.position = position;
        }

        /// <summary>
        /// Rotates the MonoBehaviour's transform to a specified angle in 2D space.
        /// </summary>
        /// <param name="mb">The MonoBehaviour to rotate.</param>
        /// <param name="angle">The angle in degrees.</param>
        public static void RotateToAngle2D(this MonoBehaviour mb, float angle)
        {
            mb.transform.rotation = Quaternion.Euler(0, 0, angle);
        }

        /// <summary>
        /// Sets the local scale of the MonoBehaviour's transform.
        /// </summary>
        /// <param name="mb">The MonoBehaviour whose scale to set.</param>
        /// <param name="scale">The new local scale.</param>
        public static void SetLocalScale(this MonoBehaviour mb, Vector3 scale)
        {
            mb.transform.localScale = scale;
        }

        /// <summary>
        /// Sets a uniform local scale for the MonoBehaviour's transform.
        /// </summary>
        /// <param name="mb">The MonoBehaviour whose scale to set.</param>
        /// <param name="uniformScale">The uniform scale value.</param>
        public static void SetUniformScale(this MonoBehaviour mb, float uniformScale)
        {
            mb.transform.localScale = Vector3.one * uniformScale;
        }

        /// <summary>
        /// Rotates the MonoBehaviour's transform to look at a target in 3D space.
        /// </summary>
        /// <param name="mb">The MonoBehaviour to rotate.</param>
        /// <param name="target">The target transform to look at.</param>
        public static void LookAtTarget(this MonoBehaviour mb, Transform target)
        {
            mb.transform.LookAt(target);
        }

        /// <summary>
        /// Rotates the MonoBehaviour's transform to look at a 2D target using the Z-axis.
        /// </summary>
        /// <param name="mb">The MonoBehaviour to rotate.</param>
        /// <param name="target">The 2D target position.</param>
        public static void LookAtTarget2D(this MonoBehaviour mb, Vector2 target)
        {
            Vector2 dir = target - (Vector2)mb.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            mb.transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }

        /// <summary>
        /// Sets the parent of the MonoBehaviour's transform.
        /// </summary>
        /// <param name="mb">The MonoBehaviour whose parent to set.</param>
        /// <param name="newParent">The new parent transform.</param>
        /// <param name="worldPositionStays">Whether to keep the world position.</param>
        public static void SetParent(this MonoBehaviour mb, Transform newParent, bool worldPositionStays = true)
        {
            mb.transform.SetParent(newParent, worldPositionStays);
        }

        /// <summary>
        /// Detaches the MonoBehaviour's transform from its parent.
        /// </summary>
        /// <param name="mb">The MonoBehaviour to detach.</param>
        public static void DetachFromParent(this MonoBehaviour mb)
        {
            mb.transform.SetParent(null);
        }

        /// <summary>
        /// Destroys all children of the MonoBehaviour's GameObject.
        /// </summary>
        /// <param name="mb">The MonoBehaviour whose children to destroy.</param>
        public static void DestroyAllChildren(this MonoBehaviour mb)
        {
            var t = mb.transform;
            for (int i = t.childCount - 1; i >= 0; i--)
            {
                GameObject.Destroy(t.GetChild(i).gameObject);
            }
        }

        /// <summary>
        /// Recursively finds a child transform by name.
        /// </summary>
        /// <param name="mb">The MonoBehaviour to search from.</param>
        /// <param name="name">The name of the child to find.</param>
        /// <returns>The found child transform, or null if not found.</returns>
        public static Transform FindDeepChild(this MonoBehaviour mb, string name)
        {
            return FindInChildrenRecursive(mb.transform, name);
        }

        /// <summary>
        /// Helper method to recursively search for a child transform by name using DFS.
        /// </summary>
        /// <param name="parent">The parent transform to search from.</param>
        /// <param name="name">The name of the child to find.</param>
        /// <returns>The found child transform, or null if not found.</returns>
        private static Transform FindInChildrenRecursive(Transform parent, string name)
        {
            if (parent == null || string.IsNullOrEmpty(name))
                return null;

            for (int i = 0; i < parent.childCount; i++)
            {
                var child = parent.GetChild(i);
                if (child.name == name)
                    return child;

                var result = FindInChildrenRecursive(child, name);
                if (result != null)
                    return result;
            }
            return null;
        }
        
        /// <summary>
        /// Attempts to get a child transform by index.
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="index"></param>
        /// <param name="child"></param>
        /// <returns></returns>
        public static bool TryGetChild(this Transform transform, int index, out Transform child)
        {
            if (transform && index.WithinRange(0, transform.childCount))
            {
                child = transform.GetChild(index);
                return true;
            }
            else
            {
                child = default;
                return false;
            }
        }
        
        /// <summary>
        /// Attempts to find a child transform by name.
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="name"></param>
        /// <param name="child"></param>
        /// <returns></returns>
        public static bool TryFind(this Transform transform, string name, out Transform child) => child = transform.Find(name);

        /// <summary>
        /// Resets the local position, rotation, and scale of the MonoBehaviour's transform to their default values.
        /// </summary>
        /// <param name="mb">The MonoBehaviour whose local transform to reset.</param>
        public static void ResetLocalTransform(this MonoBehaviour mb)
        {
            var t = mb.transform;
            t.localPosition = Vector3.zero;
            t.localRotation = Quaternion.identity;
            t.localScale = Vector3.one;
        }

        /// <summary>
        /// Aligns the MonoBehaviour's transform position and rotation with another transform.
        /// </summary>
        /// <param name="mb">The MonoBehaviour to align.</param>
        /// <param name="other">The transform to align with.</param>
        public static void AlignWith(this MonoBehaviour mb, Transform other)
        {
            var t = mb.transform;
            t.position = other.position;
            t.rotation = other.rotation;
        }

        /// <summary>
        /// Instantly rotates the MonoBehaviour's transform to face a target in 3D space.
        /// </summary>
        /// <param name="mb">The MonoBehaviour to rotate.</param>
        /// <param name="target">The target transform to face.</param>
        public static void FaceTarget(this MonoBehaviour mb, Transform target)
        {
            Vector3 direction = target.position - mb.transform.position;
            if (direction != Vector3.zero)
                mb.transform.rotation = Quaternion.LookRotation(direction);
        }

        /// <summary>
        /// Instantly rotates the MonoBehaviour's transform to face a given direction.
        /// </summary>
        /// <param name="mb">The MonoBehaviour to rotate.</param>
        /// <param name="direction">The direction to face.</param>
        public static void FaceDirection(this MonoBehaviour mb, Vector3 direction)
        {
            if (direction != Vector3.zero)
                mb.transform.rotation = Quaternion.LookRotation(direction);
        }

        /// <summary>
        /// Checks if the MonoBehaviour's transform is within a certain distance of another transform.
        /// </summary>
        /// <param name="mb">The MonoBehaviour to check from.</param>
        /// <param name="other">The other transform to check distance to.</param>
        /// <param name="distance">The maximum distance.</param>
        /// <returns>True if within range; otherwise, false.</returns>
        public static bool IsWithinRangeOf(this MonoBehaviour mb, Transform other, float distance)
        {
            return Vector3.Distance(mb.transform.position, other.position) <= distance;
        }

        /// <summary>
        /// Gets the distance from the MonoBehaviour's transform to another transform.
        /// </summary>
        /// <param name="mb">The MonoBehaviour to measure from.</param>
        /// <param name="other">The other transform to measure to.</param>
        /// <returns>The distance between the two transforms.</returns>
        public static float DistanceTo(this MonoBehaviour mb, Transform other)
        {
            return Vector3.Distance(mb.transform.position, other.position);
        }
    }
}