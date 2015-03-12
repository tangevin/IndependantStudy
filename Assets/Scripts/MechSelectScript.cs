using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MechSelectScript : MonoBehaviour {
	public Text mechText;
	private int mechIndex;
	private List<Fire> mechs;
	private Fire curMech;

	// Use this for initialization
	void Start () {
		this.mechIndex = 0;
		GameObject data = GameObject.Find("DataHolder");
		PersistentData persistantData = data.GetComponent<PersistentData>();
		mechs = persistantData.mechs;
		curMech = mechs[mechIndex];
		
		mechText.text = this.mechIndex.ToString();
	}

	public Fire getCurrentMech() {
		return this.curMech;
	}

	public void mechUp(){
		Debug.Log("HERE!!");
		this.mechIndex++;
		if (this.mechIndex == mechs.Count) {
			this.mechIndex = 0;
		}

		this.curMech = mechs[mechIndex];
		
		mechText.text = this.mechIndex.ToString();
	}
	public void mechDown() {
		Debug.Log("YAR!");
		this.mechIndex--;
		if (this.mechIndex < 0) {
			this.mechIndex = mechs.Count - 1;
		}

		this.curMech = mechs[mechIndex];

		mechText.text = this.mechIndex.ToString();
	}
}
