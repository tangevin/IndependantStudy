using UnityEngine;
using System.Collections;

public class Enemy : Pathfinding {

	private int health = 100;

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
		if (!hasPath())
		{
			Debug.Log("Enemy doesnt have path");
			ground.removeLastWallsPlaced();
			FindPath(this.transform.position, endPosition);
		}
		
		Move();

		if (Vector3.Distance(this.transform.position, endPosition) <= 5) {
			GameController.health--;
			Destroy(this.gameObject);
		}
	}

	public bool hasPath()
	{
		return Path.Count > 0;
	}

	public int damage(int dam)
	{
		this.health -= dam;

		if (this.health <= 0)
		{
			GameObject.Destroy(this.gameObject);
		}

		return this.health;
	}

	public int getHealth()
	{
		return this.health;
	}
}
