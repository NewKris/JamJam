using UnityEngine;
using UnityEngine.Events;

namespace JamJam.Runtime.Player {
    public class ReleaseInteractable : MonoBehaviour {
        public UnityEvent onRelease;

        public void Release() {
            onRelease.Invoke();
        }
    }
}