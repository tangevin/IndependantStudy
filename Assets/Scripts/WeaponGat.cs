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
	
	// Use this for initialization
	void Start () {
		this.damage = 10;
		this.range = 200.0f;
		this.fireRate = 0.125f;
		this.ammoCapacity = 5;
		this.reloadSpeed = 5;
		this.name = "Gattling";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}