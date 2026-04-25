using UnityEngine;

namespace JamJam.Runtime.Drink {
    [CreateAssetMenu(menuName = "Ingredient")]
    public class Ingredient : ScriptableObject {
        public Flavour flavour;
    }
}