using System;
using System.Collections.Generic;
using UnityEngine;

namespace JamJam.Runtime.Bar {
    public class Drink : MonoBehaviour {
        public GameObject drinkObject;
        public int maxIngredients;

        private Flavour _currentFlavour;
        private List<Ingredient> _ingredients;
        
        public void SpawnGlass() {
            drinkObject.SetActive(true);
        }

        public void ThrowGlass() {
            drinkObject.SetActive(false);
        }

        public void AddIngredient(Ingredient ingredient) {
            if (_ingredients.Count >= maxIngredients) return;
            
            _ingredients.Add(ingredient);
        }

        private void Awake() {
            _ingredients = new List<Ingredient>(maxIngredients);
        }
    }
}