using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PersistentData : MonoBehaviour {
	public List<Weapon> weapons {get; set;}
	public List<Fire> mechs {get; set;}

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
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
