using System.Collections.Generic;
using JamJam.Runtime.Bar;
using UnityEngine;

namespace JamJam.Runtime.Player {
    public class Drink : MonoBehaviour {
        public GameObject drinkObject;
        
        private DrinkData _currentDrink;
        
        public bool HoldingDrink { get; private set; }
        
        public void GrabDrink(DrinkData data) {
            drinkObject.SetActive(true);
            _currentDrink = data;
            HoldingDrink = true;
        }

        public void PlaceGlass(DrinkHolder holder) {
            if (!HoldingDrink) return;
            
            holder.ReceiveDrink(_currentDrink);
            drinkObject.SetActive(false);
            HoldingDrink = false;
        }

        public void ThrowGlass() {
            drinkObject.SetActive(false);
            HoldingDrink = false;
            Debug.Log("Dropped drink");
        }
    }
}