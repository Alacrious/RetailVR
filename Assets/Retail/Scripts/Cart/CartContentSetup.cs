using UnityEngine;
using System.Collections;
using Solutionario.User;
using Solutionario.Base;
using UnityEngine.UI;

/**
 * Setup the content of the scroller and name and
 * price.
 */
public class CartContentSetup : MonoBehaviour {

	[SerializeField] private GameObject m_Prefab;
	[SerializeField] private Transform m_ContentTransform;

	[SerializeField] private Image m_SelectedSprite;
	[SerializeField] private Text m_ProductName;
	[SerializeField] private Text m_Price;


	private void Start () {
		
		//Initialize the cart with first product in cart.
		ArrayList products = UserCart.Instance.GetProducts ();

		if (products.Count > 0) {
			Product p = (Product)products [0];
			InitializeBackground (p);
			InitializeCartImages (p);
		}
	}

	private void InitializeBackground (Product p) {
		
		m_SelectedSprite.sprite = p._Sprites [0];
		m_ProductName.text = p._Name;
		m_Price.text = "$" + p._Price;
	}

	private void InitializeCartImages (Product p) {
		ArrayList products = UserCart.Instance.GetProducts ();

		for(int i=0; i<products.Count; i++) {
			GameObject go = Instantiate (m_Prefab) as GameObject;
			Image img = go.GetComponent<Image> ();
			img.sprite = ((Product)products [i])._Sprites [0];
			go.transform.SetParent (m_ContentTransform, false);
		}

		//Add three more empty prefab to support scrolling
		//beyond bounds.
		for (int i=0; i<SwipeHandler.NUMBER_OF_EMPTY_ITEMS; i++) {
			GameObject go = Instantiate (m_Prefab) as GameObject;
			go.transform.SetParent (m_ContentTransform);
		}

	}
}
