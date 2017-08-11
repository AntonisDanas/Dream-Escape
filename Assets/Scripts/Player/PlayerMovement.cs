/*
 * Player movement script
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DreamEscape.Characters {
    public class PlayerMovement : MonoBehaviour {

        [SerializeField] private float m_destinationMargin = 0.1f;
        [SerializeField] private float m_speed = 1.0F; 
        // For Lerp 
        private float m_startTime;
        private float m_journeyLength;
        private Vector3 m_currentDestination;
        private Vector3 m_currentStart;
        private InteractableObject m_currentInteractableObject;

        void Start() {
            m_currentDestination = transform.position;
            m_currentStart = transform.position;
            m_journeyLength = 0f;
            m_currentInteractableObject = null;
        }

        void Update() {

            CheckDistanceToDestination();

            CheckInteractionWithObject();

        }

        /// <summary>
        /// Set target for the player to move
        /// </summary>
        public void MovePlayerToPosition(Vector3 pos) {
            m_currentStart = transform.position;
            m_currentDestination = pos;
            m_startTime = Time.time;
            m_journeyLength = Vector3.Distance(m_currentStart, m_currentDestination);
        }

        /// <summary>
        /// Set object for the player to interact with
        /// </summary>
        public void MovePlayerToInteract(InteractableObject obj) {
            m_currentStart = transform.position;
            m_currentDestination = obj.GetInteractionCenter();
            m_startTime = Time.time;
            m_journeyLength = Vector3.Distance(m_currentStart, m_currentDestination);
            m_currentInteractableObject = obj;
        }

        /// <summary>
        /// Checks distance from player to destination
        /// </summary>
        private void CheckDistanceToDestination() {
            if (Vector3.Distance(transform.position, m_currentDestination) > m_destinationMargin) {
                float distCovered = (Time.time - m_startTime) * m_speed;
                float fracJourney = distCovered / m_journeyLength;
                transform.position = Vector3.Lerp(m_currentStart, m_currentDestination, fracJourney);
            }
        }

        /// <summary>
        /// Checks distance from player to interactable interaction center
        /// </summary>
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

