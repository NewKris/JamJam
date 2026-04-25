using UnityEngine;

namespace JamJam.Runtime.Customers {
    public class ReactionBubble : MonoBehaviour {
        public void Display(bool satisfied) {
            gameObject.SetActive(true);
        }
    }
}