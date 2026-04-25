using System;
using JamJam.Runtime.Customers;
using JamJam.Runtime.Player;
using UnityEngine;

namespace JamJam.Runtime.Drink {
    public class DrinkHand : MonoBehaviour {
        public GameObject drinkPrefab;
        public Ingredient[] ingredients;
        
        private DrinkObject _heldDrink;

        private bool HoldingDrink => _heldDrink != null;

        public void DisposeDrink() {
            if (!HoldingDrink) return;
            
            Destroy(_heldDrink.gameObject);
            _heldDrink = null;
        }
        
        public void DropDrink() {
            if (!HoldingDrink) return;
            
            _heldDrink.transform.SetParent(null);
            _heldDrink.GetComponent<Rigidbody>().isKinematic = false;
            _heldDrink = null;
        }
        
        public void SpawnNewDrink() {
            if (HoldingDrink) return;
            
            _heldDrink = Instantiate(drinkPrefab).GetComponent<DrinkObject>();
            _heldDrink.PinDrink(transform);
        }

        public void PlaceDrink(Mixer mixer) {
            if (!HoldingDrink || mixer.CurrentDrink != null) return;

            mixer.CurrentDrink = _heldDrink;
            _heldDrink.PinDrink(mixer.transform);
            _heldDrink = null;
        }

        public void PickUpDrink(Mixer mixer) {
            if (HoldingDrink || mixer.CurrentDrink == null) return;
            
            _heldDrink = mixer.CurrentDrink;
            mixer.CurrentDrink = null;
            _heldDrink.PinDrink(transform);
        }
        
        public void PickUpDrink(DrinkObject drink) {
            if (HoldingDrink) return;
            
            _heldDrink = drink;
            _heldDrink.PinDrink(transform);
        }

        public void ServeDrink(CustomerSeat seat) {
            if (!HoldingDrink) return;

            seat.ServeDrink(_heldDrink);
            _heldDrink = null;
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
    }
}