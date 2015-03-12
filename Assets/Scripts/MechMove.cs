using UnityEngine;
using System.Collections;

public class MechMove : Pathfinding {
	
	private bool selected = false;
	private GameObject target;
	private Vector3 endPosition;
	private Ground ground;
	
	void Start()
	{
		ground = GameObject.FindGameObjectWithTag("Ground").GetComponent<Ground>();
		endPosition = this.transform.position;
	}
	
	void Update ()
	{
		if (Vector3.Distance(this.transform.position, endPosition) > 5 && hasPath()) {
			Move();
		}
	}
	
	public bool hasPath()
	{
		return Path.Count > 0;
	}

	public Vector3 getEndPos() {
		return endPosition;
	}
	
	public void setEndPos(Vector3 endPos) {
		this.endPosition = endPos;
		FindPath(this.transform.position, endPosition);
	}

	void OnMouseUp() {
		this.selected = true;
		GameObject tileObj = GameObject.FindGameObjectWithTag("Ground");
		HighlightTile tile = tileObj.GetComponent<HighlightTile>();
		tile.mechSelected(true);
		
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Tower")) 
		{
			if (!obj.Equals(this.gameObject)) {
				obj.GetComponent<MechMove>().unselect();
			}
		}

		GameObject.FindGameObjectWithTag("Ground").GetComponent<Ground>().setPlacingWalls(false);
	}
	
	public void unselect() {
		this.selected = false;
	}

	public bool isSelected() {
		return this.selected;
	}
}
