using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace JamJam.Runtime {
    public class GameManager : MonoBehaviour {
        public static string LoseReason;
        
        public static void Win() {
            SceneManager.LoadScene("Victory Screen");
        }

        public static void Lose(string reason) {
            LoseReason = reason;
            SceneManager.LoadScene("Game Over");
        }
    }
}