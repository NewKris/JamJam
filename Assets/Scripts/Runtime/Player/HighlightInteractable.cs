using System;
using JamJam.Runtime.Utility.Extensions;
using UnityEngine;

namespace JamJam.Runtime.Player {
    public class HighlightInteractable : MonoBehaviour {
        public GameObject[] outlines;
        
        public bool LookingAt { get; set; }

        private void LateUpdate() {
            outlines.ForEach(x => x.SetActive(LookingAt));
            LookingAt = false;
        }
    }
}