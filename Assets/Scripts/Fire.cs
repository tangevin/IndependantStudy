using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Fire : MonoBehaviour {
	public Weapon weapon;
	public GameObject bullet;

	private List<Enemy> enemyList = new List<Enemy>();
	private float fireTimer;
	private int mechCount;

	void Start() {
		GameController controller = GameObject.Find("Game Controller").GetComponent<GameController>();
		controller.addMech();
		mechCount = controller.getMechCount();

		GameObject data = GameObject.Find("DataHolder");
		PersistentData persistantData = data.GetComponent<PersistentData>();

		if (persistantData.mechs.Count == 0) {
			weapon = persistantData.weapons[0];
		}
		else {
			weapon = GameObject.Find("DataHolder").GetComponent<PersistentData>().mechs[mechCount - 1].getWeapon();
		}

		fireTimer = weapon.getFireRate();
		transform.GetComponent<SphereCollider>().radius = weapon.getRange();

		Debug.Log("Weapon:" + weapon.getName());
	}

	void Update() {
		Debug.Log("Weapon:" + weapon.getName());
		for (int i = enemyList.Count - 1; i >= 0; i--)
		{
			if (enemyList[i].getHealth() <= 0)
			{
				enemyList.RemoveAt(i);
				GameObject.Find("DataHolder").GetComponent<PersistentData>().resources += 50;
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

	void Awake() {
		DontDestroyOnLoad(this.gameObject);
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
