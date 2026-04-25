using UnityEngine;

namespace JamJam.Runtime.Customers {
    public class ReactionBubble : MonoBehaviour {
        public Sprite positiveReaction;
        public Sprite negativeReaction;
        
        public void Display(bool satisfied) {
            gameObject.SetActive(true);
            GetComponent<SpriteRenderer>().sprite = satisfied ? positiveReaction : negativeReaction;
        }
    }
}