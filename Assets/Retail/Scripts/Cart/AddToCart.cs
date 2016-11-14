using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;
using Solutionario.User;

public class AddToCart : MonoBehaviour {

	[SerializeField] private VRInteractiveItem m_InteractiveItem;

	private void OnEnable () {
		m_InteractiveItem.OnClick += HandleClick;
	}

	private void OnDisable () {
		m_InteractiveItem.OnClick -= HandleClick;
	}

	private void HandleClick () {
		UserCart.Instance.AddToCart (UserData.Instance.CurrentProduct);
	}
}
