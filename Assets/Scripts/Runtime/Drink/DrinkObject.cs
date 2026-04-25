using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace JamJam.Runtime.Drink {
    public class DrinkObject : MonoBehaviour {
        public List<Ingredient> ingredients;
        public float mixAmount;
        public int maxIngredients = 5;
        public FlavourInfoDisplay drinkInfo;

        public void SetInfoPanelActive(bool isActive) {
            drinkInfo.gameObject.SetActive(isActive);
            drinkInfo.UpdateDisplay(SumFlavours());
        }
        
        public void AddIngredient(Ingredient ingredient) {
            if (ingredients.Count >= maxIngredients) return;
            
            Debug.Log($"Added ingredient: {ingredient.name}");
            ingredients.Add(ingredient);
            drinkInfo.UpdateDisplay(SumFlavours());
        }
        
        public void PinDrink(Transform target) {
            Rigidbody rb = GetComponent<Rigidbody>();
            
            transform.SetParent(target);
            transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            rb.position = transform.position;
            rb.rotation = transform.rotation;
            rb.isKinematic = true;
        }

        private Flavour SumFlavours() {
            return new Flavour() {
                sweet = GetTotalSweetness(),
                sour = GetTotalSourness(),
                salt = GetTotalSaltiness(),
                bitter = GetTotalBitterness(),
                alcohol = GetTotalAlcohol()
            };
        }

        private int GetTotalSweetness() {
            return ingredients.Select(x => x.flavour.sweet).Sum();
        }
        
        private int GetTotalSourness() {
            return ingredients.Select(x => x.flavour.sour).Sum();
        }
        
        private int GetTotalSaltiness() {
            return ingredients.Select(x => x.flavour.salt).Sum();
        }
        
        private int GetTotalBitterness() {
            return ingredients.Select(x => x.flavour.bitter).Sum();
        }
        
        private int GetTotalAlcohol() {
            return ingredients.Select(x => x.flavour.alcohol).Sum();
        }

        private void Start() {
            mixAmount = 0;
        }
    }
}