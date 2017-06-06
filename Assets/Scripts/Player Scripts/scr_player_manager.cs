using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_player_MANAGER : MonoBehaviour {

	// Get the other player components.
	scr_player_movement_rigidbody movementScript;
	scr_player_interaction interactionScript;
	scr_player_inventory inventoryScript;

	void Start(){
		movementScript = GetComponent<scr_player_movement_rigidbody> ();
		interactionScript = GetComponent<scr_player_interaction> ();
		inventoryScript = GetComponent<scr_player_inventory> ();
	}

	// Changes what the player is able to do depending on the current state.
	/*public void PlayerStateChange(int newState){
		
		switch (State) {

		case State.free:
			movementScript.canMove = true;
			interactionScript.canInteract = true;
			Debug.Log ("Player State: FREE");
			break;

		case State.menu:
			Debug.Log ("Player State: MENU");
			break;


		default:
			Debug.Log ("No player state");
			break;
		}
	}

	public enum State{

		free,menu
	}

	public string GetState(){
		switch (State) {

		case State.free:
			return "free";
		}
	}*/
}
