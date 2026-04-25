using System;
using UnityEngine;

namespace JamJam.Runtime.Drink {
    [RequireComponent(typeof(Rigidbody))]
    public class BreakArea : MonoBehaviour {
        private void OnTriggerEnter(Collider other) {
            if (other.TryGetComponent(out DrinkObject drink)) {
                drink.Break();
            }
        }
    }
}