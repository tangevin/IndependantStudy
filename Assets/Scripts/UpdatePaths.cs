using UnityEngine;
using System.Collections;

public class UpdatePaths : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		foreach (GameObject obj in enemies) {
			Debug.Log("updating enemy path");
			obj.GetComponent<Enemy>().FindPath(obj.transform.position, GameObject.FindGameObjectWithTag("Base").transform.position);
		}
		
		GameObject[] mechs = GameObject.FindGameObjectsWithTag("Tower");
		foreach (GameObject obj in mechs) {
			obj.GetComponent<MechMove>().FindPath(obj.transform.position, obj.GetComponent<MechMove>().getEndPos());
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
