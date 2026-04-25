using System;
using JamJam.Runtime.Customers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace JamJam.Runtime.Player {
    public class SatisfactionManager : MonoBehaviour {
        private static SatisfactionManager Instance;
        private static int SatisfactionLevel;
        
        public Slider satisfactionSlider;
        public int startSatisfaction = 50;
        
        public static void DecreaseSatisfaction(int amount) {
            SatisfactionLevel -= Mathf.Abs(amount);
            Instance.satisfactionSlider.value = SatisfactionLevel;

            if (SatisfactionLevel <= 0) {
                GameManager.Lose("Your customers stormed out!");
            }
        }

        public static void IncreaseSatisfaction(int amount) {
            SatisfactionLevel += Mathf.Abs(amount);
            Instance.satisfactionSlider.value = SatisfactionLevel;

            if (SatisfactionLevel >= 100) {
                CustomerSystem.AddFinalBoss();
            }
        }
        
        private void Awake() {
            Instance = this;
            SatisfactionLevel = startSatisfaction;
            satisfactionSlider.value = SatisfactionLevel;
        }
    }
}