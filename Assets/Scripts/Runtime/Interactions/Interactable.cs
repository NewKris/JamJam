using UnityEngine;
using UnityEngine.Events;

namespace JamJam.Runtime.Interactions {
    public class Interactable : MonoBehaviour {
        public UnityEvent onInteract;
        
        public void Interact() {
            onInteract.Invoke();
        }
    }
}