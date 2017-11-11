using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mono_interactable_door : MonoBehaviour {

	GameObject thePlayer;
	mono_item_inventory playerInventory;

	public Item myKey;

	bool doorUsable = false;
	bool doorOpen = false;

	void Update(){
		if (!doorUsable) {
			if (playerInventory.CheckInventoryForItem (myKey)) {
				doorUsable = true;
			}
		}
		if (doorUsable && !doorOpen) {
			OpenDoor();
		}
	}

	void OpenDoor(){
		gameObject.SetActive (false);
		doorOpen = true;
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
			doorUsable = false;
		}
		enabled = false;
	}
}
