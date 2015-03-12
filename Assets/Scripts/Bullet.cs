using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	private float speed;
	private float angle;
	private Vector3 dest;

	public void startBullet(Vector3 start, Vector3 dest, float speed)
	{
		this.speed = speed;

		this.angle = Mathf.Atan2(start.z - dest.z, start.x - dest.x);
		this.dest = dest;
	}

	// Use this for initialization
	void Start () {

	}

	void FixedUpdate () {
		Vector3 curPos = this.GetComponent<Rigidbody>().position;
		Debug.Log("angle " + angle);

		float dx = curPos.x - (Mathf.Cos (this.angle) * this.speed / Time.fixedDeltaTime); 
		float dz = curPos.z - (Mathf.Sin (this.angle) * this.speed / Time.fixedDeltaTime);
		if (dx < dest.x)
		{
			if ((angle > 0 && dz < dest.z) ||
			    (angle < 0 && dz > dest.z) )
			{
				GameObject.Destroy(this.gameObject);
			}

		}


		this.GetComponent<Rigidbody>().position = new Vector3(dx, curPos.y, dz);
	}
}
