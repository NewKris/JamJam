using System;
using UnityEngine;

namespace JamJam.Runtime.Utility.CommonBehaviours {
    public class Billboard : MonoBehaviour {
        private void Update() {
            Vector3 dir = Camera.main.transform.position - transform.position;
            dir.y = 0;
            transform.rotation = Quaternion.LookRotation(dir.normalized);
        }
    }
}