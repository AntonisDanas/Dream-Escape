using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DreamEscape.Characters {
    public class PlayerMovement : MonoBehaviour {

        [SerializeField] private float m_destinationMargin = 0.1f;
        [SerializeField] private float m_speed = 1.0F;
        private float m_startTime;
        private float m_journeyLength;
        private Vector3 m_currentDestination;
        private Vector3 m_currentStart;

        // Use this for initialization
        void Start() {
            m_currentDestination = transform.position;
            m_currentStart = transform.position;
            m_journeyLength = 0f;
        }

        // Update is called once per frame
        void Update() {
            if (Vector3.Distance(m_currentStart, m_currentDestination) > m_destinationMargin) {
                float distCovered = (Time.time - m_startTime) * m_speed;
                float fracJourney = distCovered / m_journeyLength;
                transform.position = Vector3.Lerp(m_currentStart, m_currentDestination, fracJourney);
            }           
        }

        public void MovePlayerToPosition(Vector3 pos) {
            //m_currentDestination = xPosition;
            m_currentStart = transform.position;
            m_currentDestination = pos;
            m_startTime = Time.time;
            m_journeyLength = Vector3.Distance(m_currentStart, m_currentDestination);
        }
    }
}

