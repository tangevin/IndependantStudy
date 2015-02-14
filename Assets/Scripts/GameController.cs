using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject enemy;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	
	void Start() {
		StartCoroutine(SpawnEnemies());
	}
	
	IEnumerator SpawnEnemies() {
		yield return new WaitForSeconds(startWait);
		
		while(true) {
			for(int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3(spawnValues.x, spawnValues.y, Random.Range(-spawnValues.z, spawnValues.z));
				Quaternion spawnRotation = enemy.rigidbody.rotation;
				
				Instantiate(enemy, spawnPosition, spawnRotation);
				
				yield return new WaitForSeconds(spawnWait);
			}
			
			yield return new WaitForSeconds(waveWait);
		}
	}
}
