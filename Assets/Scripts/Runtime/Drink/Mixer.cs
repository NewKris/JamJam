using System;
using JamJam.Runtime.Player;
using UnityEngine;
using UnityEngine.UI;

namespace JamJam.Runtime.Drink {
    public class Mixer : MonoBehaviour {
        public float mixSpeed;
        public Image indicator;
        
        public DrinkObject CurrentDrink { get; set; }

        private void Update() {
            if (PlayerController.HoldingMix && CurrentDrink && CurrentDrink.HasIngredients) {
                CurrentDrink.mixAmount += mixSpeed * Time.deltaTime;
                CurrentDrink.mixAmount = Mathf.Clamp01(CurrentDrink.mixAmount);
                indicator.fillAmount = CurrentDrink.mixAmount;
            }
            else {
                indicator.fillAmount = 0;
            }
        }
    }
}