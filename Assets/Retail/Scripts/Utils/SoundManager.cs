using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour {

	private static SoundManager _instance = null;

	private void OnEnable () {
		SceneManager.sceneLoaded += HandleSceneLoaded;
	}

	private void OnDisable () {
		SceneManager.sceneLoaded += HandleSceneLoaded;
	}

	private void HandleSceneLoaded (Scene scene, LoadSceneMode mode) {
		RestartClip ();
	}

	void Awake () {
		if (_instance != null && _instance != this) {
			Destroy (gameObject);
			return;
		} else {
			_instance = this;
		}

		DontDestroyOnLoad (gameObject);
	}

	public static SoundManager GetInstance() {
		return _instance;
	}

	public void RestartClip () {
		AudioSource audioSource = this.	gameObject.GetComponent<AudioSource> ();
		audioSource.Stop ();
		audioSource.Play ();
	}
}
