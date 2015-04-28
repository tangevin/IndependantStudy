using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DialogueHandler : MonoBehaviour {
	public List<Text> messages;
	public GameObject dialoguePanel;
	private int curMessage = 0;

	void Start() {
		foreach (Text text in messages) {
			text.enabled = false;
		}
		messages[0].enabled = true;
	}

	public void nextMessage() {
		if (!dialoguePanel.activeSelf) {
			dialoguePanel.SetActive(true);
		}

		messages[curMessage].enabled = false;
		curMessage++;

		if (curMessage < messages.Count) {
			messages[curMessage].enabled = true;
		}
		else {
			dialoguePanel.SetActive(false);
		}
	}

	public void hideDialoguePanel() {
		dialoguePanel.SetActive(false);
	}

	public void displayDialoguePanel() {
		dialoguePanel.SetActive(true);
	}

	public int getCurMessage() {
		return this.curMessage;
	}
}
