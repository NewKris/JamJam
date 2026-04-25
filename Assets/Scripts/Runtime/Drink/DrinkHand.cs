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
            ReleaseDrink();
        }
        
        public void DropDrink() {
            if (!HoldingDrink) return;
            
            _heldDrink.transform.SetParent(null);
            _heldDrink.GetComponent<Rigidbody>().isKinematic = false;
            ReleaseDrink();
            SatisfactionManager.DecreaseSatisfaction(25);
        }
        
        public void SpawnNewDrink() {
            if (HoldingDrink) return;
            
            HoldDrink(Instantiate(drinkPrefab).GetComponent<DrinkObject>());
            _heldDrink.PinDrink(transform);
        }

        public void PlaceDrink(Mixer mixer) {
            if (!HoldingDrink || mixer.CurrentDrink != null) return;

            mixer.CurrentDrink = _heldDrink;
            _heldDrink.PinDrink(mixer.transform);
            ReleaseDrink();
        }

        public void PickUpDrink(Mixer mixer) {
            if (HoldingDrink || mixer.CurrentDrink == null) return;
            
            HoldDrink(mixer.CurrentDrink);
            mixer.CurrentDrink = null;
            _heldDrink.PinDrink(transform);
        }
        
        public void PickUpDrink(DrinkObject drink) {
            if (HoldingDrink) return;
            
            HoldDrink(drink);
            _heldDrink.PinDrink(transform);
        }

        public void ServeDrink(CustomerSeat seat) {
            if (!HoldingDrink) return;

            seat.ServeDrink(_heldDrink);
            ReleaseDrink();
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

        private void HoldDrink(DrinkObject drink) {
            _heldDrink = drink;
            _heldDrink.SetInfoPanelActive(true);
        }

        private void ReleaseDrink() {
            _heldDrink.SetInfoPanelActive(false);
            _heldDrink = null;
        }
    }
}