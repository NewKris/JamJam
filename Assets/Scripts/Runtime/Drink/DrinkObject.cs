using System;
using System.Collections.Generic;
using System.Linq;
using JamJam.Runtime.Player;
using JamJam.Runtime.Utility.Attributes;
using UnityEngine;
using UnityEngine.Events;

namespace JamJam.Runtime.Drink {
    public class DrinkObject : MonoBehaviour {
        public List<Ingredient> ingredients;
        public int maxIngredients = 5;
        public FlavourInfoDisplay drinkInfo;
        public int satisfactionLoss = 25;
        
        [Header("Read Only")]
        [ReadOnly] public float mixAmount;
        [ReadOnly] public bool isPoisonous;

        private int _capacity = 0;
        private Color _drinkColor;
        
        public bool HasIngredients => ingredients.Count > 0;

        public void Break() {
            Debug.Log("!");
            SatisfactionManager.DecreaseSatisfaction(satisfactionLoss);
            Destroy(gameObject);
        }
        
        public void SetInfoPanelActive(bool isActive) {
            drinkInfo.gameObject.SetActive(isActive);
            drinkInfo.UpdateDisplay(SumFlavours());
        }
        
        public void AddIngredient(Ingredient ingredient) {
            if (ingredient.ingredientVolume > 0 && _capacity >= maxIngredients) return;

            Debug.Log($"Added ingredient: {ingredient.name}");
            isPoisonous = isPoisonous || ingredient.flavour.isPoison;
            _capacity += ingredient.ingredientVolume;
            ingredients.Add(ingredient);
            drinkInfo.UpdateDisplay(SumFlavours());
            UpdateColor();
        }
        
        public void PinDrink(Transform target) {
            Rigidbody rb = GetComponent<Rigidbody>();
            
            transform.SetParent(target);
            transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            rb.position = transform.position;
            rb.rotation = transform.rotation;
            rb.isKinematic = true;
        }

        public Flavour SumFlavours() {
            return new Flavour() {
                sweet = GetTotalSweetness(),
                sour = GetTotalSourness(),
                salt = GetTotalSaltiness(),
                bitter = GetTotalBitterness(),
                alcohol = GetTotalAlcohol(),
                isBeer = IsBeer()
            };
        }

        private void UpdateColor() {
            var freq = ingredients.GroupBy(x => x)
                .OrderByDescending(x => x.Count())
                .Select(x => x.Key)
                .ToList();

            _drinkColor = freq.First().ingredientColor;
        }
        
        private bool IsBeer() {
            return ingredients.Any(x => x.flavour.isBeer);
        }
        
        private int GetTotalSweetness() {
            return Math.Clamp(ingredients.Select(x => x.flavour.sweet).Sum(), 0, Flavour.MaxFlavourLevel);
        }
        
        private int GetTotalSourness() {
            return Math.Clamp(ingredients.Select(x => x.flavour.sour).Sum(), 0, Flavour.MaxFlavourLevel);
        }
        
        private int GetTotalSaltiness() {
            return Math.Clamp(ingredients.Select(x => x.flavour.salt).Sum(), 0, Flavour.MaxFlavourLevel);
        }
        
        private int GetTotalBitterness() {
            return Math.Clamp(ingredients.Select(x => x.flavour.bitter).Sum(), 0, Flavour.MaxFlavourLevel);
        }
        
        private int GetTotalAlcohol() {
            return Math.Clamp(ingredients.Select(x => x.flavour.alcohol).Sum(), 0, Flavour.MaxFlavourLevel);
        }

        private void Start() {
            mixAmount = 0;
        }
    }
}