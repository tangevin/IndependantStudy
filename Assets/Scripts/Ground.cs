using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour {
	public GameObject bottomLeft;
	public GameObject topRight;
	private bool[,] walls;

	// Use this for initialization
	void Start () {
		int width = getWidth();
		int height = getHeight();

		this.walls = new bool[width, height];

		for (int i = 0; i < width; i++) {
			for (int j = 0; j < height; j++) {
				this.walls[i, j] = false;
			}
		}
	}
	
	public void addWall(int x, int y) {
		this.walls[x, y] = true;
	}

	public bool hasWall(int x, int y) {
		return this.walls[x, y];
	}

	public int getWidth() {
		return (int)(topRight.transform.position.x - bottomLeft.transform.position.x) / 30;
	}

	public int getHeight() {
		return (int)(topRight.transform.position.z - bottomLeft.transform.position.z) / 30;
	}
}
