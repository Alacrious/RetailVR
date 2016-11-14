using System;
using UnityEngine;
using Solutionario.Base;
using Solutionario.User;


namespace Solutionario.User {
	public class UserData {

		private static UserData instance = null;

		private UserData () {
			m_UserCart = UserCart.Instance;
		}

		public static UserData Instance {
			get {
				if (instance == null) {
					instance = new UserData ();
				}
				return instance;
			}
		}

		/******************* Properties *****************************/
		public Solutionario.Base.Environment CurrentEnvironment {
			get;
			set;
		}

		public Product CurrentProduct { get; set; }

		private UserCart m_UserCart;
		//private UserNumber m_UserNumber;

		public void StartSession () {
			m_UserCart.StartSession ();
		}

		public void RestartSession () {
			this.StopSession ();
			this.StartSession ();
		}

		public void StopSession () {
			m_UserCart.StopSession ();
			CurrentEnvironment = null;
			CurrentProduct = null;
			UserNumber.Number = "";
		}

	}
}
