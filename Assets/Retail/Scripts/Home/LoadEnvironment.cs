using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using VRStandardAssets.Utils;
using UnityEngine.SceneManagement;
using Retail.Utils;
using Solutionario.User;
using Solutionario.Base;

public class LoadEnvironment : MonoBehaviour {


	[SerializeField] private string m_SceneToLoad;
	[SerializeField] private VRCameraFade m_CameraFade;
	[SerializeField] private GazeClicked m_GazeClickedEntity;
	[SerializeField] private string m_EnvironmentToLoad;

	private void OnEnable() {
		m_GazeClickedEntity.EntityClicked += HandleClick;
	}

	private void OnDisable() {
		m_GazeClickedEntity.EntityClicked -= HandleClick;
	}

	private void HandleClick() {
		UserData.Instance.CurrentEnvironment = Solutionario.Base.Environment.GetEnvironment (m_EnvironmentToLoad);

		StartCoroutine(SceneHandler.GetInstance().LoadScene (SceneUtils.SceneType.ENVIRONMENTSCENE, m_CameraFade));
	}
}
