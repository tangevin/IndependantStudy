using UnityEngine;
using System.Collections;

public class PlaceWall : MonoBehaviour {
	public GameObject wallNode;
	public GameObject wall;

	void OnMouseUp() {
		Vector3 mousePos = Input.mousePosition;
		int xPos = (int)(mousePos.x / 720 * 900 / 30) * 30 - 450 + 15;
		int zPos = (int)(mousePos.y / 480 * 600 / 30) * 30 - 300 + 15;
		
		Vector3 spawnPosition = new Vector3(xPos, wallNode.transform.position.y, zPos);
		Quaternion spawnRotation = Quaternion.identity;
		
		Instantiate(wallNode, spawnPosition, spawnRotation);
	}
}
