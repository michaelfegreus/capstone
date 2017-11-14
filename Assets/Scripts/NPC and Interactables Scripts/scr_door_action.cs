using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_door_action : MonoBehaviour {

	Animator anim;
	scr_npc_MANAGER questManagerScript;

	public bool locked;
	bool open = false;

	// How long it takes until the door automatically closes itself without player input.

	void Start(){
		anim = GetComponent<Animator> ();
		questManagerScript = GetComponent<scr_npc_MANAGER> ();

	}

	// Run update once upon activation to complete script's task.
	// This is a way to "call" varying specific scripts from the generic scr_player_interaction Monobehavior.
	void Update(){
		if (locked) {
			// If you completed the quest and unlocked the door...
			if (questManagerScript.currentQuest > 0) {
				locked = false;
			}
		}
		if (!open && !locked) {
			Debug.Log ("Open sesame and such.");
			anim.SetBool ("doorOpen", true);
			open = true;
		} else if(open && !locked){
			Debug.Log ("Close the door.");
			anim.SetBool ("doorOpen", false);
			open = false;
		}
		if (open) {

		}
		enabled = false;
	}
}
