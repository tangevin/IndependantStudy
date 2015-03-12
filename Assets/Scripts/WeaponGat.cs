using UnityEngine;
using System.Collections;

public class WeaponGat : Weapon {

	public WeaponGat ()
	{
		this.damage = 10;
		this.range = 200.0f;
		this.fireRate = 0.12f;
		this.ammoCapacity = 5;
		this.reloadSpeed = 5;
		this.name = "Gattling";
	}

	void Start() {

	}

	void Update() {

	}
}