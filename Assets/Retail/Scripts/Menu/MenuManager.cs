using UnityEngine;
using VRStandardAssets.Utils;
using Retail.Utils;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	[SerializeField] private VRInteractiveItem m_Home;
	[SerializeField] private VRInteractiveItem m_Back;
	[SerializeField] private VRInteractiveItem m_Help;
	[SerializeField] private VRInteractiveItem m_Cart;

	private VRCameraFade m_CameraFade;

	private void OnEnable () {
		m_Home.OnClick += Home;
		m_Back.OnClick += Back;
		m_Help.OnClick += Help;
		m_Cart.OnClick += Cart;
	}

	private void OnDisable () {
		m_Home.OnClick -= Home;
		m_Back.OnClick -= Back;
		m_Help.OnClick -= Help;
		m_Cart.OnClick -= Cart;
	}

	private void Start () {
		GameObject camera = GameObject.FindGameObjectWithTag ("MainCamera");
		m_CameraFade = (VRCameraFade)camera.GetComponent<VRCameraFade> ();
	}

	private void Home () {
		SceneHandler.GetInstance().GoToHomeScene (m_CameraFade);
	}

	private void Help () {
		//TODO
		//Fade in the UI Fader for the help canvas
		//Handle the help canvas controls
	}

	private void Back () {
		StartCoroutine(SceneHandler.GetInstance().LoadScene (LevelManager.PreviousSceneType, m_CameraFade));
	}

	private void Cart () {
		StartCoroutine(SceneHandler.GetInstance().LoadScene (SceneUtils.SceneType.CARTSCENE, m_CameraFade));
	}

	#if UNITY_EDITOR
	private void OnGUI () {
		if (GUI.Button (new Rect (10, 60, 50, 50), "Home")) {
			Home ();	
		}

		if (GUI.Button (new Rect (10, 120, 50, 50), "Back")) {
			Back ();	
		}
	}
	#endif
}
