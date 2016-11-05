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

		public void OnEnable() {
			m_InstructionsFader.OnFadeOutComplete += InstructionsFadeOutComplete;
			m_EnvironmentsFader.OnFadeOutComplete += EnvironmentsFadeOutComplete;

			m_StartButton.EntityClicked += HandleStartButton;
		}

		public void OnDisable() {
			m_InstructionsFader.OnFadeOutComplete -= InstructionsFadeOutComplete;
			m_EnvironmentsFader.OnFadeOutComplete -= EnvironmentsFadeOutComplete;

			m_StartButton.EntityClicked -= HandleStartButton;
		}

		/**
		 * Fade in instructions and on start fade out instructions 
		 * with fading in of environments
		 */
		private IEnumerator Start() {
			//Fade out current instructions.
			yield return StartCoroutine (m_InstructionsFader.InteruptAndFadeIn ());
		}

		public void HandleStartButton() {
			Debug.Log("UIController :Handling the start button");
			StartCoroutine (m_InstructionsFader.InteruptAndFadeOut ());
		}

		private void InstructionsFadeOutComplete() {
			StartCoroutine (m_EnvironmentsFader.InteruptAndFadeIn ());
		}

		private void EnvironmentsFadeOutComplete() {
		}
	}
}
