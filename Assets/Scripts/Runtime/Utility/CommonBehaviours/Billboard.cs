using System;
using UnityEngine;

namespace JamJam.Runtime.Utility.CommonBehaviours {
    public class Billboard : MonoBehaviour {
        public bool invert;

        private float _mult;
        
        private void Awake() {
            _mult = invert ? -1 : 1;
        }

        private void Update() {
            Vector3 dir = Camera.main.transform.position - transform.position;
            dir *= _mult;
            dir.y = 0;
            transform.rotation = Quaternion.LookRotation(dir.normalized);
        }
    }
}