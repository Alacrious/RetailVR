using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class EmulatedCameraMovement : MonoBehaviour {

	[SerializeField] private VRInput m_VRInput;
	[SerializeField] private float m_Angle = 20f;
	[SerializeField] private float m_Damping = 0.2f;        // Used to smooth the rotation of the transform.
	[SerializeField] private float m_SwipeTime = 1f;


	private const float k_ExpDampCoef = -20f;
	private VRInput.SwipeDirection swipeDirection = VRInput.SwipeDirection.NONE;
	private float timeLeft = 0f;

	void OnEnable () {
		m_VRInput.OnSwipe += HandleSwipe;
	}

	void OnDisable () {
		m_VRInput.OnSwipe -= HandleSwipe;
	}

	private void HandleSwipe (VRInput.SwipeDirection swipeDirection) {
		if(swipeDirection != VRInput.SwipeDirection.NONE)
			startSwipe (swipeDirection);
	}

	private void startSwipe (VRInput.SwipeDirection direction) {
		swipeDirection = direction;
		timeLeft = m_SwipeTime;
	}

	private void stopSwipe() {
		swipeDirection = VRInput.SwipeDirection.NONE;
		timeLeft = 0f;
	}

	private void Update () {
		if (swipeDirection != VRInput.SwipeDirection.NONE) {
			var eulerAngle = transform.rotation.eulerAngles;
			switch (swipeDirection) {
			case VRInput.SwipeDirection.UP:
				eulerAngle.x += m_Angle*Time.deltaTime;
				break;
			case VRInput.SwipeDirection.DOWN:
				eulerAngle.x -= m_Angle*Time.deltaTime;
				break;
			case VRInput.SwipeDirection.LEFT:
				eulerAngle.y -= m_Angle*Time.deltaTime;
				break;
			case VRInput.SwipeDirection.RIGHT:
				eulerAngle.y += m_Angle*Time.deltaTime;
				break;
			}

			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(eulerAngle), Time.deltaTime);

			timeLeft -= Time.deltaTime;
			if (timeLeft <= Mathf.Epsilon) {
				stopSwipe ();
			}
		}
	}
}
