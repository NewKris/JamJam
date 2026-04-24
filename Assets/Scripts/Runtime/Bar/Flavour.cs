using System;
using UnityEngine;

namespace JamJam.Runtime.Bar {
    [Serializable]
    public struct Flavour {
        public float sweet;
        public float sour;
        public float salt;
        public float bitter;
        public float alcohol;
        
        [Header("Booleans")]
        public bool isPoison;
        public bool isBeer;

        public static bool EvaluateFlavour(Flavour desired, Flavour actual) {
            return true;
        }
    }
}