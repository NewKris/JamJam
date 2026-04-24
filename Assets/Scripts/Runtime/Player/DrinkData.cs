using System.Collections.Generic;
using JamJam.Runtime.Bar;

namespace JamJam.Runtime.Player {
    public class DrinkData {
        private readonly List<Ingredient> _ingredients = new List<Ingredient>();
        
        public int IngredientCount => _ingredients.Count;

        public void AddIngredient(Ingredient ingredient) {
            _ingredients.Add(ingredient);
        }
    }
}