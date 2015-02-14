using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {
	public float fireRange;

	void Start() {
		transform.GetComponent<SphereCollider>().radius = fireRange;
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Enemy") {
			Destroy(other.gameObject);
		}
	}
}
