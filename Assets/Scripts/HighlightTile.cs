using UnityEngine;
using System.Collections;

public class HighlightTile : MonoBehaviour {
	public GameObject highlight;
	private GameObject currentlyHighlighted = null;

	void OnMouseOver()
	{
		Vector3 mousePos = Input.mousePosition;
		int xPos = (int)((mousePos.x / 720 * 900 - 450) / 30) * 30 + 15;
		int zPos = (int)((mousePos.y / 480 * 600 - 300) / 30) * 30 + 15;

		Vector3 spawnPosition = new Vector3(xPos, 1, zPos);
		Quaternion spawnRotation = Quaternion.identity;

		if (currentlyHighlighted != null) {
			Destroy(currentlyHighlighted);
		}

		currentlyHighlighted = (GameObject)Instantiate(highlight, spawnPosition, spawnRotation);
	}
}
