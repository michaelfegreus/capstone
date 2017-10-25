using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mono_inventory_menu_manager : MonoBehaviour {

	// Script for dealing with the non-diegetic inventory menu.
	// I'm thinking this will get stuck onto the Game Manager object, rather than create a new object.

	mono_item_inventory currentInventory;

	int currentInventorySize;

	// Keeps track of when the UI menu is open.
	public bool inItemMenu = false;

	// The inventory UI to visually communicate the inventory.
	public GameObject inventoryUI;
	scr_ui_inventory_manager inventoryUIScript;

	// This keeps track of where the player's cursor is over the items.
	int cursorIndex = 0;
	//Keeps track of whether the cursor was just moved.
	bool cursorMove = false;

	void Start(){
		inventoryUIScript = inventoryUI.GetComponent<scr_ui_inventory_manager> ();
	}

	public void OpenInventoryMenu (mono_item_inventory incomingInventory){
		currentInventory = incomingInventory;
		currentInventorySize = incomingInventory.itemsHeld.Length;
		inItemMenu = true;
		inventoryUI.SetActive (true);
	}
	public void CloseInventoryMenu (){
		inItemMenu = false;
		inventoryUI.SetActive (false);
	}






	/*
	public int[] helditemIDs;





	// An array that keeps track of all the things the trigger collider is colliding with. These things should all have an scr_item_use_check component attached to them.
	// This prevents the player from interacting with more than one thing at a time, should interactable objects be close enough.
	public GameObject[] nearbyInteractables;


	void Update(){

		// Allows you to operate the item menu when it's open

		// Analog stick version of menu control
		if (inItemMenu) {
			float inputY = Input.GetAxis("Vertical");
			// If you haven't just moved the cursor.
			if (!cursorMove) {
				// If input down
				if (inputY < -.5f) {
					// If the next cursor slot is past the end of the array...
					if (cursorIndex + 1 == helditemIDs.Length) {
						cursorIndex = 0;
					} else {
						cursorIndex++;
					}
					cursorMove = true;
					inventoryUIScript.UpdateCursorIndex (cursorIndex);
				}
				// If input up
				if (inputY > .5f) {
					// If the next cursor slot is below 0...
					if (cursorIndex - 1 < 0) {
						cursorIndex = helditemIDs.Length - 1;
					} else {
						cursorIndex--;
					}
					cursorMove = true;
					inventoryUIScript.UpdateCursorIndex (cursorIndex);
				}
			} else if (inputY < .5f && inputY > -.5f) {
				cursorMove = false;
			}
		}
		// Button version of menu control
		if (inItemMenu) {
			float inputY = Input.GetAxis("Vertical");
			// If you haven't just moved the cursor.

			if (Input.GetKeyDown(KeyCode.JoystickButton5)) {
				// If the next cursor slot is past the end of the array...
				if (cursorIndex + 1 >= helditemIDs.Length) {
					cursorIndex = 0;
				} else {
					cursorIndex++;
				}
				inventoryUIScript.UpdateCursorIndex (cursorIndex);
			}
			// If input up
			if (Input.GetKeyDown(KeyCode.JoystickButton4)) {
				// If the next cursor slot is below 0...
				if (cursorIndex - 1 < 0) {
					cursorIndex = helditemIDs.Length - 1;
				} else {
					cursorIndex--;
				} 
				inventoryUIScript.UpdateCursorIndex (cursorIndex);
			}
		}/*
		// To use an item in menu...
		if (inItemMenu){
			if (Input.GetKeyDown (KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Return)) {
				// If not currently highlighting an empty item ID.
				if (helditemIDs [cursorIndex] != 0) {
					UseItem ();
				}
			}
		}
	}

	void SortInventoryArray(){
		int[] sortedInventory = new int[helditemIDs.Length];
		int sortedInventorySlot = 0; // Keep track of where we are along the sorted inventory
		for (int i = 0; i < helditemIDs.Length; i++) {
			if (helditemIDs [i] != 0) { // If the item ID is not 0 aka the slot is not empty
				sortedInventory[sortedInventorySlot] = helditemIDs[i];
				sortedInventorySlot++;
			}
		}
		for (int i = 0; i < helditemIDs.Length; i++) { // Copy the sorted array into the main inventory array.
			if (sortedInventory [i] != 0) { // If the item ID is not 0 aka the slot is not empty
				helditemIDs [i] = sortedInventory [i];
			} else {
				helditemIDs [i] = 0;
			}
		}
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

	// Check to see if the player entered the range of interactable objects with an item check script.
	void OnTriggerEnter(Collider col){
		// If there's an item check script...
		if (col.GetComponent<scr_item_quest>() != null){// == ("Item")) {
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
		if (col.GetComponent<scr_item_quest>() != null){// == ("Item")) {
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
	}*/
}
