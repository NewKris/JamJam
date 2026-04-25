using System;
using TMPro;
using UnityEngine;

namespace JamJam.Runtime.UI {
    public class GameOverSubTitle : MonoBehaviour {
        private void Awake() {
            GetComponent<TextMeshProUGUI>().text = GameManager.LoseReason;
        }
    }
}