using UnityEngine;
using UnityEngine.Events;

namespace JamJam.Runtime.Player {
    public class GrabInteractable : MonoBehaviour {
        public UnityEvent onGrab;

        public void Grab() {
            onGrab.Invoke();
        }
    }
}