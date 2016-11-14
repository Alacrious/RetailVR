using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Retail.Utils;
using VRStandardAssets.Utils;

namespace Retail {
	public class UIController : MonoBehaviour {

		public Retail.Utils.UIFader m_InstructionsFader;
		public Retail.Utils.UIFader m_EnvironmentsFader;
		public GazeClicked m_StartButton;
		[SerializeField] private Retail.Utils.UIFader m_MenuFader;
		[SerializeField] private Canvas m_EnvironmentCanvas;
		[SerializeField] private Canvas m_MenuCanvas;

		public void OnEnable() {
			m_InstructionsFader.OnFadeOutComplete += InstructionsFadeOutComplete;
			m_EnvironmentsFader.OnFadeOutComplete += EnvironmentsFadeOutComplete;
			m_EnvironmentsFader.OnFadeInComplete += EnvironmentsFadeInComplete;
			m_StartButton.EntityClicked += HandleStartButton;
		}

		public void OnDisable() {
			m_InstructionsFader.OnFadeOutComplete -= InstructionsFadeOutComplete;
			m_EnvironmentsFader.OnFadeOutComplete -= EnvironmentsFadeOutComplete;
			m_EnvironmentsFader.OnFadeInComplete -= EnvironmentsFadeInComplete;
			m_StartButton.EntityClicked -= HandleStartButton;
		}

		#if UNITY_EDITOR
		private void OnGUI () {
			if (GUI.Button (new Rect (10, 10, 50, 50), "Start")) {
				HandleStartButton ();
			}
		}
		#endif

		/**
		 * Fade in instructions and on start fade out instructions 
		 * with fading in of environments
		 */
		private IEnumerator Start() {
			//Fade in current instructions.
			yield return StartCoroutine (m_InstructionsFader.InteruptAndFadeIn ());
		}

		public void HandleStartButton() {
			Debug.Log("UIController :Handling the start button");
			StartCoroutine (m_InstructionsFader.InteruptAndFadeOut ());
		}

		private void InstructionsFadeOutComplete() {
			StartCoroutine (m_EnvironmentsFader.InteruptAndFadeIn ());
			StartCoroutine (m_MenuFader.InteruptAndFadeIn ());
		}

		private void EnvironmentsFadeOutComplete() {
		}

		private void EnvironmentsFadeInComplete () {
			m_EnvironmentCanvas.gameObject.SetActive (true);
			m_MenuCanvas.gameObject.SetActive (true);
		}
	}
}
