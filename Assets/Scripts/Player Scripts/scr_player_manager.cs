using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_player_manager : MonoBehaviour {

	// To perform context sensitive actions. May need to change depending on scalability and ease of keeping track.
	[HideInInspector] public int contextLocation = Locations.GENERAL;

	// Keeps track of what tool is being held by the player.
	[HideInInspector] public int currentTool;

	// To manage other scripts from player
	scr_inventory inventoryScript;
	scr_player_movement movementScript;

	// To interact with the tool manager when tools are engaged with.
	scr_tool_manager toolManagerScript;

	void Start(){
		inventoryScript = GetComponent<scr_inventory> ();
		movementScript = GetComponent<scr_player_movement> ();
		toolManagerScript = GetComponent<scr_tool_manager> ();
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == ("ContextSensitive")) {
			contextLocation = col.GetComponent<scr_contextsensitive_location> ().GetLocationID ();
			//Debug.Log ("Current area: " + contextLocation);
		}
	}
	void OnTriggerExit2D(Collider2D col){
		if (col.tag == ("ContextSensitive")) {
			contextLocation = Locations.GENERAL;
			//Debug.Log ("Current area: " + contextLocation);
		}
	}

	// To keep track of what tool is being used for use, animation, etc.
	public void SetCurrentTool(int newCurrentTool){
		currentTool = newCurrentTool;
	}
}