using UnityEngine;
using System.Collections;

public class WeaponSwitch : MonoBehaviour {
	public void test(){

		if (weapon.getName().Equals("Gattling"))
		{
			weapon = new WeaponSniper();
		}
		else
		{
			weapon = new WeaponGat();
		}
		fireTimer = weapon.getFireRate();
		transform.GetComponent<SphereCollider>().radius = weapon.getRange();
	}
}
