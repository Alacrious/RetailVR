using System;
using UnityEngine.SceneManagement;
using Solutionario.User;
using UnityEngine;
using VRStandardAssets.Utils;

namespace Retail.Utils
{
	public class SceneUtils {
		public enum SceneType {
			NONE = -1,
			STARTSCENE = 0,
			ENVIRONMENTSCENE = 1,
			PRODUCTSSCENE = 2,
			CARTSCENE = 3,
		};

		public static int GetSceneLevel (SceneType sceneType) {
			return (int)sceneType;
		}

		public static string GetSceneName (SceneType sceneType) {
			switch (sceneType) {
			case SceneType.STARTSCENE:
				return "StartScene";
			case SceneType.ENVIRONMENTSCENE:
				return "EnvironmentScene";
			case SceneType.PRODUCTSSCENE:
				return "ProductsScene";
			case SceneType.CARTSCENE:
				return "CartScene";
			case SceneType.NONE:
				return "";
			default: 
				return "";	
			}
		}

		public static SceneType GetSceneType (string sceneName) {
			if (sceneName.Equals ("StartScene")) {
				return SceneType.STARTSCENE;
			} else if (sceneName.Equals ("EnvironmentScene")) {
				return SceneType.ENVIRONMENTSCENE;
			} else if (sceneName.Equals ("ProductsScene")) {
				return SceneType.PRODUCTSSCENE;
			} else if (sceneName.Equals ("CartScene")) {
				return SceneType.CARTSCENE;
			} else {
				return SceneType.NONE;
			}
		}
	}
}

