using UnityEngine;

namespace JamJam.Runtime.Drink {
    [CreateAssetMenu(menuName = "Ingredient Database")]
    public class IngredientDatabase : ScriptableObject {
        public Ingredient[] ingredients;
        
        public Ingredient this[int i] => ingredients[i];
    }
}