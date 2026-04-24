using JamJam.Runtime.Bar;
using UnityEngine;

namespace JamJam.Runtime.Customers {
    [CreateAssetMenu(menuName = "Customer Data")]
    public class CustomerData : ScriptableObject {
        public string[] barks;
    }
}