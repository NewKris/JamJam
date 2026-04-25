using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace JamJam.Runtime.Drink {
    public class DrinkObject : MonoBehaviour {
        public List<Ingredient> ingredients;
        public bool containsPoison;
        public float mixAmount;
        public int maxIngredients = 5;
        public GameObject infoPanel;
        public UnityEvent onIngredientAdded;

        public void SetInfoPanelActive(bool isActive) {
            infoPanel.SetActive(isActive);
        }
        
        public void AddIngredient(Ingredient ingredient) {
            if (ingredients.Count >= maxIngredients) return;
            
            Debug.Log($"Added ingredient: {ingredient.name}");
            ingredients.Add(ingredient);
            onIngredientAdded.Invoke();
        }
        
        public void PinDrink(Transform target) {
            Rigidbody rb = GetComponent<Rigidbody>();
            
            transform.SetParent(target);
            transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            rb.position = transform.position;
            rb.rotation = transform.rotation;
            rb.isKinematic = true;
        }

        public int GetTotalSweetness() {
            return ingredients.Select(x => x.flavour.sweet).Sum();
        }
        
        public int GetTotalSourness() {
            return ingredients.Select(x => x.flavour.sour).Sum();
        }
        
        public int GetTotalSaltiness() {
            return ingredients.Select(x => x.flavour.salt).Sum();
        }
        
        public int GetTotalBitterness() {
            return ingredients.Select(x => x.flavour.bitter).Sum();
        }
        
        public int GetTotalAlcohol() {
            return ingredients.Select(x => x.flavour.alcohol).Sum();
        }

        private void Start() {
            mixAmount = 0;
        }
    }
}