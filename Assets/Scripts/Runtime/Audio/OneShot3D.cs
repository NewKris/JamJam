using System;
using UnityEngine;

namespace JamJam.Runtime.Audio {
    public class OneShot3D : MonoBehaviour {
        private AudioSource _source;
        
        public void Play(AudioClip clip) {
            GetComponent<AudioSource>().PlayOneShot(clip);
        }

        private void Awake() {
            _source = GetComponent<AudioSource>();
        }

        private void Update() {
            if (!_source.isPlaying) Destroy(gameObject);
        }
    }
}