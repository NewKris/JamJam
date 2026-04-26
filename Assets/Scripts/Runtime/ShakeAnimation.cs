using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace JamJam.Runtime {
    public class ShakeAnimation : MonoBehaviour {
        public float intensity;
        public float frequency;

        private float _lastShake;
        
        public bool Shaking { get; set; }
        
        private void Update() {
            if (Shaking && CanShake()) {
                transform.localPosition = Random.insideUnitSphere * intensity;
                _lastShake = Time.time;
            }
            else {
                transform.localPosition = Vector3.zero;
            }
        }

        private bool CanShake() {
            return Time.time - _lastShake > frequency;
        }
    }
}