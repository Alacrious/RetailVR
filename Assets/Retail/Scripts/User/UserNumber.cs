using UnityEngine;
using System.Collections;

namespace Solutionario.User {
	public class UserNumber {

		public static string Number {get; set;}

		/**
		 * Check the sanity of the user's number.
		 */
		public static bool CheckSanity () {
			if (Number.Length < 11)
				return false;
			return true;
		}
	}
}