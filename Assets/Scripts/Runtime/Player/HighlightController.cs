using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace JamJam.Runtime.Player {
    public class HighlightController : MonoBehaviour {
        public LayerMask highlightLayer;

        private void Update() {
            if (TryInteract(out HighlightInteractable interactable)) {
                interactable.LookingAt = true;
            }
        }
        
        private bool TryInteract<T>(out T interactable) where T : Object {
            bool hitInteraction = Physics.Raycast(GetCameraRay(), out RaycastHit hit, 10, highlightLayer);

            if (!hitInteraction) {
                interactable = null;
                return false;
            }
            
            return hit.collider.TryGetComponent(out interactable);
        }
        
        private Ray GetCameraRay() {
            return Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        }
    }
}