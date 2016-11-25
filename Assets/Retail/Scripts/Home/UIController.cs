using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Retail.Utils;
using VRStandardAssets.Utils;
using System.Collections.Generic;

namespace Retail {
	public class UIController : MonoBehaviour {

		[SerializeField] private Retail.Utils.UIFader m_InstructionsFader;
		[SerializeField] private Retail.Utils.UIFader m_EnvironmentsFader;
		[SerializeField] private GazeClicked m_StartButton;
		[SerializeField] private Retail.Utils.UIFader m_MenuFader;
		[SerializeField] private Canvas m_EnvironmentCanvas;
		[SerializeField] private Canvas m_MenuCanvas;
		[SerializeField] private Reticle m_Reticle;
		[SerializeField] private SelectionRadial m_Radial;


		private void OnEnable() {
			m_InstructionsFader.OnFadeOutComplete += InstructionsFadeOutComplete;
			m_EnvironmentsFader.OnFadeOutComplete += EnvironmentsFadeOutComplete;
			m_EnvironmentsFader.OnFadeInComplete += EnvironmentsFadeInComplete;
			m_StartButton.EntityClicked += HandleStartButton;
		}

		private void OnDisable() {
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
			m_Reticle.Show ();
			m_Radial.Hide ();

			//Fade in current instructions.
			yield return StartCoroutine (m_InstructionsFader.InteruptAndFadeIn ());
		}

		public void HandleStartButton() {
			Debug.Log("UIController :Handling the start button");
			StartCoroutine (m_InstructionsFader.InteruptAndFadeOut ());
		}

		private void InstructionsFadeOutComplete() {
			StartCoroutine (ShowEnvironmentAndMenu ());
		}

		private IEnumerator ShowEnvironmentAndMenu () {
			m_EnvironmentCanvas.gameObject.SetActive (true);
			m_MenuCanvas.gameObject.SetActive (true);
			yield return StartCoroutine (m_EnvironmentsFader.InteruptAndFadeIn ());
			yield return StartCoroutine (m_MenuFader.InteruptAndFadeIn ());
		}

		private void EnvironmentsFadeOutComplete() {
		}

		private void EnvironmentsFadeInComplete () {

		}
	}
}
