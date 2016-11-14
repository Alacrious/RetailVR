using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class ScaleObject : MonoBehaviour {

	[SerializeField] private VRInteractiveItem m_InteractiveItem;
	[SerializeField] private Transform m_Transform;
	[SerializeField] private float m_ScaleX = 0.2f;
	[SerializeField] private float m_ScaleY = 0.2f;

	private void OnEnable () {
		m_InteractiveItem.OnOver += HandleOver;
		m_InteractiveItem.OnOut += HandleOut;
	}

	private void OnDisable () {
		m_InteractiveItem.OnOut -= HandleOut;
	}

	private void HandleOver () {
		m_Transform.localScale += new Vector3 (m_ScaleX, m_ScaleX, 0f);
	}

	private void HandleOut () {
		m_Transform.localScale -= new Vector3 (m_ScaleX, m_ScaleX, 0f);
	}
}
