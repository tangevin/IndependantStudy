using UnityEngine;
using System.Collections;

public class WeaponSniper : Weapon {

	public WeaponSniper()
	{
		this.damage = 100;
		this.range = 400.0f;
		this.fireRate = 2f;
		this.speed = 1.0f;
		this.ammoCapacity = 5;
		this.reloadSpeed = 5;
		this.name = "Sniper";
	}

	void Start() {

	}

	void Update() {

	}
}
