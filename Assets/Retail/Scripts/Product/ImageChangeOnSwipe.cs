using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Solutionario.Base;
using Solutionario.User;

public class ImageChangeOnSwipe : MonoBehaviour {

	[SerializeField] private Image m_Image;
	[SerializeField] private SwipeHandler m_SwipeHandler;

	private void OnEnable () {
		m_SwipeHandler.OnScrollComplete += HandleScrollComplete;
	}

	void HandleScrollComplete (int selectedItem) {
		Product p = UserData.Instance.CurrentProduct;

		m_Image.sprite = p._Sprites [selectedItem - 1];
	}
}
