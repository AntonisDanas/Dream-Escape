using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DreamEscape.Characters;
using DreamEscape.Utilities;

public class InputWrapper : MonoBehaviour {

    //TODO make singleton

    private PlayerMovement m_characterMovement;
    // INSPECTOR PROPERTIES RENDERED BY CUSTOM EDITOR SCRIPT
    [SerializeField] private int[] layerPriorities;

    private float maxRaycastDepth = 100f; // Hard coded value

    // Use this for initialization
    void Start () {
        m_characterMovement = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update () {
        Ray ray = new Ray();
#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetMouseButtonDown(0)) {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            ResolveClick(ray);
        }
#elif UNITY_ANDROID
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            ResolveClick(ray);
        }        
#endif

    }

    void ResolveClick(Ray ray) {
        RaycastHit2D[] raycastHits = Physics2D.RaycastAll(ray.origin,ray.direction,maxRaycastDepth);

        RaycastHit2D? priorityHit = FindTopPriorityHit(raycastHits);

        if (priorityHit.HasValue) {
            var objectHit = priorityHit.Value.collider.gameObject;

            switch (LayerMask.LayerToName(objectHit.layer)) {
                case "Interactables":

                    break;
                case "Walkable":
                    Vector3 newPos = WorldPositionConversions.Conv2DTo3DWithDepth(ray.origin.x, ray.origin.y);
                    m_characterMovement.MovePlayerToPosition(newPos);
                    print(newPos);
                    break;
                default:
                    return;
            }
            
        }
        print("hit");
    }

    RaycastHit2D? FindTopPriorityHit(RaycastHit2D[] raycastHits) {
        // Form list of layer numbers hit
        List<int> layersOfHitColliders = new List<int>();
        foreach (RaycastHit2D hit in raycastHits) {
            layersOfHitColliders.Add(hit.collider.gameObject.layer);
        }

        // Step through layers in order of priority looking for a gameobject with that layer
        foreach (int layer in layerPriorities) {
            foreach (RaycastHit2D hit in raycastHits) {
                if (hit.collider.gameObject.layer == layer) {
                    return hit; // stop looking
                }
            }
        }
        return null; // because cannot use GameObject? nullable
    }
}
