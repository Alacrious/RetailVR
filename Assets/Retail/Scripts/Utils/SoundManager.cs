using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public static SoundManager _instance = null;

	void Awake () {
		if (_instance != null && _instance != this) {
			Destroy (gameObject);
			return;
		} else {
			_instance = this;
		}

		DontDestroyOnLoad (gameObject);
	}

	public static SoundManager GetInstance() {
		return _instance;
	}
}
