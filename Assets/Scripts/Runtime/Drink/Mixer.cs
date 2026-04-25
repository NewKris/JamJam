using System;
using JamJam.Runtime.Player;
using UnityEngine;

namespace JamJam.Runtime.Drink {
    public class Mixer : MonoBehaviour {
        public float mixSpeed;
        
        public DrinkObject CurrentDrink { get; set; }

        private void Update() {
            if (PlayerController.HoldingMix && CurrentDrink) {
                CurrentDrink.mixAmount += mixSpeed * Time.deltaTime;
                CurrentDrink.mixAmount = Mathf.Clamp01(CurrentDrink.mixAmount);
            }
        }
    }
}