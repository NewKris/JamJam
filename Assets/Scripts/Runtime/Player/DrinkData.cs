using System.Collections.Generic;
using JamJam.Runtime.Bar;

namespace JamJam.Runtime.Player {
    public class DrinkData {
        private readonly List<Ingredient> _ingredients = new List<Ingredient>();
        
        public void AddIngredient(Ingredient ingredient) {
            if (_ingredients.Count >= 5) return;
            
            _ingredients.Add(ingredient);
        }
    }
}