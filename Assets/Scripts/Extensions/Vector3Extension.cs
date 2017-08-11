/*
 * Custom extensions for Vector3 class
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DreamEscape.Extensions {
    public static class Vector3Extension {
        
        /// <summary>
        /// Returns x and y coordinates of vector
        /// </summary>
        public static Vector2 xy(this Vector3 vec) {
            return new Vector2(vec.x, vec.y);
        }

        /// <summary>
        /// Returns x and z coordinates of vector
        /// </summary>
        public static Vector2 xz(this Vector3 vec) {
            return new Vector2(vec.x, vec.z);
        }

        /// <summary>
        /// Returns y and z coordinates of vector
        /// </summary>
        public static Vector2 yz(this Vector3 vec) {
            return new Vector2(vec.y, vec.z);
        }

    } 
}
