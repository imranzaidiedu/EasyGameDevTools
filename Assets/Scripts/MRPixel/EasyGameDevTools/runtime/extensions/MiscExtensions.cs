using UnityEngine;

namespace MRPixel.EasyGameDevTools.Runtime.Extensions
{
    public static class MiscExtensions
    {
        /// <summary>
        /// Determines whether the specified layer is included in the LayerMask.
        /// </summary>
        /// <param name="layerMask">The LayerMask to check.</param>
        /// <param name="layer">The layer to test for inclusion.</param>
        /// <returns>True if the layer is included in the LayerMask; otherwise, false.</returns>
        public static bool Includes(this LayerMask layerMask, int layer) => (layerMask.value & (1 << layer)) != 0;
    }
}
