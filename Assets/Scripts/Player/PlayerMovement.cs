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
        private InteractableObject m_currentInteractableObject;

        // Use this for initialization
        void Start() {
            m_currentDestination = transform.position;
            m_currentStart = transform.position;
            m_journeyLength = 0f;
            m_currentInteractableObject = null;
        }

        // Update is called once per frame
        void Update() {

            CheckDistanceToDestination();

            CheckInteractionWithObject();

        }

        public void MovePlayerToPosition(Vector3 pos) {
            m_currentStart = transform.position;
            m_currentDestination = pos;
            m_startTime = Time.time;
            m_journeyLength = Vector3.Distance(m_currentStart, m_currentDestination);
        }

        public void MovePlayerToInteract(InteractableObject obj) {
            m_currentStart = transform.position;
            m_currentDestination = obj.GetInteractionCenter();
            m_startTime = Time.time;
            m_journeyLength = Vector3.Distance(m_currentStart, m_currentDestination);
            m_currentInteractableObject = obj;
        }

        private void CheckDistanceToDestination() {
            if (Vector3.Distance(transform.position, m_currentDestination) > m_destinationMargin) {
                float distCovered = (Time.time - m_startTime) * m_speed;
                float fracJourney = distCovered / m_journeyLength;
                transform.position = Vector3.Lerp(m_currentStart, m_currentDestination, fracJourney);
            }
        }

        private void CheckInteractionWithObject() {
            if (m_currentInteractableObject &&
                    Vector3.Distance(transform.position, m_currentDestination) <
                        m_currentInteractableObject.GetInteractionRadius()) {
                m_currentInteractableObject.Interact();
                m_currentInteractableObject = null;
                m_currentDestination = transform.position;
            }
        }
    }
}

