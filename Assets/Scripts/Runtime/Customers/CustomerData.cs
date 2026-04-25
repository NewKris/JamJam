using JamJam.Runtime.Drink;
using UnityEngine;

namespace JamJam.Runtime.Customers {
    [CreateAssetMenu(menuName = "Customer Data")]
    public class CustomerData : ScriptableObject {
        public string[] barks;
        public Flavour desiredFlavour;
        public int satisfactionLoss;
        public int satisfactionGain;
    }
}