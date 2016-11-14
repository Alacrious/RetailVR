using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using VRStandardAssets.Utils;
using Solutionario.User;

public class DoneHandler : MonoBehaviour {

	[SerializeField] private VRInteractiveItem m_InteractiveItem;

	private void OnEnable () {
		m_InteractiveItem.OnClick += HandleDone;
	}

	private void OnDisable () {
		m_InteractiveItem.OnClick -= HandleDone;
	}

	private void HandleDone () {
		if (UserNumber.CheckSanity ()) {
			//TODO Send all the data to servers about user's activities.
		} else {
			//TODO Show some popup to notify that input is wrong.
		}
	}
}
