using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MechMenuController : MonoBehaviour {
	public Text weaponText;
	private int weaponIndex;
	private List<Fire> mechs;
	private List<Weapon> weapons;

	// Use this for initialization
	void Start () {
		GameObject data = GameObject.Find("DataHolder");
		PersistentData persistantData = data.GetComponent<PersistentData>();
		mechs = persistantData.mechs;
		weapons = persistantData.weapons;

		weaponText.text = mechs[0].getWeapon().getName();

		int i = 0;
		foreach (Weapon weapon in weapons) {
			if (weapon.getName().Equals(weaponText.text)) {
				weaponIndex = i;
			}
			i++;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void weaponUp() {
		this.weaponIndex++;
		if (this.weaponIndex == weapons.Count) {
			this.weaponIndex = 0;
		}

		weaponText.text = weapons[this.weaponIndex].getName();
	}

	public void weaponDown() {
		this.weaponIndex--;
		if (this.weaponIndex < 0) {
			this.weaponIndex = weapons.Count - 1;
		}

		weaponText.text = weapons[this.weaponIndex].getName();
	}

	public void setMechWeapon() {
		mechs[0].setWeapon(weapons[this.weaponIndex]);
	}
}
