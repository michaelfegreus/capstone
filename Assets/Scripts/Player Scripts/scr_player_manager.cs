using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_player_MANAGER : MonoBehaviour {

	// Get the other player components.
	scr_player_movement_rigidbody movementScript;
	scr_player_interaction interactionScript;
	scr_player_inventory inventoryScript;
	public GameObject characterRig;
	scr_rig_controller rigScript;

	public State currentState;

	void Start(){
		movementScript = GetComponent<scr_player_movement_rigidbody> ();
		interactionScript = GetComponent<scr_player_interaction> ();
		inventoryScript = GetComponent<scr_player_inventory> ();
		rigScript = characterRig.GetComponent<scr_rig_controller> ();

		currentState = State.free;
	}

	void Update(){

		// If it detects a change in state...(Only check for things the Player Object manages - not menus or pausing, which the Game Manager object runs).
		if (currentState != State.inMenu) {
			if (movementScript.onGround != true && currentState != State.inAir) {
				//changeState = false;
				StateChange (State.inAir);
			}
			if (interactionScript.inDialogue == true && currentState != State.inDialogue) {
				//changeState = false;
				currentState = State.inDialogue;
				StateChange (State.inDialogue);
			}
			if (interactionScript.inDialogue == false && movementScript.onGround == true && currentState != State.free) {
				StateChange (State.free);
			}
		}

	}

	public void StateChange(State newState){

		currentState = newState;

		switch (currentState) {

		case State.free:
			//Debug.Log ("Current player state: Free");
			movementScript.enabled = true;
			interactionScript.enabled = true;
			rigScript.enabled = true;
			break;

		case State.inAir:
			//Debug.Log ("Current player state: Free");
			interactionScript.DeactivateExclamationUI();
			interactionScript.enabled = false;
			break;

		case State.inMenu:
			//Debug.Log ("Current player state: In Menu");
			movementScript.ResetMovementValues ();
			movementScript.enabled = false;
			interactionScript.enabled = false;
			rigScript.ResetAnimation ();
			rigScript.enabled = false;
			break;

		case State.inDialogue:
			//Debug.Log ("Current player state: In Dialogue");
			movementScript.ResetMovementValues ();
			movementScript.enabled = false;
			rigScript.ResetAnimation ();
			rigScript.enabled = false;
			break;

		}
	}

	public enum State{

		free, inAnimation, inMenu, inDialogue, inAir

	}
}