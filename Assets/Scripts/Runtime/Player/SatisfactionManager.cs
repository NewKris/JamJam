using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace JamJam.Runtime.Player {
    public class SatisfactionManager : MonoBehaviour {
        private static SatisfactionManager Instance;
        private static int SatisfactionLevel;
        
        public Slider satisfactionSlider;
        
        public static void DecreaseSatisfaction(int amount) {
            SatisfactionLevel -= Mathf.Abs(amount);
            Instance.satisfactionSlider.value = SatisfactionLevel;

            if (SatisfactionLevel <= 0) {
                SceneManager.LoadScene("Game Over");
            }
        }

        public static void IncreaseSatisfaction(int amount) {
            SatisfactionLevel += Mathf.Abs(amount);
            Instance.satisfactionSlider.value = SatisfactionLevel;
        }
        
        private void Awake() {
            Instance = this;
            SatisfactionLevel = 100;
        }
    }
}