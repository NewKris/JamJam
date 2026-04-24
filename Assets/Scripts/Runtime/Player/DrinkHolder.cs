using System;
using UnityEngine;
using UnityEngine.Events;

namespace JamJam.Runtime.Player {
    public class DrinkHolder : MonoBehaviour {
        public UnityEvent onReceiveDrink;
        public UnityEvent onRemoveDrink;
        
        public DrinkData HeldDrink { get; private set; }
        public bool HasDrink => HeldDrink != null;
        
        public void ReceiveDrink(DrinkData drink) {
            HeldDrink = drink;
            onReceiveDrink.Invoke();
        }
        
        public void RemoveDrink() {
            HeldDrink = null;
            onRemoveDrink.Invoke();
        }
    }
}