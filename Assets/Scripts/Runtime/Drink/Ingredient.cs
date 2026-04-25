using UnityEngine;

namespace JamJam.Runtime.Drink {
    [CreateAssetMenu(menuName = "Ingredient")]
    public class Ingredient : ScriptableObject {
        public Flavour flavour;

        [Header("Info")] 
        public string displayName;
        [TextArea] public string description;
        public Sprite icon;
    }
}