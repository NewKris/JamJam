using System;
using JamJam.Runtime.Player;
using UnityEngine;

namespace JamJam.Runtime.UI {
    public class TutorialPanel : MonoBehaviour {
        public GameObject tutorial1;
        public GameObject tutorial2;

        private void Update() {
            tutorial1.SetActive(PlayerController.HoldingTutorial1);
            tutorial2.SetActive(PlayerController.HoldingTutorial2);
        }
    }
}