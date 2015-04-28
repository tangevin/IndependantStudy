using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PersistentData : MonoBehaviour {
	public List<Weapon> weapons {get; set;}
	public List<Mech> mechs {get; set;}
	public Fire selectedMech;
	public int resources {get; set;}
	public int health {get; set;}

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this.gameObject);
		Debug.Log("STARTED PERSISTENT DATA");
		if(weapons == null) {
			weapons = new List<Weapon>();
			weapons.Add(new WeaponGat());
			weapons.Add(new WeaponSniper());
		}
		if (mechs == null) {
			mechs = new List<Mech>();
		}
		if(health == 0) {
			Debug.Log("Set Health");
			health = 20;
		}
		if(resources == 0) {
			Debug.Log("Set Resources");
			resources = 300;
		}
	}

	public int getResources() {
		return this.resources;
	}

	public int getHealth() {
		return this.health;
	}
}
