using System;
using JamJam.Runtime.Bar;
using UnityEngine;

namespace JamJam.Runtime.Player {
    public class InteractController : MonoBehaviour {
        public float maxInteractDistance;
        public LayerMask interactMask;
        public Drink drink;

        private void Awake() {
            PlayerController.OnGrab += TryGrab;
            PlayerController.OnRelease += TryRelease;
        }

        private void OnDestroy() {
            PlayerController.OnGrab -= TryGrab;
            PlayerController.OnRelease -= TryRelease;
        }

        private void TryGrab() {
            if (drink.HoldingDrink) return;
            
            if (Physics.Raycast(GetRay(), out RaycastHit hit, maxInteractDistance, interactMask)) {
                if (hit.collider.TryGetComponent(out DrinkSource _)) {
                    drink.GrabDrink(new DrinkData());
                } else if (hit.collider.TryGetComponent(out DrinkHolder holder) 
                           && holder.HasDrink
                ) {
                    drink.GrabDrink(holder.HeldDrink);
                    holder.RemoveDrink();
                }
            }
        }

        private void TryRelease() {
            if (!drink.HoldingDrink) return;
            
            if (Physics.Raycast(GetRay(), out RaycastHit hit, maxInteractDistance, interactMask)
                && hit.collider.TryGetComponent(out DrinkHolder receiver)
                && !receiver.HasDrink
            ) {
                drink.PlaceGlass(receiver);
            }
            else {
                drink.ThrowGlass();
            }
        }

        private Ray GetRay() {
            return Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        }
    }
}