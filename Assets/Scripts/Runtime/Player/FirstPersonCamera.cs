using System;
using UnityEngine;

namespace JamJam.Runtime.Player {
    public class FirstPersonCamera : MonoBehaviour {
        public float sensitivity = 1;
        public Vector2 axisDamping = Vector2.one;
        public float mouseSmoothing = 0;

        private Transform _pitchPivot;
        private Transform _yawPivot;

        private void Start() {
            CreateHierarchy();
        }

        private void Update() {
            Look(PlayerController.DeltaMouse, Time.deltaTime);
        }

        private void Look(Vector2 deltaMouse, float dt) {
        }

        private void CreateHierarchy() {
            _yawPivot = new GameObject("Yaw").transform;
            _yawPivot.SetParent(transform.parent);
            _yawPivot.SetPositionAndRotation(transform.position, transform.rotation);
            
            _pitchPivot = new GameObject("Pitch").transform;
            _pitchPivot.SetParent(_yawPivot);
            _pitchPivot.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            
            transform.SetParent(_pitchPivot);
            transform.SetLocalPositionAndRotation(Vector2.zero, Quaternion.identity);
        }
    }
}