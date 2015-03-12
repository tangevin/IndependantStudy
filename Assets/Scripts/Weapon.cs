using UnityEngine;
using System.Collections;

public abstract class Weapon {
	protected int damage;
	protected float range;
	protected float fireRate;
	protected float speed;
	protected int ammoCapacity;
	protected float reloadSpeed;
	protected string name;

	public int getDamage() {
		return this.damage;
	}

	public float getRange() {
		return this.range;
	}

	public float getFireRate() {
		return this.fireRate;
	}

	public int getAmmoCapacity() {
		return this.ammoCapacity;
	}

	public float getReloadSpeed() {
		return this.reloadSpeed;
	}

	public string getName() {
		return this.name;
	}

	public float getSpeed() {
		return this.speed;
	}
}
