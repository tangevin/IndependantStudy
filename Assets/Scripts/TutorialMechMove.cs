using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialMechMove : MonoBehaviour {
	public GameObject dialoguePanel;
	private bool dialogueDisplayed = true;
	private DialogueHandler dialogueHandler;

	public GameObject stuckMech;
	private MechMove stuckMechMovement;
	public GameObject stuckMechTarget;
	private bool stuckMechAtTarget = false;

	public GameObject mech2;
	private MechMove mech2Movement;
	public GameObject mech2Start;
	private bool mech2AtTarget = false;
	private bool mech2NearStuckMech = false;

	private bool waiting = false;
	private int curWaitTime = 0;
	private int waitTime = 90;

	public Text healthTitle;
	public Text healthNumber;

	private bool waveStart = false;
	private bool wavesFinished = false;

	public int waves;
	public int hazardCount;
	public Vector3 spawnValues;
	public Enemy enemy;
	public float spawnWait;
	public float waveWait;

	// Use this for initialization
	void Start () {
		dialogueHandler = dialoguePanel.GetComponent<DialogueHandler>();
		stuckMechMovement = stuckMech.GetComponent<MechMove>();
		stuckMechMovement.setInDialogue(true);
		mech2Movement = mech2.GetComponent<MechMove>();
		mech2Movement.setInDialogue(true);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space") && dialogueDisplayed) {
			if (dialogueHandler.getCurMessage() == 1) {
				dialogueHandler.hideDialoguePanel();
				stuckMechMovement.setEndPos(stuckMechTarget.transform.position);
				dialogueDisplayed = false;
			}
			else if(dialogueHandler.getCurMessage() == 6) {
				dialogueHandler.hideDialoguePanel();
				this.waiting = true;
			}
			else if(dialogueHandler.getCurMessage() == 11) {
				dialogueHandler.hideDialoguePanel();
				mech2Movement.setEndPos(mech2Start.transform.position);
				dialogueDisplayed = false;
			}
			else if(dialogueHandler.getCurMessage() == 13) {
				dialogueHandler.hideDialoguePanel();
				mech2Movement.setInDialogue(false);
				dialogueDisplayed = false;
			}
			else if(dialogueHandler.getCurMessage() == 18) {
				dialogueHandler.hideDialoguePanel();
				mech2Movement.setInDialogue(false);
				healthTitle.enabled = true;
				healthNumber.enabled = true;
				dialogueDisplayed = false;
				waveStart = true;
			}
			else {
				dialogueHandler.nextMessage();
			}
		}

		if (Vector3.Distance(stuckMech.transform.position, stuckMechTarget.transform.position) < 10 && !stuckMechAtTarget) {
			dialogueHandler.nextMessage();
			stuckMechAtTarget = true;
			dialogueDisplayed = true;
		}

		if (Vector3.Distance(mech2.transform.position, mech2Start.transform.position) < 10 && !mech2AtTarget) {
			dialogueHandler.nextMessage();
			mech2AtTarget = true;
			dialogueDisplayed = true;
		}

		if (Vector3.Distance(mech2.transform.position, stuckMech.transform.position) < 100 && !mech2NearStuckMech) {
			mech2Movement.setEndPos(mech2.transform.position);
			dialogueHandler.nextMessage();
			mech2NearStuckMech = true;
			dialogueDisplayed = true;
			mech2Movement.setInDialogue(true);
			mech2Movement.unselect();
		}

		if (waiting) {
			curWaitTime++;
		}
		if (curWaitTime == waitTime) {
			curWaitTime = 0;
			waiting = false;
			dialogueDisplayed = true;
			dialogueHandler.nextMessage();
		}

		if (waveStart) {
			waveStart = false;
			StartCoroutine(SpawnEnemies());
		}

		if (wavesFinished) {
			if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0) {
				wavesFinished = false;
				dialogueHandler.nextMessage();
				dialogueDisplayed = true;
				mech2Movement.setInDialogue(true);
			}
		}
	}

	IEnumerator SpawnEnemies() {
		int curWave = 0;
		
		while(curWave++ < waves) {
			for(int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = new Vector3(spawnValues.x, spawnValues.y, Random.Range(-spawnValues.z, spawnValues.z));
				Quaternion spawnRotation = enemy.transform.rotation;
				
				Instantiate(enemy, spawnPosition, spawnRotation);
				
				yield return new WaitForSeconds(spawnWait);
			}
			
			yield return new WaitForSeconds(waveWait);
		}

		wavesFinished = true;
	}
}
