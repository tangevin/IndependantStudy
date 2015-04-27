using UnityEngine;
using System.Collections;

public class LoadSceneTransition : MonoBehaviour {
	public string loadLevel;

	// Use this for initialization
	void Start () {
		Application.LoadLevel(loadLevel);
	}
}
