using System;
using UnityEngine;
using UnityEngine.UI;

namespace JamJam.Runtime.Drink {
    public class FlavourInfoDisplay : MonoBehaviour {
        public Slider sweetSlider;
        public Slider sourSlider;
        public Slider saltSlider;
        public Slider bitterSlider;
        public Slider alcoholSlider;

        public void UpdateDisplay(Flavour flavour) {
            sweetSlider.value = flavour.sweet / (float)Flavour.MaxFlavourLevel;
            sourSlider.value = flavour.sour / (float)Flavour.MaxFlavourLevel;
            saltSlider.value = flavour.salt / (float)Flavour.MaxFlavourLevel;
            bitterSlider.value = flavour.bitter / (float)Flavour.MaxFlavourLevel;
            alcoholSlider.value =flavour.alcohol / (float)Flavour.MaxFlavourLevel;
        }
    }
}