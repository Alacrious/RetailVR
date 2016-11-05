using UnityEngine;
using System.Collections;

public class EnableTest : MonoBehaviour {

	private void OnEnable() {
		Debug.Log ("EnableTest: onenable");
	}

	private void OnDisable() {
		Debug.Log ("EnableTest: ondisable");
	}

	private void Start() {
	}
}
