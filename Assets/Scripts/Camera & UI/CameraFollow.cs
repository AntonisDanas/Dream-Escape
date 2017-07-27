using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DreamEscape {
    public class CameraFollow : MonoBehaviour {

        public Transform target;

        [SerializeField] private float m_topBorder = 1f;
        [SerializeField] private float m_bottomBorder = 1f;
        [SerializeField] private float m_leftBorder = 1f;
        [SerializeField] private float m_rightBorder = 1f;

        // Use this for initialization
        void Start() {
            transform.position = new Vector3(target.position.x,
                                            target.position.y,
                                            transform.position.z)  ;
        }

        // Update is called once per frame
        void LateUpdate() {
            transform.position = CorrectCameraPosition();
        }

        private void OnDrawGizmos() {
            Color oldColor = Gizmos.color;

            Gizmos.color = Color.green;
            Gizmos.DrawLine(new Vector3(m_leftBorder, m_topBorder, 0f),
                            new Vector3(m_rightBorder, m_topBorder, 0f));
            Gizmos.DrawLine(new Vector3(m_leftBorder, m_bottomBorder, 0f),
                            new Vector3(m_rightBorder, m_bottomBorder, 0f));

            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(new Vector3(m_leftBorder, m_topBorder, 0f),
                            new Vector3(m_leftBorder, m_bottomBorder, 0f));
            Gizmos.DrawLine(new Vector3(m_rightBorder, m_topBorder, 0f),
                            new Vector3(m_rightBorder, m_bottomBorder, 0f));

            Gizmos.color = oldColor;
        }

        private Vector3 CorrectCameraPosition() {

            float vertSize = Camera.main.orthographicSize;
            float horSize = vertSize * Camera.main.aspect;

            float newXPos = target.position.x + horSize >= m_rightBorder ||
                            target.position.x - horSize <= m_leftBorder ?
                            transform.position.x : target.position.x;

            float newYPos = target.position.y + vertSize >= m_topBorder ||
                            target.position.y - vertSize <= m_bottomBorder ?
                            transform.position.y : target.position.y;

            return new Vector3(newXPos, newYPos, transform.position.z);
        }
    } 
}
