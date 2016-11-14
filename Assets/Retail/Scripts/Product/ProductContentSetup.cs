using UnityEngine;
using System.Collections;
using Solutionario.Base;
using Solutionario.User;
using UnityEngine.UI;

/**
 * Setup the content of scroller and background
 * according to the selected product. Also takes
 * care of refreshing the content.
 */
public class ProductContentSetup : MonoBehaviour {

	[SerializeField] private GameObject m_Prefab;
	[SerializeField] private Transform m_ContentTransform;

	//Background properties
	[SerializeField] private Image m_SelectedSprite;
	[SerializeField] private Text m_ProductName;
	[SerializeField] private Text m_Price;
	[SerializeField] private Text m_Color;
	[SerializeField] private Text m_ProductMaterial;
	[SerializeField] private Text m_Size;
	[SerializeField] private Text m_Origin;
	[SerializeField] private Image m_LeftSprite;
	[SerializeField] private Image m_RightSprite;


	private void Start () {
		//TODO Remove it .Testing purpose
		UserData.Instance.CurrentProduct = Product.GetSomeProduct ();
		InitializeBackground ();
		InitializeProductImages ();
	}

	private void InitializeBackground () {
		Product p = UserData.Instance.CurrentProduct;

		m_SelectedSprite.sprite = p._Sprites [0];
		m_ProductName.text = p._Name;
		m_Price.text = "$" + p._Price;
		m_Color.text = p._Color;
		m_ProductMaterial.text = p._Material;
		m_Size.text = p._Size;
		m_Origin.text = p._Origin;

		//TODO Set the side sprites

	}

	private void InitializeProductImages () {
		Product currentProduct = UserData.Instance.CurrentProduct;


		for (int i=0; i<currentProduct._Sprites.Length; i++) {
			GameObject go = Instantiate (m_Prefab) as GameObject;
			Image img = go.GetComponent<Image> ();
			img.sprite = currentProduct._Sprites [i];
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
