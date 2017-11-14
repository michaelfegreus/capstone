using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mono_interactable_door : MonoBehaviour {

	GameObject thePlayer;
	mono_item_inventory playerInventory;
	[System.NonSerialized]
	public bool doorOpen = false;

	// *** I removed key related stuff because I'm just going to handle the Item requirement via scr_interactable_check
	// AKA redundant to have two Item checks.

	/*public Item myKey;
	bool doorUsable = false;

	void Start(){
		if (myKey == null) { // If there's no needed key, just let her open it.
			doorUsable = true;
		}
	}*/

	// Only run update when enabled (enabled set on by the scr_interaction_manager via player input, and disabled after the frame).
	void Update(){
		/*if (!doorUsable) {
			if (playerInventory.CheckInventoryForItem (myKey)) {
				doorUsable = true;
			}
		}
		if (myKey == null) { // If there's no needed key, just let her open it.
			doorUsable = true;
		}*/
		if (/*doorUsable &&*/ !doorOpen) {
			doorOpen = true;
		}
		
		enabled = false;
	}

	// Grab a reference to the Player on collision.
	void OnTriggerEnter(Collider col){
		if (col.tag.Trim().Equals("Player".Trim())){
			thePlayer = col.gameObject;
			playerInventory = thePlayer.GetComponent<mono_item_inventory> ();
		}
	}

	void OnTriggerExit(Collider col){
		// Reset the door status when the player walks away.
		if (col.tag.Trim().Equals("Player".Trim())){
		//	doorUsable = false;

			enabled = false;
		}
	}
}
