using System;
using UnityEngine;

namespace JamJam.Runtime.Player {
    public class VfxPlayer : MonoBehaviour {
        private static VfxPlayer Instance;
        
        private Animator _animator;
        
        public static void TriggerCrash() {
            Instance._animator.SetTrigger("Crash");
        }

        private void Awake() {
            Instance = this;
            _animator = GetComponent<Animator>();
        }
    }
}