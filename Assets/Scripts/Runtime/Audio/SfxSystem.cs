using JamJam.Runtime.Utility.Extensions;
using UnityEngine;

namespace JamJam.Runtime.Audio {
    public class SfxSystem : MonoBehaviour {
        private static SfxSystem Instance;

        public GameObject oneShotPrefab;
        public AudioClip[] pickUpGlass;
        public AudioClip[] glassCrash;
        
        private AudioSource _sfxSource;

        public static void PlayGeneric(AudioClip clip) {
            Instance.PlayOneShot(clip);
        }

        public static void PlayPickUp() {
            Instance.PlayOneShot(Instance.pickUpGlass.GetRandom());
        }

        public static void PlayCrash(Vector3 point) {
            Instance.PlayOneShot(Instance.glassCrash.GetRandom(), point);
        }
        
        private void Awake() {
            Instance = this;
            _sfxSource = GetComponent<AudioSource>();
        }
        
        private void PlayOneShot(AudioClip clip) {
            _sfxSource.PlayOneShot(clip);
        }

        private void PlayOneShot(AudioClip clip, Vector3 point) {
            OneShot3D oneShot3D = Instantiate(oneShotPrefab, point, Quaternion.identity).GetComponent<OneShot3D>();
            oneShot3D.Play(clip);
        }
    }
}