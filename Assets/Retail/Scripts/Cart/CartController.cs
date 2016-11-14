using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

namespace Retail.Cart {
	public class CartController : MonoBehaviour {

		[SerializeField] private Reticle m_Reticle;
		[SerializeField] private SelectionRadial m_Radial;

		// Use this for initialization
		void Start () {
			m_Reticle.Show ();
			m_Radial.Hide ();
		}
	}
}
