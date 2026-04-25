using JamJam.Runtime.Drink;
using UnityEngine;

namespace JamJam.Runtime.Customers {
    [CreateAssetMenu(menuName = "Customer Data")]
    public class CustomerData : ScriptableObject {
        public string firstBark;
        public string repeatingBark;
        public CustomerRequest desiredFlavour;
        public int satisfactionLoss;
        public int satisfactionGain;
        public bool isTarget;
        public Sprite sprite;
    }
}