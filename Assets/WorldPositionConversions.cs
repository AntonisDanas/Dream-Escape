using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DreamEscape.Utilities {
    public static class WorldPositionConversions {

        public static Vector3 Conv2DTo3DWithDepth(Vector2 pos) {
            return new Vector3(pos.x, pos.y, pos.y / 2); // 2 is an arbitrary number
        }

        public static Vector3 Conv2DTo3DWithDepth(float x, float y) {
            return new Vector3(x, y, y / 2); // 2 is an arbitrary number
        }

    }
}

