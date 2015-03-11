using UnityEngine;
using System.Collections;

public class Enemy : Pathfinding {
	private GameObject target;
	private Vector3 endPosition;
	private Ground ground;
	
	void Start()
	{
		ground = GameObject.FindGameObjectWithTag("Ground").GetComponent<Ground>();
		target = GameObject.FindGameObjectWithTag("Base");
		endPosition = target.transform.position;
		FindPath(this.transform.position, endPosition);
	}
	
	void Update ()
	{
		FindPath(this.transform.position, endPosition);
		if (!hasPath())
		{
			ground.removeLastWallsPlaced();
			FindPath(this.transform.position, endPosition);
		}
		
		Move();
	}

	public bool hasPath()
	{
		return Path.Count > 0;
	}

	public string ToString() {
		return "Position: " + this.transform.position;
	}
}
