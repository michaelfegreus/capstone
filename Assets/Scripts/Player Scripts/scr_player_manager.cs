using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_player_manager : MonoBehaviour {

	// To perform context sensitive actions. May need to change depending on scalability and ease of keeping track.
	[HideInInspector] public int trigger = Triggers.GENERAL;

	// Keeps track of what tool is being held by the player.
	[HideInInspector] public int currentTool;

	// Overall GameManager interaction
	public GameObject gameManager;
	scr_game_manager gameManagerScript;

	// To manage other scripts from player
	scr_inventory inventoryScript;
	scr_player_movement movementScript;
	scr_contextsensitive_input contextSensitiveInputScript;

	// To interact with the tool manager when tools are engaged with.
	scr_tool_manager toolManagerScript;

	// To deal with text
	public GameObject textBoxManager;
	scr_textbox_manager textBoxManagerScript;

	void Start(){
		// Roll through and get components for easy access.
		inventoryScript = GetComponent<scr_inventory> ();
		movementScript = GetComponent<scr_player_movement> ();
		toolManagerScript = GetComponent<scr_tool_manager> ();
		contextSensitiveInputScript = GetComponent<scr_contextsensitive_input> ();
		gameManagerScript = GetComponent<scr_game_manager> ();
		// Component on different object.
		textBoxManagerScript = textBoxManager.GetComponent<scr_textbox_manager> ();
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == ("Trigger")) {
			trigger = col.GetComponent<scr_contextsensitive_location> ().GetLocationID ();
			contextSensitiveInputScript.changeContextLocation(trigger);

			// Prepare the Text Box Manager with the text file of the signboard. Useful so it can be ready for when you press A.
			if (trigger == Triggers.SIGNBOARD) {
				string textToLoad = col.gameObject.GetComponent<scr_signboard> ().signText;
				Debug.Log (textToLoad);
				textBoxManagerScript.SetNewString (textToLoad);
			}
		}
	}
	void OnTriggerExit2D(Collider2D col){
		if (col.tag == ("Trigger")) {

			// If you walk away from a sign, disable the text box.
			if (trigger == Triggers.SIGNBOARD) {
				textBoxManagerScript.EnableTextBox (false);
			}

			trigger = Triggers.GENERAL;
		}
	}

	// When you run out of stamina at the end of the day.
	public void DayStaminaDeplete(){
		toolManagerScript.enabled = false;
		inventoryScript.enabled = false;
	}

	// To keep track of what tool is being used for use, animation, etc.
	public void SetCurrentTool(int newCurrentTool){
		currentTool = newCurrentTool;
	}
}