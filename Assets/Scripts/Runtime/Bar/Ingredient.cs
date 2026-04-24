using UnityEngine;

namespace JamJam.Runtime.Bar {
    [CreateAssetMenu(menuName = "Ingredient")]
    public class Ingredient : ScriptableObject {
        public Flavour flavour;
    }
}