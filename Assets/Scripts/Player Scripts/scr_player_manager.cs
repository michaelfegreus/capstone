using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_player_MANAGER : MonoBehaviour {

	// Get the other player components.
	scr_player_movement_rigidbody movementScript;
	scr_player_interaction interactionScript;
	scr_player_inventory inventoryScript;

	public bool inItemMenu;
	public bool onGround;
	public bool inDialogue;
	public bool inAnimation;
	public bool free;

	void Start(){
		movementScript = GetComponent<scr_player_movement_rigidbody> ();
		interactionScript = GetComponent<scr_player_interaction> ();
		inventoryScript = GetComponent<scr_player_inventory> ();

		free = true;
		//currentPlayerState = State.free;
	}

	void Update(){

		// If it detects a change in state...
		if (inItemMenu != inventoryScript.inItemMenu) {
			free = false;
			inItemMenu = inventoryScript.inItemMenu;
		}
		if(onGround != movementScript.onGround){
			free = false;
			onGround = movementScript.onGround;
		}
		if (inDialogue != interactionScript.inDialogue) {
			free = false;
			inDialogue = interactionScript.inDialogue;
		}

		// State change settings.
		if (!free) {
			if (!onGround) {
				interactionScript.DeactivateExclamationUI();
				interactionScript.enabled = false;
				inventoryScript.enabled = false;
				//currentPlayerState = State.inAir;
			} else if (inItemMenu) {
				movementScript.ResetMovementValues ();
				movementScript.enabled = false;
				interactionScript.enabled = false;
				//currentPlayerState = State.inMenu;
			} else if (inDialogue) {
				movementScript.ResetMovementValues ();
				movementScript.enabled = false;
				interactionScript.enabled = false;
				inventoryScript.enabled = false;
				//currentPlayerState = State.inDialogue;
			} else {
				free = true;
				movementScript.enabled = true;
				interactionScript.enabled = true;
				inventoryScript.enabled = true;
				//currentPlayerState = State.free;
			}
		}
	}

	/*public enum State{

		free, inAnimation, inMenu, inDialogue, inAir

	}*/
}
