using System;
using JamJam.Runtime.Player;
using UnityEngine;

namespace JamJam.Runtime.UI {
    public class TutorialPanel : MonoBehaviour {
        public GameObject tutorialParent;

        private void Awake() {
            PlayerController.OnToggleTutorial += ToggleTutorial;
        }

        private void OnDestroy() {
            PlayerController.OnToggleTutorial -= ToggleTutorial;
        }

        private void ToggleTutorial() {
            tutorialParent.SetActive(!tutorialParent.activeSelf);
        }
    }
}