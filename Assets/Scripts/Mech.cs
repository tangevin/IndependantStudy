using UnityEngine;
using System.Collections;

public class Mech : MonoBehaviour {
	public int id;

	private Weapon weapon;
	public GameObject bullet;

	// Use this for initialization
	void Start () {
		GameObject data = GameObject.Find("DataHolder");
		PersistentData persistantData = data.GetComponent<PersistentData>();

		if (persistantData.mechs.Count < id) {
			weapon = persistantData.weapons[0];

			persistantData.mechs.Add(this);
			Debug.Log("Added mech " + id + " to persistant data.");
		}
		else {
			weapon = persistantData.mechs[id - 1].weapon;
		}
	}

	public Weapon getWeapon() {
		return this.weapon;
	}

	public void setWeapon(Weapon newWeapon) {
		this.weapon = newWeapon;
	}
}
