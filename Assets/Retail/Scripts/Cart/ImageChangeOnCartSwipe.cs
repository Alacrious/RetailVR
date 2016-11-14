using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Solutionario.Base;
using Solutionario.User;

public class ImageChangeOnCartSwipe : MonoBehaviour {

	[SerializeField] private Image m_Image;
	[SerializeField] private SwipeHandler m_SwipeHandler;

	private void OnEnable () {
		m_SwipeHandler.OnScrollComplete += HandleScrollComplete;
	}

	void HandleScrollComplete (int selectedItem) {
		ArrayList products = UserCart.Instance.GetProducts ();

		m_Image.sprite = ((Product)products[selectedItem - 1])._Sprites[0];
	}
}
