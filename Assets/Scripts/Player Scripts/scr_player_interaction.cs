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

	// Interact with Player Manager
	scr_player_MANAGER managerScript;

	public bool inDialogue;

	// Use this for initialization
	void Start () {
		inventoryScript = GetComponent<scr_player_inventory> ();
		managerScript = GetComponent<scr_player_MANAGER> ();
		// Can change amount of nearby interactable objects if need be, but there should not be too many.
		nearbyInteractables = new GameObject[5];
	}
	
	// Update is called once per frame
	void Update () {

		// Interact button.
		if (Input.GetKeyDown (KeyCode.JoystickButton2)) {

			// Check through the array of interactables objects. Interact with the closest one.
			int currentNearestObjectIndex = CheckNearestObjectSlot();

			// If not null, and there are nearby interactables...
			if (currentNearestObjectIndex > -1) {
				// If it's an item, do this:
				if (nearbyInteractables [currentNearestObjectIndex].tag.Trim ().Equals ("Item".Trim ())) {
					if (!inventoryScript.CheckFull ()) {
						int itemID = nearbyInteractables [currentNearestObjectIndex].GetComponent<scr_item_ID> ().GetItemID ();
						inventoryScript.AddItem (itemID);
						// Get rid of object from scene.
						Destroy (nearbyInteractables [currentNearestObjectIndex]);
						// Remove from interactable objects array.
						nearbyInteractables [currentNearestObjectIndex] = null;
					}
				}
			}
		}

		CheckExclamationUI ();
	}

	int CheckNearestObjectSlot(){
		
		// Run a check of nearest object's index in the nearbyInteractables array.
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
		return nearestObjectIndex;
	}

	// If there are no nearby interactable objects, turn off the exclamation object UI.
	void CheckExclamationUI(){
		
		bool interactablesEmpty = true;

		for (int i = 0; i < nearbyInteractables.Length; i++) {
			if (nearbyInteractables [i] != null) {
				interactablesEmpty = false;
				// UI on!
				exclamationUI.SetActive (true);
				return;
			}
		}
		if (interactablesEmpty) {
			// UI off
			exclamationUI.SetActive (false);
		}
	}

	public void DeactivateExclamationUI(){
		exclamationUI.SetActive (false);
	}

	// Check to see if the player entered the range of interactable objects.
	void OnTriggerEnter(Collider col){
		if (col.tag.Trim().Equals("Item".Trim()) || col.tag.Trim().Equals("Dialogue".Trim())){
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
		if (col.tag.Trim().Equals("Item".Trim()) || col.tag.Trim().Equals("Dialogue".Trim())){
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
