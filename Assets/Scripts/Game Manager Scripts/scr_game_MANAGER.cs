﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_game_MANAGER : MonoBehaviour {

	public GameObject playerObject;
	scr_player_MANAGER playerScript;

	scr_textbox_manager textBoxScript;

	// Player state conditions
	bool inDialogue = false;

	// Use this for initialization
	void Start () {
		playerScript = playerObject.GetComponent<scr_player_MANAGER>();
		textBoxScript = GetComponent<scr_textbox_manager> ();
	}
	
	// Update is called once per frame
	void Update () {

	
		// If this script notices that the text box has been closed...
		/*if (inDialogue != textBoxScript.textBoxActive) {
			inDialogue = textBoxScript.textBoxActive;
			if (inDialogue == false) {
				Debug.Log ("Let the player move again.");
				playerScript.currentState = playerScript.PlayerState.free;
				playerScript.changeState = true;
			}
		}
		// If this script notices that the player is in dialogue...
		if (inDialogue != playerScript.inDialogue) {
			inDialogue = playerScript.inDialogue;
			textBoxScript.ActivateTextBox ();
		}*/

	}
}