using UnityEngine;
using System.Collections;
using System;

namespace Solutionario.Base {
	/**
 	* Data structure for the environments and its properties.
 	*/
	public class Environment {

		public enum EnvironmentType {
			LIVING,
			KITCHEN,
			BEDROOM
		}

		private string _ID { get; set; }

		private Environment (string id) {
			_ID = id;
		}

		private ArrayList products = null;

		public static Environment GetEnvironment (string id) {
			return new Environment (id);
		}


		/**
		 * Returns the products in the environment
		 */
		public ArrayList GetProductList () {
			//TODO return the product list
			//Testing purpose
			if (products == null) {
				products = new ArrayList ();
				for (int i = 0; i < 4; i++) {
					products.Add (Product.GetSomeProduct ());
				}
			}
			return products;
		}

		public Product GetNextProduct (Product product) {
			ArrayList products = GetProductList ();
			for(int i=0; i<products.Count; i++) {
				//If it is not the last product and both of them match
				if (i+1 != products.Count && ((object)product).Equals((object)products [i])) {
					return (Product)products [i + 1];
				}
			}
			return null;
		}

		public Product GetPreviousProduct (Product product) {
			ArrayList products = GetProductList ();
			for(int i=0; i<products.Count; i++) {
				//If it is not the first product and both of them match
				if (i != 0 && ((object)product).Equals((object)products [i])) {
					return (Product)products [i - 1];
				}
			}
			return null;
		}
	}
}
