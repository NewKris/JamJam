using TMPro;
using UnityEngine;

namespace JamJam.Runtime.Drink {
    public class IngredientInfoDisplay : MonoBehaviour {
        public TextMeshProUGUI displayName;
        public TextMeshProUGUI description;
        public TextMeshProUGUI keyBind;
        public FlavourInfoDisplay flavourInfo;
        
        private Ingredient _currentIngredient;
        
        public void ShowInfo(Ingredient ingredient) {
            if (_currentIngredient == ingredient) return;
            
            _currentIngredient = ingredient;
            displayName.text = ingredient.displayName;
            description.text = ingredient.description;
            keyBind.text = $"[{ingredient.keyBind}]";
            flavourInfo.UpdateDisplay(ingredient.flavour);
        }
    }
}