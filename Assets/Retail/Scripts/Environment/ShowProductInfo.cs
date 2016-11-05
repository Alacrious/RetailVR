using UnityEngine;
using System.Collections;
using Retail.Utils;
using VRStandardAssets.Utils;
using UnityEngine.SceneManagement;

namespace Retail {
	public class ShowProductInfo : MonoBehaviour {

		[SerializeField] private Retail.Utils.UIFader m_ProductInfoCanvas;
		[SerializeField] private VRInteractiveItem m_InteractiveItem;
		[SerializeField] private float m_TimeToHideProductInfo;
		[SerializeField] private VRCameraFade m_CameraFade;


		private void OnEnable () {
			m_InteractiveItem.OnOver += HandleOver;
			m_InteractiveItem.OnOut += HandleOut;
			m_InteractiveItem.OnClick += HandleClick;
		}

		private void OnDisable () {
			m_InteractiveItem.OnOver -= HandleOver;
			m_InteractiveItem.OnOut -= HandleOut;
			m_InteractiveItem.OnClick -= HandleClick;
		}

		private void HandleOver () {
			StartCoroutine (m_ProductInfoCanvas.InteruptAndFadeIn ());
		}

		private void HandleOut () {
			StartCoroutine (HideProductInfo ());
		}

		private IEnumerator HideProductInfo () {
			yield return new WaitForSeconds (m_TimeToHideProductInfo);

			StartCoroutine (m_ProductInfoCanvas.InteruptAndFadeOut ());
		}

		private void HandleClick () {
			StartCoroutine (LoadProductsScene ());
		}

		private IEnumerator LoadProductsScene () {
			if (m_CameraFade.IsFading)
				yield break;
			
			// Wait for the screen to fade out.
			yield return StartCoroutine (m_CameraFade.BeginFadeOut (true));

			// Load the main menu by itself.
			SceneManager.LoadScene("ProductsScene", LoadSceneMode.Single);
			
		}


	}
}
