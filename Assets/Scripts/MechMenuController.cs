using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MechMenuController : MonoBehaviour {
	public Text weaponText;
	private int weaponIndex;

	public Text mechText;
	private int mechIndex;

	private List<Mech> mechs;
	private List<Weapon> weapons;
	private Mech selectedMech;

	// Use this for initialization
	void Start () {
		GameObject data = GameObject.Find("DataHolder");
		PersistentData persistantData = data.GetComponent<PersistentData>();
		mechs = persistantData.mechs;
		weapons = persistantData.weapons;
		this.mechIndex = 0;
		selectedMech = mechs[mechIndex];


		weaponText.text = selectedMech.getWeapon().getName();


		int i = 0;
		foreach (Weapon weapon in weapons) {
			if (weapon.getName().Equals(weaponText.text)) {
				weaponIndex = i;
			}
			i++;
		}

		mechText.text = this.mechIndex.ToString();
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
		selectedMech.setWeapon(weapons[this.weaponIndex]);
	}

	
	public void mechUp(){
		this.mechIndex++;
		if (this.mechIndex == mechs.Count) {
			this.mechIndex = 0;
		}

		setMechWeapon();
		
		this.selectedMech = mechs[mechIndex];
		mechText.text = this.mechIndex.ToString();

		if (!(this.selectedMech.getWeapon().getName().Equals(weapons[this.weaponIndex].getName())))
		{
			if (this.selectedMech.getWeapon().getName().Equals("Gattling"))
			{
				this.weaponIndex = 0;
			}
			else
			{
				this.weaponIndex = 1;
			}
			this.weaponText.text = this.weapons[this.weaponIndex].getName();
		}
	}

	public void mechDown() {
		this.mechIndex--;
		if (this.mechIndex < 0) {
			this.mechIndex = mechs.Count - 1;
		}
		
		this.selectedMech = mechs[mechIndex];

		setMechWeapon();
		mechText.text = this.mechIndex.ToString();

		if (!(this.selectedMech.getWeapon().getName().Equals(weapons[this.weaponIndex].getName())))
		{
			if (this.selectedMech.getWeapon().getName().Equals("Gattling"))
			{
				this.weaponIndex = 0;
			}
			else
			{
				this.weaponIndex = 1;
			}
			this.weaponText.text = this.weapons[this.weaponIndex].getName();
		}
	}
}
