using UnityEngine;
using System.Collections;

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

		public static Environment GetEnvironment (string id) {
			return new Environment (id);
		}
	}
}
