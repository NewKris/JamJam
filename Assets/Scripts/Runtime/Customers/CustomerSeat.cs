using System;
using UnityEngine;
using Werehorse.Runtime.Utility;

namespace JamJam.Runtime.Customers {
    public class CustomerSeat : MonoBehaviour {
        public bool Available { get; set; }
        public Vector3 SpawnStart => transform.position + Vector3.forward * 5;
        public Vector3 SeatPos => transform.position;

        private void Start() {
            Available = true;
        }

        private void OnDrawGizmos() {
            HandlesProxy.DrawDisc(transform.position, Vector3.up, 0.5f, false, Color.yellow);
            HandlesProxy.DrawDisc(SpawnStart, Vector3.up, 0.5f, true, Color.red);
            HandlesProxy.DrawLine(transform.position, SpawnStart, 1, true, Color.red);
        }
    }
}