/*
 * Valuable world space conversion methods
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DreamEscape.Utilities {
    public static class WorldPositionConversions {

        private const float m_dumper = 2f; // arbitrary value to divide with

        /// <summary>
        /// Converts screen position to 3D coordinates
        /// </summary>
        public static Vector3 Conv2DTo3DWithDepth(Vector2 pos) {
            return new Vector3(pos.x, pos.y, pos.y / m_dumper);
        }

        /// <summary>
        /// Converts screen position to 3D coordinates
        /// </summary>
        public static Vector3 Conv2DTo3DWithDepth(float x, float y) {
            return new Vector3(x, y, y / m_dumper);
        }

    }
}

