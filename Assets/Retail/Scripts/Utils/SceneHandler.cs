using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;
using UnityEngine.SceneManagement;
using Solutionario.User;

namespace Retail.Utils {
	public class SceneHandler : MonoBehaviour {

		private static SceneHandler _instance = null;

		void Awake () {
			if (_instance != null && _instance != this) {
				Destroy (gameObject);
				return;
			} else {
				_instance = this;
			}

			DontDestroyOnLoad (gameObject);
		}

		public static SceneHandler GetInstance () {
			return _instance;
		}

		private void Start () {
			UserData.Instance.StartSession ();
		}

		public IEnumerator LoadScene (SceneUtils.SceneType sceneType, VRCameraFade cameraFade) {
			//Set the previous scene name
			LevelManager.PreviousSceneType = SceneUtils.GetSceneType(SceneManager.GetActiveScene ().name);

			if (cameraFade.IsFading)
				yield break;

			// Wait for the screen to fade out.
			yield return StartCoroutine (cameraFade.BeginFadeOut (true));

			// Load the main menu by itself.
			SceneManager.LoadScene (SceneUtils.GetSceneName (sceneType), LoadSceneMode.Single);
		}

		public void GoToHomeScene (VRCameraFade cameraFade) {
			StartCoroutine(LoadScene (SceneUtils.SceneType.STARTSCENE, cameraFade));
		}
	}
}
		