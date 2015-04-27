using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject enemy;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public int waves;
	private bool startWave = false;
	private bool wavesStarted = false;

	public Button startButton;
	public Button mechButton;
	public Button pilotButton;

	public Text WaveNumberText;
	public Text EnemiesRemainingText;
	public Text ResourcesText;
	public Text HealthText;

	private GameObject data;
	private PersistentData persistantData;
	
	void Start() {
		data = GameObject.Find("DataHolder");
		persistantData = data.GetComponent<PersistentData>();

		HealthText.text = persistantData.health.ToString();
		if(!Application.loadedLevelName.StartsWith("Tutorial")) {
			ResourcesText.text = persistantData.resources.ToString();
		}
	}

	void Update() {
		if (startWave == true && wavesStarted == false) {
			wavesStarted = true;
			GameObject.FindGameObjectWithTag("Ground").GetComponent<HighlightTile>().setWaveStarted(true);
			StartCoroutine(SpawnEnemies());
		}

		HealthText.text = persistantData.health.ToString();

		if (!Application.loadedLevelName.StartsWith("Tutorial")) {
			EnemiesRemainingText.text = GameObject.FindGameObjectsWithTag("Enemy").Length.ToString();
			ResourcesText.text = persistantData.resources.ToString();
		}
	}
	
	IEnumerator SpawnEnemies() {
		yield return new WaitForSeconds(startWait);
		int curWave = 0;
		WaveNumberText.text = curWave.ToString();
		
		while(curWave++ < waves) {
			for(int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3(spawnValues.x, spawnValues.y, Random.Range(-spawnValues.z, spawnValues.z));
				Quaternion spawnRotation = enemy.transform.rotation;
				
				Instantiate(enemy, spawnPosition, spawnRotation);
				
				yield return new WaitForSeconds(spawnWait);
			}
			
			yield return new WaitForSeconds(waveWait);
		}

		startWave = false;
		wavesStarted = false;
		startButton.interactable = true;
		mechButton.interactable = true;
		pilotButton.interactable = true;
		GameObject.FindGameObjectWithTag("Ground").GetComponent<HighlightTile>().setWaveStarted(false);
	}

	public void StartWave() {
		startWave = true;

		foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Tower"))
		{
			MechMove mech = obj.GetComponent<MechMove>();
			mech.unselect();
			mech.setEndPos(mech.transform.position);
		}

		GameObject.FindGameObjectWithTag("Ground").GetComponent<Ground>().setPlacingWalls(true);
	}

	public void unselectMechs() {
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Tower"))
		{
			MechMove mech = obj.GetComponent<MechMove>();
			mech.unselect();
			mech.setEndPos(mech.transform.position);
		}

		GameObject.FindGameObjectWithTag("Ground").GetComponent<HighlightTile>().mechSelected(false);
		GameObject.FindGameObjectWithTag("Ground").GetComponent<Ground>().setPlacingWalls(true);
	}
}
