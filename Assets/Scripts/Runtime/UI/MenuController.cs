using UnityEngine;
using UnityEngine.SceneManagement;

namespace JamJam.Runtime.UI {
    public class MenuController : MonoBehaviour {
        public void PlayGame() {
            SceneManager.LoadScene("Gameplay");
        }

        public void StartNewGame() {
            SceneManager.LoadScene("Intro Text");
        }

        public void ExitGame() {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}