using UnityEngine;
using System.Collections;

public class WeaponSniper : Weapon {

	private int damage;
	private int range;
	private int fireRate;
	private int ammoCapacity;
	private int reloadSpeed;

	// Use this for initialization
	void Start () {
		this.damage = 10;
		this.range = 20;
		this.fireRate = 1;
		this.ammoCapacity = 5;
		this.reloadSpeed = 5;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
