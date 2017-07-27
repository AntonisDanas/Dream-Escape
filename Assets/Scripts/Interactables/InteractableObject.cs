using UnityEngine;
using DreamEscape.Extensions;
using DreamEscape.Utilities;

namespace DreamEscape {
    public abstract class InteractableObject : MonoBehaviour {

        [SerializeField] protected float m_interactionRadius;
        [SerializeField] protected Vector2 m_interactionPosOffset;

        // Use this for initialization
        protected virtual void Start() {
            transform.position = WorldPositionConversions.Conv2DTo3DWithDepth(transform.position.xy());
        }

        public abstract void Interact();

        private void OnDrawGizmos() {
            Color oldColor = Gizmos.color;
            Gizmos.color = Color.red;
            Vector3 newPos = transform.position + new Vector3(m_interactionPosOffset.x, m_interactionPosOffset.y, 0f);
            Gizmos.DrawWireSphere(newPos, m_interactionRadius);
            Gizmos.color = oldColor;
        }

        public Vector3 GetInteractionCenter() {
            Vector2 finalPos = transform.position.xy() + m_interactionPosOffset;
            return WorldPositionConversions.Conv2DTo3DWithDepth(finalPos);
            //return new Vector3(finalPos.x, finalPos.y, transform.position.z);
        }

        public float GetInteractionRadius() {
            return m_interactionRadius;
        }
    }

}