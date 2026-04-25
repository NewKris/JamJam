using System.Collections.Generic;
using UnityEngine;

namespace JamJam.Runtime.Drink {
    public class DrinkObject : MonoBehaviour {
        public List<Ingredient> ingredients;
        public bool containsPoison;
        public int maxIngredients = 5;
        
        public void AddIngredient(Ingredient ingredient) {
            if (ingredients.Count >= maxIngredients) return;
            
            Debug.Log($"Added ingredient: {ingredient.name}");
            ingredients.Add(ingredient);
        }
    }
}