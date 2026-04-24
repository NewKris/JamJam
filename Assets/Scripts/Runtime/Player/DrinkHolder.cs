using System;
using UnityEngine;

namespace JamJam.Runtime.Player {
    public class DrinkHolder : MonoBehaviour {
        public bool canTakeDrinkFrom = true;
        public GameObject proxy;
        
        public DrinkData HeldDrink { get; private set; }
        public bool HasDrink => HeldDrink != null;
        
        public void ReceiveDrink(DrinkData drink) {
            HeldDrink = drink;
            proxy.SetActive(true);
        }
        
        public void RemoveDrink() {
            HeldDrink = null;
            proxy.SetActive(false);
        }

        private void Awake() {
            proxy.SetActive(false);
        }
    }
}