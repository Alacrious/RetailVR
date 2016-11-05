using System;
using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

/**
 * Class to handle input if an entity is gazed and click.
 * Classes will be notified through EntityClicked method.
 */
public class GazeClicked : MonoBehaviour {

	public event Action EntityClicked;

	public VRInput m_VRInput;
	public VRInteractiveItem m_InteractiveItem;


	private bool m_GazeOver;

	private void OnEnable() {
		m_VRInput.OnDown += HandleDown;
		m_VRInput.OnUp += HandleUp;

		m_InteractiveItem.OnOver += HandleOver;
		m_InteractiveItem.OnOut += HandleOut;
	}

	private void OnDisable() {
		m_VRInput.OnDown -= HandleDown;
		m_VRInput.OnUp -= HandleUp;

		m_InteractiveItem.OnOver -= HandleOver;
		m_InteractiveItem.OnOut -= HandleOut;
	}

	private void HandleDown() {
	}

	private void HandleUp() {
		if (m_GazeOver) {
			if (EntityClicked != null) {
				EntityClicked ();
			}
		}
	}

	private void HandleOver() {
		m_GazeOver = true;

		// Play 'on over' clip using audio source
	}

	private void HandleOut() {
		m_GazeOver = false;

		//Stop the clip
	}
}
