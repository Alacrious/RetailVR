using System;
using System.Collections;
using Solutionario.Base;

namespace Solutionario.User {
	/**
	 * User's Cart which hold the selected products
	 * and cart related logic.
	 */ 
	public class UserCart {

		private static UserCart instance = null;

		private UserCart () {
		}

		public static UserCart Instance {
			get {
				if (instance == null) {
					instance = new UserCart ();
				}
				return instance;
			}
		}

		private ArrayList _Products;

		public void StartSession () {
			if (_Products == null) {
				_Products = new ArrayList ();
			}
			//New session new cart
			_Products.Clear ();
		}

		public void AddToCart (Product product) {
			_Products.Add (product);
		}

		public void RemoveFromCart (Product product) {
			_Products.Remove (product);
		}

		public void StopSession () {
			_Products.Clear ();
		}

		public ArrayList GetProducts () {
			return _Products;
		}

	}
}
