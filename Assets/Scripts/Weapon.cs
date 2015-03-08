using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour {
	private int damage;
	private int range;
	private int fireRate;
	private int ammoCapacity;
	private int reloadSpeed;

	public int getDamage() {
		return this.damage;
	}

	public int getRange() {
		return this.range;
	}

	public int getFireRate() {
		return this.fireRate;
	}

	public int getAmmoCapacity() {
		return this.ammoCapacity;
	}

	public int getReloadSpeed() {
		return this.reloadSpeed;
	}
}
