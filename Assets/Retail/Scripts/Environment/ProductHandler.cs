using UnityEngine;
using System.Collections;
using Retail.Utils;
using VRStandardAssets.Utils;
using UnityEngine.SceneManagement;
using Solutionario.Base;
using Solutionario.User;

namespace Retail {
	/**
	 * Handle the hover and click events on the products
	 * in the environment scene.
	 */
	public class ProductHandler : MonoBehaviour {

		[SerializeField] private Retail.Utils.UIFader m_ProductInfoCanvas;
		[SerializeField] private VRInteractiveItem m_InteractiveItem;
		[SerializeField] private float m_TimeToHideProductInfo;
		[SerializeField] private VRCameraFade m_CameraFade;
		[SerializeField] private string m_ProductId;


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
			//TODO Sets the current product
			UserData.Instance.CurrentProduct = Product.GetSomeProduct ();

			StartCoroutine(SceneHandler.GetInstance().LoadScene (SceneUtils.SceneType.PRODUCTSSCENE, m_CameraFade));
		}
	}
}
