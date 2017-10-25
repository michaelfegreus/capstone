using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_game_MANAGER : MonoBehaviour {

	public GameObject playerObject;
	scr_player_MANAGER playerScript;

	mono_inventory_menu_manager inventoryMenuManager;
	scr_ui_textbox_manager textBoxScript;

	// Player state conditions
	bool inDialogue = false;

	// Use this for initialization
	void Start () {
		playerScript = playerObject.GetComponent<scr_player_MANAGER>();
		textBoxScript = GetComponent<scr_ui_textbox_manager> ();
		inventoryMenuManager = GetComponent<mono_inventory_menu_manager> ();
	}
	
	// Update is called once per frame
	void Update () {

		// Open up the menu on a button input. This includes functionality that updates what is written in the text UI.
		if (Input.GetKeyDown (KeyCode.JoystickButton3) || Input.GetKeyDown (KeyCode.I)) {
			if (playerScript.currentState == scr_player_MANAGER.State.inMenu) {
				playerScript.StateChange (scr_player_MANAGER.State.free);
				// Close menu
				inventoryMenuManager.CloseInventoryMenu ();
			}
			// Open menu
			else if (playerScript.currentState == scr_player_MANAGER.State.free) {
				playerScript.StateChange (scr_player_MANAGER.State.inMenu);
				inventoryMenuManager.OpenInventoryMenu (playerObject.GetComponent<mono_item_inventory>());
			}
		}

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