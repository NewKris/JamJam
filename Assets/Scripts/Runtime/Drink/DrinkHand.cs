using System;
using JamJam.Runtime.Player;
using UnityEngine;

namespace JamJam.Runtime.Drink {
    public class DrinkHand : MonoBehaviour {
        public GameObject drinkPrefab;
        public Ingredient[] ingredients;
        
        private DrinkObject _heldDrink;

        private bool HoldingDrink => _heldDrink != null;
        
        public void DropDrink() {
            if (!HoldingDrink) return;
            
            _heldDrink.transform.SetParent(null);
            _heldDrink.GetComponent<Rigidbody>().isKinematic = false;
            _heldDrink = null;
        }
        
        public void SpawnNewDrink() {
            if (HoldingDrink) return;
            
            _heldDrink = Instantiate(drinkPrefab).GetComponent<DrinkObject>();
            PinDrink();
        }

        public void PickUpDrink(DrinkObject drink) {
            if (HoldingDrink) return;
            
            _heldDrink = drink;
            PinDrink();
        }

        private void Awake() {
            PlayerController.OnAddIngredient += AddIngredient;
        }

        private void OnDestroy() {
            PlayerController.OnAddIngredient -= AddIngredient;
        }

        private void AddIngredient(int ingredientIndex) {
            if (!HoldingDrink) return;
            
            _heldDrink.AddIngredient(ingredients[ingredientIndex]);
        }

        private void PinDrink() {
            Rigidbody rb = _heldDrink.GetComponent<Rigidbody>();
            
            _heldDrink.transform.SetParent(transform);
            _heldDrink.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            rb.position = _heldDrink.transform.position;
            rb.rotation = _heldDrink.transform.rotation;
            rb.isKinematic = true;
        }
    }
}