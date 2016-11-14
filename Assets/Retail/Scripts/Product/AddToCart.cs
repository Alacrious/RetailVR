using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;
using Solutionario.User;
using Retail.Utils;

public class AddToCart : MonoBehaviour {

	[SerializeField] private VRInteractiveItem m_InteractiveItem;
	[SerializeField] private Toast m_Toast;

	private void OnEnable () {
		m_InteractiveItem.OnClick += HandleClick;
	}

	private void OnDisable () {
		m_InteractiveItem.OnClick -= HandleClick;
	}

	private void HandleClick () {
		UserCart.Instance.AddToCart (UserData.Instance.CurrentProduct);

		//Show the toast that product is added to cart.
		StartCoroutine(m_Toast.Show ());
	}


	#if UNITY_EDITOR
	private void OnGUI () {
		if(GUI.Button(new Rect(10, 10, 50, 50), "Add")) {
			UserCart.Instance.StartSession ();
			HandleClick ();
		}
	}
	#endif
}
