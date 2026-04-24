using System;
using JamJam.Runtime.Player;
using UnityEngine;

namespace JamJam.Runtime.Interactions {
    public class InteractController : MonoBehaviour {
        public float maxInteractDistance;
        public LayerMask interactMask;

        private void Awake() {
            PlayerController.OnInteract += TryInteract;
        }

        private void OnDestroy() {
            PlayerController.OnInteract -= TryInteract;
        }

        private void TryInteract() {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            if (Physics.Raycast(ray, out RaycastHit hit, maxInteractDistance, interactMask) 
                && hit.collider.TryGetComponent(out Interactable interactable)
            ) {
                interactable.Interact();
            }
        }
    }
}