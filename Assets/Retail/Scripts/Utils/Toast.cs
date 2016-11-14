using UnityEngine;
using System.Collections;
using Retail.Utils;

public class Toast : MonoBehaviour {

	[SerializeField] private UIFader m_CanvasFader;
	[SerializeField] private float m_ToastTime = 1f;

	public IEnumerator Show () {
		StartCoroutine (m_CanvasFader.InteruptAndFadeIn ());

		yield return new WaitForSeconds (m_ToastTime);

		StartCoroutine (m_CanvasFader.InteruptAndFadeOut ());
	}
}
