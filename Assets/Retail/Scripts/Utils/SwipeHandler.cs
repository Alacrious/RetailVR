using System;
using UnityEngine;
using UnityEngine.UI;
using VRStandardAssets.Utils;
using Solutionario.User;

/**
 * It handles and manages all the swipes on the Product Scene.
 */
public class SwipeHandler : MonoBehaviour {

	public event Action<int> OnScrollComplete;
	public event Action OnSwipeLeft;
	public event Action OnSwipeRight;

	public static int NUMBER_OF_EMPTY_ITEMS = 3;

	[SerializeField] private ScrollRect m_ScrollRect;
	[SerializeField] private VRInput m_VRInput;
	[SerializeField] private float m_DeceraltionTime = 10f;
	//Height of the item to scroll
	[SerializeField] private float m_ScrollHeight = 30f;
	//Currently selected image of the product.
	//[SerializeField] private Image m_MainImage;


	private RectTransform m_ScrollRectTransform;

	private RectTransform m_ContainerTransform;
	// No of items in the list to be scrolled
	private int m_Items;

	private int m_SelectedItem = 1;



	private bool scrolling = false;
	private Vector2 scrollPosition = Vector2.zero;

	private void Start () {
		m_ScrollRectTransform = m_ScrollRect.GetComponent<RectTransform> ();
		m_ContainerTransform = m_ScrollRect.content;
	}

	private void OnEnable () {
		m_VRInput.OnSwipe += HandleSwipe;
		//this.OnScrollComplete += HandleScrollComplete;
	}

	private void OnDisable () {
		m_VRInput.OnSwipe -= HandleSwipe;
		//this.OnScrollComplete -= HandleScrollComplete;
	}

	private void Update () {
		if (scrolling) {
			float decelerateTime = Mathf.Min (m_DeceraltionTime * Time.deltaTime, 1f);
			m_ContainerTransform.anchoredPosition = Vector2.Lerp (m_ContainerTransform.anchoredPosition, scrollPosition, decelerateTime);

			if (Vector2.SqrMagnitude (m_ContainerTransform.anchoredPosition - scrollPosition) < 0.25f) {
				m_ContainerTransform.anchoredPosition = scrollPosition;
				scrolling = false;
				m_ScrollRect.velocity = Vector2.zero;

				if (OnScrollComplete != null) {
					OnScrollComplete (m_SelectedItem);
				}
			}
		}
	}

	//Converting swipe action to scroll action
	private void HandleSwipe (VRInput.SwipeDirection swipeDirection) {
		if (!scrolling && swipeDirection != VRInput.SwipeDirection.NONE) {
			int totalItems = GetItems ();
			switch (swipeDirection) {
			case VRInput.SwipeDirection.UP:
				//Do not scroll down if already at last item
				if(m_SelectedItem != totalItems)
					ScrollDownItems ();
				break;
			case VRInput.SwipeDirection.DOWN:
				//Do not scroll up if already at firt item
				if(m_SelectedItem != 1)
					ScrollUpItems ();
				break;
			case VRInput.SwipeDirection.LEFT:
				if (OnSwipeLeft != null) {
					m_SelectedItem = 1;
					m_ContainerTransform.anchoredPosition = Vector2.zero;
					OnSwipeLeft ();
				}
				break;
			case VRInput.SwipeDirection.RIGHT:
				if (OnSwipeRight != null) {
					m_SelectedItem = 1;
					m_ContainerTransform.anchoredPosition = Vector2.zero;
					OnSwipeRight ();
				}
				break;
			}
		}
	}

	private void ScrollDownItems () {
		scrollPosition = m_ContainerTransform.anchoredPosition + new Vector2 (0, m_ScrollHeight);
		scrollPosition.y = Mathf.Clamp (scrollPosition.y, 0, m_ScrollHeight * (GetItems () - 1));
		scrolling = true;
		m_SelectedItem += 1;
	}

	private void ScrollUpItems () {
		scrollPosition = m_ContainerTransform.anchoredPosition - new Vector2 (0, m_ScrollHeight);
		scrollPosition.y = Mathf.Clamp (scrollPosition.y, 0, m_ScrollHeight * (GetItems () - 1));
		scrolling = true;
		m_SelectedItem -= 1;
	}

	private int GetItems () {
		return m_ContainerTransform.childCount - NUMBER_OF_EMPTY_ITEMS;
	}

	#if false
	private void HandleScrollComplete (int selectedItem) {
		//Change the main sprite of the product to currently selected product's image
		m_MainImage.sprite = UserData.Instance.CurrentProduct._Sprites[m_SelectedItem - 1];
	}
	#endif

	#if UNITY_EDITOR
	private void OnGUI () {
		if (GUI.Button (new Rect(10, 20, 50, 50), "Left")) {
			HandleSwipe (VRInput.SwipeDirection.LEFT);
		}

		if (GUI.Button (new Rect(10, 60, 50, 50), "Right")) {
			HandleSwipe (VRInput.SwipeDirection.RIGHT);
		}
	}
	#endif
}
