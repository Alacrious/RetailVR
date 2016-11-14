using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;
using Solutionario.User;

namespace Retail.Environment {
	public class EnvironmentController : MonoBehaviour {

		[SerializeField] private Reticle m_Reticle;
		[SerializeField] private SelectionRadial m_Radial;

		// Use this for initialization
		void Start () {
			//TODO Remove it. Just for testing.
			UserData.Instance.CurrentEnvironment = Solutionario.Base.Environment.GetEnvironment ("Apartment");

			m_Reticle.Show ();
			m_Radial.Hide ();
		}
	}
}
