using UnityEngine;
using System.Collections;

public class PlaceWall : MonoBehaviour {
	public GameObject wallNode;
	public GameObject wall;
	private Ground curMap;

	void OnMouseDown() {
		curMap = GameObject.Find("Ground").GetComponent<Ground>();
		Vector3 mousePos = Input.mousePosition;

		int xPos = (int)(mousePos.x / 720 * 900 / 30) * 30 - 450 + 15;
		int zPos = (int)(mousePos.y / 480 * 600 / 30) * 30 - 300 + 15;

		int widthPos = (int)(mousePos.x / 720 * 900 / 30);
		int heightPos = (int)(mousePos.y / 480 * 600 / 30);

		if (!curMap.hasWall(widthPos, heightPos)) {
			Vector3 spawnPosition = new Vector3(xPos, wallNode.transform.position.y, zPos);
			Quaternion spawnRotation = Quaternion.identity;
			
			Instantiate(wallNode, spawnPosition, spawnRotation);

			curMap.addWall(widthPos, heightPos);

			if (widthPos - 1 >= 0) {
				checkLeftForWall(widthPos, heightPos, xPos, zPos);
			}
			if (widthPos + 1 < curMap.GetComponent<Ground>().getWidth()) {
				checkRightForWall(widthPos, heightPos, xPos, zPos);
			}
			if (heightPos - 1 >= 0) {
				checkDownForWall(widthPos, heightPos, xPos, zPos);
			}
			if (heightPos + 1 < curMap.GetComponent<Ground>().getHeight()) {
				checkUpForWall(widthPos, heightPos, xPos, zPos);
			}
		}
	}

	// Need to rotate wall
	private void checkUpForWall(int widthPos, int heightPos, int x, int z) {
		if (curMap.hasWall(widthPos, heightPos + 1)) {
			Vector3 wallPosition = new Vector3(x, wall.transform.position.y, z + 15);
			Quaternion wallRotation = Quaternion.Euler(new Vector3(0, 90, 0));
			
			Instantiate(wall, wallPosition, wallRotation);
		}
	}

	// Need to rotate wall
	private void checkDownForWall(int widthPos, int heightPos, int x, int z) {
		if (curMap.hasWall(widthPos, heightPos - 1)) {
			Vector3 wallPosition = new Vector3(x, wall.transform.position.y, z - 15);
			Quaternion wallRotation = Quaternion.Euler(new Vector3(0, 90, 0));
			
			Instantiate(wall, wallPosition, wallRotation);
		}
	}

	private void checkLeftForWall(int widthPos, int heightPos, int x, int z) {
		if (curMap.hasWall(widthPos - 1, heightPos)) {
			Vector3 wallPosition = new Vector3(x - 15, wall.transform.position.y, z);
			Quaternion wallRotation = Quaternion.identity;
			
			Instantiate(wall, wallPosition, wallRotation);
		}
	}

	private void checkRightForWall(int widthPos, int heightPos, int x, int z) {
		if (curMap.hasWall(widthPos + 1, heightPos)) {
			Vector3 wallPosition = new Vector3(x + 15, wall.transform.position.y, z);
			Quaternion wallRotation = Quaternion.identity;
			
			Instantiate(wall, wallPosition, wallRotation);
		}
	}
}
