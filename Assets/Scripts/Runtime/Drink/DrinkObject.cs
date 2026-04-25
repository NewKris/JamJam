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
        
        public void PinDrink(Transform target) {
            Rigidbody rb = GetComponent<Rigidbody>();
            
            transform.SetParent(target);
            transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            rb.position = transform.position;
            rb.rotation = transform.rotation;
            rb.isKinematic = true;
        }
    }
}