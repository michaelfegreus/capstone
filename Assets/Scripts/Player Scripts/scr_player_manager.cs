using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_player_manager : MonoBehaviour {

	// To perform context sensitive actions. May need to change depending on scalability and ease of keeping track.
	int contextLocation = Locations.GENERAL;

	// To manage other scripts from player
	scr_inventory inventoryScript;
	scr_player_movement movementScript;

	void Start(){
		inventoryScript = GetComponent<scr_inventory> ();
		movementScript = GetComponent<scr_player_movement> ();
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == ("ContextSensitive")) {
			if (col.name == "ToolShed") {
				contextLocation = Locations.TOOLSHED;
			}
			Debug.Log (contextLocation);
		}
	}
	void OnTriggerExit2D(Collider2D col){
		if (col.tag == ("ContextSensitive")) {
			contextLocation = Locations.GENERAL;
		}
		Debug.Log (contextLocation);
	}
}