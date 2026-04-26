using System;
using JamJam.Runtime.Audio;
using JamJam.Runtime.Customers;
using JamJam.Runtime.Player;
using UnityEngine;

namespace JamJam.Runtime.Drink {
    public class DrinkHand : MonoBehaviour {
        public GameObject drinkPrefab;
        public IngredientDatabase ingredients;
        
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
        }
        
        public void SpawnNewDrink() {
            if (HoldingDrink) return;
            
            HoldDrink(Instantiate(drinkPrefab, transform.position, transform.rotation).GetComponent<DrinkObject>());
            _heldDrink.PinDrink(transform);
            SfxSystem.PlayPickUp();
        }

        public void PlaceDrink(Mixer mixer) {
            if (!HoldingDrink || mixer.CurrentDrink != null) return;

            mixer.CurrentDrink = _heldDrink;
            _heldDrink.PinDrink(mixer.glassPivot);
            ReleaseDrink();
            SfxSystem.PlayPlaceDown();
        }

        public void PickUpDrink(Mixer mixer) {
            if (HoldingDrink || mixer.CurrentDrink == null) return;
            
            HoldDrink(mixer.CurrentDrink);
            mixer.CurrentDrink = null;
            _heldDrink.PinDrink(transform);
            SfxSystem.PlayPickUp();
        }
        
        public void PickUpDrink(DrinkObject drink) {
            if (HoldingDrink) return;
            
            HoldDrink(drink);
            _heldDrink.PinDrink(transform);
            SfxSystem.PlayPickUp();
        }

        public void ServeDrink(CustomerSeat seat) {
            if (!HoldingDrink) return;

            seat.ServeDrink(_heldDrink);
            ReleaseDrink();
            SfxSystem.PlayPlaceDown();
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