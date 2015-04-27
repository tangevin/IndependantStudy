using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Fire : MonoBehaviour {
	public Weapon weapon;
	public GameObject bullet;

	private List<Enemy> enemyList = new List<Enemy>();
	private float fireTimer;

	private Mech mech;

	void Start() {
		GameController controller = GameObject.Find("Game Controller").GetComponent<GameController>();

		GameObject data = GameObject.Find("DataHolder");
		PersistentData persistantData = data.GetComponent<PersistentData>();

		mech = this.GetComponent<Mech>();

		weapon = persistantData.mechs[mech.id - 1].getWeapon();
		fireTimer = weapon.getFireRate();
		transform.GetComponent<SphereCollider>().radius = weapon.getRange();

		Debug.Log("Weapon:" + weapon.getName() + " in mech " + mech.id);
	}

	void Update() {
		Debug.Log("Weapon:" + weapon.getName() + " in mech " + mech.id);
		for (int i = enemyList.Count - 1; i >= 0; i--)
		{
			if (enemyList[i].getHealth() <= 0)
			{
				enemyList.RemoveAt(i);
			}
		}

		if (fireTimer < 0 && !GetComponent<MechMove>().isMoving())
		{
			shoot();
			fireTimer = weapon.getFireRate();
		}
		else
		{
			fireTimer -= Time.fixedDeltaTime;
		}
	}

	void shoot()
	{
		if (enemyList.Count > 0)
		{
			GameObject shot;
			Vector3 start = this.GetComponent<Rigidbody>().position;

			Debug.Log("Making a bullet");
			shot = Instantiate(bullet, start, this.GetComponent<Rigidbody>().rotation) as GameObject;
			if (shot)
			{
				Vector3 enemyPos = enemyList[0].GetComponent<Rigidbody>().position;
				Debug.Log("GO!");
				shot.GetComponent<Bullet>().startBullet(start, new Vector3(enemyPos.x + 20, enemyPos.y, enemyPos.z), weapon.getSpeed());
			}


			Debug.Log(weapon.getName() + " Fire!!");
			if (enemyList[0].damage(weapon.getDamage()) <= 0)
			{
				enemyList.RemoveAt(0);
			}
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

	public List<Enemy> getEnemyList() {
		return enemyList;
	}

	public Weapon getWeapon() {
		return this.weapon;
	}

	public void setWeapon(Weapon weapon) {
		this.weapon = weapon;
	}
}
