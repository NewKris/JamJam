using System;
using JamJam.Runtime.Drink;
using UnityEngine;

namespace JamJam.Runtime.Customers {
    [Serializable]
    public struct CustomerRequest {
        public DesiredFlavour desiredSweetness;
        public DesiredFlavour desiredSourness;
        public DesiredFlavour desiredSaltness;
        public DesiredFlavour desiredBitterness;
        public DesiredFlavour desiredAlcohol;
        
        public bool EvaluateFlavour(Flavour desired) {
            return desiredSweetness.Evaluate(desired.sweet)
                &&  desiredSourness.Evaluate(desired.sour)
                &&  desiredSaltness.Evaluate(desired.salt)
                &&  desiredBitterness.Evaluate(desired.bitter)
                &&  desiredAlcohol.Evaluate(desired.alcohol);
        }
    }

    [Serializable]
    public struct DesiredFlavour {
        public int level;
        public Evaluator evaluator;

        public bool Evaluate(int actualValue) {
            return evaluator switch {
                Evaluator.EQUAL => actualValue == level,
                Evaluator.GREATER_OR_EQUAL => actualValue >= level,
                Evaluator.LESS_OR_EQUAL => actualValue <= level,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }

    public enum Evaluator {
        LESS_OR_EQUAL,
        EQUAL,
        GREATER_OR_EQUAL
    }
}