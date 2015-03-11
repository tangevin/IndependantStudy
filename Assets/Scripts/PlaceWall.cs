using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlaceWall : MonoBehaviour {
	public GameObject wallNode;
	public GameObject wall;
	private Ground curMap;
	private List<GameObject> wallsToPlace;

	void OnMouseDown() {
		wallsToPlace = new List<GameObject>();
		curMap = GameObject.Find("Ground").GetComponent<Ground>();
		Vector3 mousePos = Input.mousePosition;

		int xPos = (int)(mousePos.x / 720 * 900 / 30) * 30 - 450 + 15;
		int zPos = (int)(mousePos.y / 480 * 600 / 30) * 30 - 300 + 15;

		int widthPos = (int)(mousePos.x / 720 * 900 / 30);
		int heightPos = (int)(mousePos.y / 480 * 600 / 30);

		if (!curMap.hasWall(widthPos, heightPos)) {
			Vector3 spawnPosition = new Vector3(xPos, wallNode.transform.position.y, zPos);
			Quaternion spawnRotation = Quaternion.identity;
			
			wallsToPlace.Add((GameObject)Instantiate(wallNode, spawnPosition, spawnRotation));

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

			curMap.setLastWallsPlaced(wallsToPlace, new int[2] {widthPos, heightPos});
			GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
			foreach (GameObject obj in enemies) {
				obj.GetComponent<Enemy>().FindPath(obj.transform.position, GameObject.FindGameObjectWithTag("Base").transform.position);
			}
		}
	}

	// Need to rotate wall
	private void checkUpForWall(int widthPos, int heightPos, int x, int z) {
		if (curMap.hasWall(widthPos, heightPos + 1)) {
			Vector3 wallPosition = new Vector3(x, wall.transform.position.y, z + 15);
			Quaternion wallRotation = Quaternion.Euler(new Vector3(0, 90, 0));
			
			wallsToPlace.Add((GameObject)Instantiate(wall, wallPosition, wallRotation));
		}
	}

	// Need to rotate wall
	private void checkDownForWall(int widthPos, int heightPos, int x, int z) {
		if (curMap.hasWall(widthPos, heightPos - 1)) {
			Vector3 wallPosition = new Vector3(x, wall.transform.position.y, z - 15);
			Quaternion wallRotation = Quaternion.Euler(new Vector3(0, 90, 0));
			
			wallsToPlace.Add((GameObject)Instantiate(wall, wallPosition, wallRotation));
		}
	}

	private void checkLeftForWall(int widthPos, int heightPos, int x, int z) {
		if (curMap.hasWall(widthPos - 1, heightPos)) {
			Vector3 wallPosition = new Vector3(x - 15, wall.transform.position.y, z);
			Quaternion wallRotation = Quaternion.identity;
			
			wallsToPlace.Add((GameObject)Instantiate(wall, wallPosition, wallRotation));
		}
	}

	private void checkRightForWall(int widthPos, int heightPos, int x, int z) {
		if (curMap.hasWall(widthPos + 1, heightPos)) {
			Vector3 wallPosition = new Vector3(x + 15, wall.transform.position.y, z);
			Quaternion wallRotation = Quaternion.identity;
			
			wallsToPlace.Add((GameObject)Instantiate(wall, wallPosition, wallRotation));
		}
	}

	private bool checkForPath() {
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		Debug.Log(enemies.Length);
		GameObject target = GameObject.FindGameObjectWithTag("Base");
		Vector3 endPosition = target.transform.position;

		foreach (GameObject obj in enemies) {
			Enemy enemy = obj.GetComponent<Enemy>();
			enemy.FindPath(enemy.transform.position, endPosition);
			Debug.Log("Current enemy path: " + enemy.Path.Count);
			if (!enemy.hasPath()) {
				Debug.Log("Enemy at " + enemy.transform.position + " does not have a path.");
				return false;
			}
		}

		return true;
	}
}
