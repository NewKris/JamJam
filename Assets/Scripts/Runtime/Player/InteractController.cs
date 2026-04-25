using System;
using JamJam.Runtime.Drink;
using UnityEngine;
using Object = UnityEngine.Object;

namespace JamJam.Runtime.Player {
    public class InteractController : MonoBehaviour {
        public float maxInteractDistance;
        public LayerMask interactMask;
        public DrinkHand drinkHand;

        private void Awake() {
            PlayerController.OnGrab += TryGrab;
            PlayerController.OnRelease += TryRelease;
        }

        private void OnDestroy() {
            PlayerController.OnGrab -= TryGrab;
            PlayerController.OnRelease -= TryRelease;
        }

        private void TryGrab() {
            if (TryInteract(out GrabInteractable grabInteractable)) {
                grabInteractable.Grab();
            } else if (TryInteract(out DrinkObject drinkObject)) {
                drinkHand.PickUpDrink(drinkObject);
            }
        }

        private void TryRelease() {
            if (TryInteract(out ReleaseInteractable releaseInteractable)) {
                releaseInteractable.Release();
            }
            else {
                drinkHand.DropDrink();
            }
        }

        private bool TryInteract<T>(out T interactable) where T : Object {
            bool hitInteraction = Physics.Raycast(GetCameraRay(), out RaycastHit hit, maxInteractDistance, interactMask);

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