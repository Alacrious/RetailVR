using System;
using UnityEngine;

namespace Solutionario.Base {
	/**
	 * Data structure for the Products.
	 */
	public class Product {

		public string _ID { get; set; }

		public string _Name { get; set; }

		public float _Price { get; set; }

		public string _Color { get; set; }

		public string _Material { get; set; }

		public string _Size { get; set; }

		public string _Origin { get; set; }

		public Sprite[]  _Sprites;

		private Product(string id) {
			_ID = id;
		}

		//TODO Move this to generic class. Either a database
		// or server call.
		public static Product GetProduct (string id) {
			return new Product (id);
		}

		public static Product GetSomeProduct () {
			Product p = new Product ("Chair");
			p._Name = "SILLA TELA BLANCA";
			p._Price = 89.99f;
			p._Color = "Star Dust";
			p._Material = "Tela";
			p._Size = "42x42x85";
			p._Origin = "India";
			p._Sprites = Resources.LoadAll<Sprite>("Products/Chair");
			return p;
		}

		public int NoOfSprites () {
			return _Sprites.Length;
		}
	}
}
