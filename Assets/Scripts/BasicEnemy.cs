using UnityEngine;
using System.Collections;

public class BasicEnemy : Pathfinding {
	private GameObject target;
	private Vector3 endPosition;

	void Start()
	{
		target = GameObject.FindGameObjectWithTag("Base");
		endPosition = target.transform.position;
		FindPath(this.transform.position, endPosition);
	}

	void Update ()
	{
		//If i hit the P key i will get a path from my position to my end position
		//if (Input.GetKeyDown(KeyCode.P))
		//{
		//	FindPath(transform.position, endPosition);
		//}
		//If path count is bigger than zero then call a move method
		if (Path.Count > 0)
		{
			Move();
		}
	}
}
