using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DreamEscape.Extensions {
    public static class Vector3Extension {

        public static Vector2 xy(this Vector3 vec) {
            return new Vector2(vec.x, vec.y);
        }

        public static Vector2 xz(this Vector3 vec) {
            return new Vector2(vec.x, vec.z);
        }

        public static Vector2 yz(this Vector3 vec) {
            return new Vector2(vec.y, vec.z);
        }

    } 
}
