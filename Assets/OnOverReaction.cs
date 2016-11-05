using UnityEngine;
using VRStandardAssets.Utils;

namespace VRStandardAssets.Examples
{

	public class OnOverReaction : MonoBehaviour
	{
		[SerializeField] private VRInteractiveItem m_Item;

		private void OnEnable()
		{
			Debug.Log("Show over state");
			m_Item.OnOver += HandleOnOver;
			m_Item.OnOut += HandleOnOut;
		}


		private void OnDisable()
		{
			Debug.Log("Show over state");
			m_Item.OnOver -= HandleOnOver;
			m_Item.OnOut += HandleOnOut;
		}

		private void HandleOnOver()
		{
			Debug.Log("Handle over state");
			//m_Renderer.material.color = Color.green;
		}

		private void HandleOnOut() {
			Debug.Log("Show over state");
			//m_Renderer.material.color = Color.blue;
			m_Item.gameObject.transform.localScale.Set (1f,1f,1f);
		}
	}
}