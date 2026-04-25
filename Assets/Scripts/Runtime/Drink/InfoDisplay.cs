using System;
using UnityEngine;
using UnityEngine.UI;

namespace JamJam.Runtime.Drink {
    public class InfoDisplay : MonoBehaviour {
        public DrinkObject drink;
        public Slider sweetSlider;
        public Slider sourSlider;
        public Slider saltSlider;
        public Slider bitterSlider;
        public Slider alcoholSlider;

        public void UpdateDisplay() {
            sweetSlider.value = drink.GetTotalSweetness() / (float)Flavour.MaxFlavourLevel;
            sourSlider.value = drink.GetTotalSourness() / (float)Flavour.MaxFlavourLevel;
            saltSlider.value = drink.GetTotalSaltiness() / (float)Flavour.MaxFlavourLevel;
            bitterSlider.value = drink.GetTotalBitterness() / (float)Flavour.MaxFlavourLevel;
            alcoholSlider.value = drink.GetTotalAlcohol() / (float)Flavour.MaxFlavourLevel;
        }

        private void OnEnable() {
            UpdateDisplay();
        }
    }
}