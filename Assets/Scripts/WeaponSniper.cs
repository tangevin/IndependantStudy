using UnityEngine;
using System.Collections;

public class WeaponSniper : Weapon {

	public WeaponSniper()
	{
		this.damage = 100;
		this.range = 400.0f;
		this.fireRate = 1.25f;
		this.ammoCapacity = 5;
		this.reloadSpeed = 5;
		this.name = "Sniper";
	}

	// Use this for initialization
	void Start () {
		this.damage = 100;
		this.range = 400.0f;
		this.fireRate = 1.25f;
		this.ammoCapacity = 5;
		this.reloadSpeed = 5;
		this.name = "Sniper";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
