using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Fire : MonoBehaviour {
	public float fireRange;
	public static Weapon weapon = new WeaponGat();

	private List<Enemy> enemyList;
	private float fireTimer;

	void Start() {
		enemyList = new List<Enemy>();
		fireTimer = weapon.getFireRate();
		transform.GetComponent<SphereCollider>().radius = weapon.getRange();
	}

	void Update() {
		for (int i = enemyList.Count - 1; i >= 0; i--)
		{
			if (enemyList[i].getHealth() <= 0)
			{
				enemyList.RemoveAt(i);
			}
		}

		if (fireTimer < 0)
		{
			if (enemyList.Count > 0)
			{
				Debug.Log(weapon.getName() + " Fire!!");
				if (enemyList[0].damage(weapon.getDamage()) <= 0)
				{
					enemyList.RemoveAt(0);
				}
			}
			fireTimer = weapon.getFireRate();
		}
		else
		{
			fireTimer -= Time.fixedDeltaTime;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Enemy") {
			Enemy e = other.GetComponent<Enemy>();
			enemyList.Add(e);
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Enemy") {
			Enemy e = other.GetComponent<Enemy>();

			if (enemyList.Contains(e))
			{
				enemyList.Remove(e);
			}
		}
	}
}
