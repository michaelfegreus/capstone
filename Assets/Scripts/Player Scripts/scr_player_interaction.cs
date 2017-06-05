using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_player_interaction : MonoBehaviour {

	// To check if an item is being picked up.
	//bool buttonInput = false;

	// An array that keeps track of all the things the trigger collider is colliding with.
	// This prevents the player from interacting with more than one thing at a time, should interactable objects be close enough.
	public GameObject[] nearbyInteractables;

	// Cartoon thing that pops up above the player's head to notify that you're in front of something interactable.
	public GameObject exclamationUI;

	// To deal with inventory when the player interacts with items
	scr_player_inventory inventoryScript;


	// Use this for initialization
	void Start () {
		inventoryScript = GetComponent<scr_player_inventory> ();
		nearbyInteractables = new GameObject[5];
	}
	
	// Update is called once per frame
	void Update () {

		// Interact button.
		if (Input.GetKeyDown (KeyCode.JoystickButton2)) {

			// Check through the array of interactables objects. Interact with the closest one.
			int nearestObjectIndex = -1; // Setting values because Unity asking that they not be empty.
			float nearestObjectDistance = 0; // Setting values because Unity asking that they not be empty.
			for (int i = 0; i < nearbyInteractables.Length; i++) {
				// If not null, check how far from the player object.
				if (nearbyInteractables [i] != null) {
					// If there's nothing in the nearestObjectDistance check yet, just take the first value. -1 means nothing was put in there.
					if (nearestObjectIndex == -1) {
						nearestObjectDistance = Vector3.Distance (nearbyInteractables [i].transform.position, transform.position);
						nearestObjectIndex = i; // The new nearest object is set.
					}
					// If there's a smaller distance between another object and the player, make that the thing to interact with.
					else if (Vector3.Distance (nearbyInteractables [i].transform.position, transform.position) < nearestObjectDistance) {
						nearestObjectDistance = Vector3.Distance (nearbyInteractables [i].transform.position, transform.position);
						nearestObjectIndex = i; // The new nearest object is set.
					}
				}
			}

			// If it's an item, do this:
			if (nearbyInteractables [nearestObjectIndex].tag.Trim ().Equals ("Item".Trim ())) {
				if (!inventoryScript.CheckFull()) {
					int itemID = nearbyInteractables [nearestObjectIndex].GetComponent<scr_item_ID> ().GetItemID ();
					inventoryScript.AddItem (itemID);
					// Get rid of object from scene.
					Destroy (nearbyInteractables [nearestObjectIndex]);
					// Remove from interactable objects array.
					nearbyInteractables [nearestObjectIndex] = null;
				}
			}
		}

		checkExclamationUI ();
	}

	// If there are no nearby interactable objects, turn off the exclamation object UI.
	void checkExclamationUI(){
		
		bool interactablesEmpty = true;

		for (int i = 0; i < nearbyInteractables.Length; i++) {
			if (nearbyInteractables [i] != null) {
				interactablesEmpty = false;
				return;
			}
		}
		if (interactablesEmpty) {
			// UI off
			exclamationUI.SetActive (false);
		}
	}

	// Check to see if the player entered the range of interactable objects.
	void OnTriggerEnter(Collider col){
		if (col.tag.Trim().Equals("Item".Trim())){// == ("Item")) {
			// UI on!
			exclamationUI.SetActive (true);
			// Add to array of nearby interactables.
			for (int i = 0; i < nearbyInteractables.Length; i++) {
				// If it finds a null slot, then it replaces it with the interactable.
				if (nearbyInteractables [i] == null) {
					nearbyInteractables [i] = col.gameObject;
					// This breaks the loop early
					return;
				}
			}
		}
	}

	// Check to see if the player exited the range of interactable objects.
	void OnTriggerExit(Collider col){
		if (col.tag.Trim().Equals("Item".Trim())){// == ("Item")) {
			// Remove from list of nearby interactables.
			for (int i = 0; i < nearbyInteractables.Length; i++) {
				// Remove the interactable from the array.
				if (nearbyInteractables [i] == col.gameObject) {
					nearbyInteractables [i] = null;
					// This breaks the loop early
					return;
				}
			}
		}
	}
}
