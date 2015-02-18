using UnityEngine;
using System.Collections;

public class MechMenuArrow : MonoBehaviour {

	public Sprite idle;
	public Sprite hover;
	public Sprite select;

	private SpriteRenderer sr;
	private bool down;

	// Use this for initialization
	void Start () {
		sr = gameObject.GetComponent<SpriteRenderer>();
		down = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver() 
	{
		if (!down)
			sr.sprite = hover;
	}

	void OnMouseExit()
	{
		sr.sprite = idle;
	}

	void OnMouseDown()
	{
		down = true;
		sr.sprite = select;
	}

	void OnMouseUp()
	{
		down = false;
	}
}