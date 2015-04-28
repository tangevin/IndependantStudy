using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextFlash : MonoBehaviour {
	public Text text;
	int maxA = 150;
	int minA = 60;
	bool increase = false;
	Color color;

	// Use this for initialization
	void Start () {
		this.color = text.color;
		this.color.a = maxA;
		text.color = this.color;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.color.a >= maxA) {
			this.increase = false;
		}
		else if (this.color.a <= minA) {
			this.increase = true;
		}

		if (this.increase) {
			this.color.a += 5f;
			text.color = new Color(this.color.r, this.color.g, this.color.b, this.color.a/255);
		}
		else {
			this.color.a -= 5f;
			text.color = new Color(this.color.r, this.color.g, this.color.b, this.color.a/255);
		}
	}
}
