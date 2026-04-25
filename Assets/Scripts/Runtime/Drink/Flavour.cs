using System;
using UnityEngine;

namespace JamJam.Runtime.Drink {
    [Serializable]
    public struct Flavour {
        public const int MaxFlavourLevel = 5;
        
        public int sweet;
        public int sour;
        public int salt;
        public int bitter;
        public int alcohol;
        
        [Header("Booleans")]
        public bool isPoison;
        public bool isBeer;

        public static bool EvaluateFlavour(Flavour desired, Flavour actual) {
            return true;
        }
    }
}