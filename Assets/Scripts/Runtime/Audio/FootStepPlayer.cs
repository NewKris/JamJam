using System;
using JamJam.Runtime.Utility.Extensions;
using UnityEngine;

namespace JamJam.Runtime.Audio {
    public class FootStepPlayer : MonoBehaviour {
        public AudioClip[] footSteps;
        public float frequency;

        private float _lastPlayed;
        private AudioSource _source;
        
        public bool IsWalking { get; set; }

        private void Awake() {
            _source = GetComponent<AudioSource>();
        }

        private void Update() {
            if (IsWalking && CanPlay()) Play();
        }

        private void Play() {
            _lastPlayed = Time.time;
            _source.PlayOneShot(footSteps.GetRandom());
        }

        private bool CanPlay() {
            return Time.time - _lastPlayed > frequency;
        }
    }
}