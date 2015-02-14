using UnityEngine;
using System.Collections;

public class BasicEnemyMovement : MonoBehaviour {
	public float speed;
	
	void Start() {
		rigidbody.velocity = transform.forward * speed;
	}
}
