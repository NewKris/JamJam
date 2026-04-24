using System;
using UnityEngine;
using Werehorse.Runtime.Utility;

namespace JamJam.Runtime.Customers {
    public class CustomerSeat : MonoBehaviour {
        public Transform startSpawn;
        
        public bool Available { get; set; }

        private void Start() {
            Available = true;
        }

        private void OnDrawGizmos() {
            HandlesProxy.DrawDisc(transform.position, Vector3.up, 0.5f, false, Color.yellow);
        }
    }
}