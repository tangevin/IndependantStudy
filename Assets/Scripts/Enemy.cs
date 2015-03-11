using UnityEngine;
using System.Collections;

public class Enemy : Pathfinding {

	private int health = 100;

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
