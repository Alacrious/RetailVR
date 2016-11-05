using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

namespace VRStandardAssets.Utils  {
	
	public class OnClickReaction : MonoBehaviour {

		[SerializeField] private VRInteractiveItem m_InteractiveItem;
		[SerializeField] private Renderer m_Renderer;

		private void OnEnable() {
			Debug.Log ("Enable click handling ");
			m_InteractiveItem.OnClick += HandleClick;
		}

		private void OnDisable() {
			Debug.Log ("Disable click handling ");
			m_InteractiveItem.OnClick += HandleClick;
		}

		private void HandleClick() {
			Debug.Log ("Now you can handle click");
		}

		private void Awake() {
			bool enabled = isActiveAndEnabled;
			bool gameObjectEnabled = gameObject.activeInHierarchy && gameObject.activeSelf;
			Debug.Log ("Click reaction is awake");
		}
		private void Update() {
		}
	}
}