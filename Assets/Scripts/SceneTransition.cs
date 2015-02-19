using UnityEngine;
using System.Collections;

public class SceneTransition : MonoBehaviour {

	public void sceneTransition(string sceneName) {
		Application.LoadLevel(sceneName);
	}
}
