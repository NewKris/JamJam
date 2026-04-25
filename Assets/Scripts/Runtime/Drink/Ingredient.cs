using UnityEngine;

namespace JamJam.Runtime.Drink {
    [CreateAssetMenu(menuName = "Ingredient")]
    public class Ingredient : ScriptableObject {
        public bool isPoisonous;
        public int ingredientVolume = 1;
        public Flavour flavour;

        [Header("Info")] 
        public string displayName;
        [TextArea] public string description;
        public Sprite icon;
        public string keyBind;
    }
}