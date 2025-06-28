using UnityEngine;

namespace MRPixel.EasyGameDevTools.Runtime.Extensions
{
    public static class Vector3IntExtensions
    {
        /// <summary>
        /// Returns a new Vector3Int with the absolute values of each component.
        /// </summary>
        /// <param name="vector">The source Vector3Int.</param>
        /// <returns>A Vector3Int with absolute x, y, and z values.</returns>
        public static Vector3Int Abs(this Vector3Int vector)
        {
            return new Vector3Int(Mathf.Abs(vector.x), Mathf.Abs(vector.y), Mathf.Abs(vector.z));
        }

        /// <summary>
        /// Returns a new Vector3Int with the x component replaced.
        /// </summary>
        /// <param name="vector">The source Vector3Int.</param>
        /// <param name="x">The new x value.</param>
        /// <returns>A Vector3Int with the specified x value.</returns>
        public static Vector3Int SetX(this Vector3Int vector, int x)
        {
            return new Vector3Int(x, vector.y, vector.z);
        }

        /// <summary>
        /// Returns a new Vector3Int with the y component replaced.
        /// </summary>
        /// <param name="vector">The source Vector3Int.</param>
        /// <param name="y">The new y value.</param>
        /// <returns>A Vector3Int with the specified y value.</returns>
        public static Vector3Int SetY(this Vector3Int vector, int y)
        {
            return new Vector3Int(vector.x, y, vector.z);
        }
        
        /// <summary>
        /// Returns a new Vector3Int with the z component replaced.
        /// </summary>
        /// <param name="vector">The source Vector3Int.</param>
        /// <param name="z">The new z value.</param>
        /// <returns>A Vector3Int with the specified z value.</returns>
        public static Vector3Int SetZ(this Vector3Int vector, int z)
        {
            return new Vector3Int(vector.x, vector.y, z);
        }

        /// <summary>Returns a Vector2Int with both components set to x.</summary>
        public static Vector2Int XX(this Vector3Int vector) => new(vector.x, vector.x);
        
        /// <summary>Returns a Vector2Int with x and y components.</summary>
        public static Vector2Int XY(this Vector3Int vector) => new(vector.x, vector.y);
        
        /// <summary>Returns a Vector2Int with x and z components.</summary>
        public static Vector2Int XZ(this Vector3Int vector) => new(vector.x, vector.z);
        
        /// <summary>Returns a Vector2Int with y and x components.</summary>
        public static Vector2Int YX(this Vector3Int vector) => new(vector.y, vector.x);
        
        /// <summary>Returns a Vector2Int with both components set to y.</summary>
        public static Vector2Int YY(this Vector3Int vector) => new(vector.y, vector.y);
        
        /// <summary>Returns a Vector2Int with y and z components.</summary>
        public static Vector2Int YZ(this Vector3Int vector) => new(vector.y, vector.z);
        
        /// <summary>Returns a Vector2Int with z and x components.</summary>
        public static Vector2Int ZX(this Vector3Int vector) => new(vector.z, vector.x);
        
        /// <summary>Returns a Vector2Int with z and y components.</summary>
        public static Vector2Int ZY(this Vector3Int vector) => new(vector.z, vector.y);
        
        /// <summary>Returns a Vector2Int with both components set to z.</summary>
        public static Vector2Int ZZ(this Vector3Int vector) => new(vector.z, vector.z);
    }
}
