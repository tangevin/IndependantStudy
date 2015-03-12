using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PersistentData : MonoBehaviour {
	public List<Weapon> weapons {get; set;}
	public List<Fire> mechs {get; set;}
	public Fire selectedMech;
	private int resources;
	private int health;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this.gameObject);
		Debug.Log("in persistent data:" + mechs);
		if(weapons == null) {
			weapons = new List<Weapon>();
			weapons.Add(new WeaponGat());
			weapons.Add(new WeaponSniper());
		}
		if (mechs == null) {
			mechs = new List<Fire>();
		}
		if(health == 0) {
			health = 20;
		}
		if(resources == 0) {
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
