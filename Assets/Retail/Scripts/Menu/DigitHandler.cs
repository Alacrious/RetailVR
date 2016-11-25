using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using VRStandardAssets.Utils;
using Solutionario.User;

public class DigitHandler : MonoBehaviour {

	[SerializeField] private Text m_Text;
	// All the digits from 0-9 in that order.
	[SerializeField] private VRInteractiveItem m_Digit;
	// Submit button on while giving the input.
	[SerializeField] private int m_Value;

	private void OnEnable () {
		m_Digit.OnClick += HandleDigit;
	}

	private void OnDisable () {
		m_Digit.OnClick -= HandleDigit;
	}

	private void HandleDigit () {
		//Clear the text
		if(m_Value == -1) {
			m_Text.text = "";
		} else { // Append the number to the text
			m_Text.text += "" + m_Value;	
		}

		UserNumber.Number = m_Text.text;
	}
}
