using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace JamJam.Runtime.Drink {
    public class IngredientInfoController : MonoBehaviour {
        public LayerMask ingredientInfoLayer;
        public IngredientInfoDisplay infoDisplay;

        private IngredientInfoSource _lookingAtSource;
        
        private void Update() {
            if (TryInteract(out _lookingAtSource)) {
                infoDisplay.ShowInfo(_lookingAtSource.ingredient);
                infoDisplay.gameObject.SetActive(true);
            }
            else {
                infoDisplay.gameObject.SetActive(false);
            }
        }
        
        private bool TryInteract<T>(out T interactable) where T : Object {
            bool hitInteraction = Physics.Raycast(GetCameraRay(), out RaycastHit hit, 10, ingredientInfoLayer);

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