using UnityEngine;
using System.Collections;

public class HighlightTile : MonoBehaviour {
	public GameObject highlight;
	private GameObject currentlyHighlighted = null;
	private Ground curMap;

	void Start() {
		curMap = this.GetComponent<Ground>();
	}

	void OnMouseOver()
	{
		Vector3 mousePos = Input.mousePosition;
		int xPos = (int)(mousePos.x / 720 * 900 / 30) * 30 - 450 + 15;
		int zPos = (int)(mousePos.y / 480 * 600 / 30) * 30 - 300 + 15;

		int widthPos = (int)(mousePos.x / 720 * 900 / 30);
		int heightPos = (int)(mousePos.y / 480 * 600 / 30);

		if (!curMap.hasWall(widthPos, heightPos)) {
			Vector3 spawnPosition = new Vector3(xPos, 1, zPos);
			Quaternion spawnRotation = Quaternion.identity;

			if (currentlyHighlighted != null) {
				Destroy(currentlyHighlighted);
			}

			currentlyHighlighted = (GameObject)Instantiate(highlight, spawnPosition, spawnRotation);
		}
	}
}
