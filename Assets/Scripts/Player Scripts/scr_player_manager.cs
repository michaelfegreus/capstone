using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_player_manager : MonoBehaviour {

	int contextLocation = 0;

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == ("ContextSensitive")) {
			if (col.name == "ToolShed") {
				//contextLocation = enum_dictionary.ContextLocations.ToolShed;
			}
		}
	}
	void OnTriggerExit2D(Collider2D col){
		if (col.tag == ("ContextSensitive")) {
			contextLocation = 0;
		}
	}
}