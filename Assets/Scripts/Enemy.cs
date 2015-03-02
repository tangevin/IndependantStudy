using UnityEngine;
using System.Collections;

public class Enemy : Pathfinding {
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
		FindPath(this.transform.position, endPosition);
		if (hasPath())
		{
			Move();
		}
	}

	public bool hasPath()
	{
		return Path.Count > 0;
	}
}
