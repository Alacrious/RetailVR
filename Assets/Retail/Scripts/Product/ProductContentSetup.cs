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
	[SerializeField] private SwipeHandler m_SwipeHandler;

	private void OnEnable () {
		m_SwipeHandler.OnSwipeLeft += HandleSwipeLeft;
		m_SwipeHandler.OnSwipeRight += HandleSwipeRight;
	}

	private void OnDisable () {
		m_SwipeHandler.OnSwipeLeft -= HandleSwipeLeft;
		m_SwipeHandler.OnSwipeRight -= HandleSwipeRight;
	}

	private void Start () {
		//TODO Remove to
		UserData.Instance.CurrentEnvironment = Solutionario.Base.Environment.GetEnvironment ("Apartment");
		UserData userData = UserData.Instance;
		userData.CurrentProduct = ((Product)(userData.CurrentEnvironment.GetProductList () [0]));


		RefreshContent ();
	}

	/**
	 * Refreshes the content according to the current selected product.
	 */
	private void RefreshContent () {
		Product product = UserData.Instance.CurrentProduct;
		InitializeBackground (product);
		InitializeProductImages (product);
	}

	private void InitializeBackground (Product p) {

		m_SelectedSprite.sprite = p._Sprites [0];
		m_ProductName.text = p._Name;
		m_Price.text = "$" + p._Price;
		m_Color.text = p._Color;
		m_ProductMaterial.text = p._Material;
		m_Size.text = p._Size;
		m_Origin.text = p._Origin;

		//TODO Set the side sprites

	}

	private void InitializeProductImages (Product currentProduct) {
		//Removes all the previous products
		for(int i=m_ContentTransform.childCount-1; i>=0; i--) {
			Destroy (m_ContentTransform.GetChild(i).gameObject);
		}

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


	private void HandleSwipeLeft () {
		//Get previous item in the environment and refresh the content
		Environment env = UserData.Instance.CurrentEnvironment;
		Product p = env.GetNextProduct (UserData.Instance.CurrentProduct);

		if (p != null) {
			UserData.Instance.CurrentProduct = p;

			RefreshContent ();
		}
	}

	private void HandleSwipeRight () {
		//Get next item in the environment and refresh the content
		Environment env = UserData.Instance.CurrentEnvironment;
		Product p = env.GetPreviousProduct (UserData.Instance.CurrentProduct);

		if (p != null) {
			UserData.Instance.CurrentProduct = p;

			RefreshContent ();
		}
	}


}
