using UnityEngine;

namespace JamJam.Runtime.Interactions {
    public class LogInteraction : MonoBehaviour {
        public void LogMessage(string message) {
            Debug.Log(message);
        }
    }
}