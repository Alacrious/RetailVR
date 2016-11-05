using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using VRStandardAssets.Utils;
using UnityEngine.SceneManagement;

public class LoadEnvironment : MonoBehaviour {


	[SerializeField] private string m_SceneToLoad;
	[SerializeField] private VRCameraFade m_CameraFade;
	[SerializeField] private Image m_Image;
	[SerializeField] private GazeClicked m_GazeClickedEntity;

	private void OnEnable() {
		m_GazeClickedEntity.EntityClicked += HandleClick;
	}

	private void OnDisable() {
		m_GazeClickedEntity.EntityClicked += HandleClick;
	}

	private void HandleClick() {
		StartCoroutine (Load ());
	}

	private IEnumerator Load() {
		//Fade out the Environment cards
		// If the camera is already fading, ignore.

		if (m_CameraFade.IsFading)
			yield break;

		//Load the clicked environment.
		// Wait for the camera to fade out.
		yield return StartCoroutine(m_CameraFade.BeginFadeOut(true));

		// Load the level.
		SceneManager.LoadScene(m_SceneToLoad, LoadSceneMode.Single);
	}
}
