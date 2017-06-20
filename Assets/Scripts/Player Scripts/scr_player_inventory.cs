using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_player_inventory : MonoBehaviour {

	public int[] helditemIDs;

	// The inventory UI to visually communicate the inventory.
	public GameObject inventoryUI;
	scr_inventorytext_manager inventoryUIScript;

	// Keeps track of when the UI menu is open.
	public bool inItemMenu = false;

	// This keeps track of where the player's cursor is over the items.
	int cursorIndex = 0;
	//Keeps track of whether the cursor was just moved.
	bool cursorMove = false;

	// An array that keeps track of all the things the trigger collider is colliding with. These things should all have an scr_item_use_check component attached to them.
	// This prevents the player from interacting with more than one thing at a time, should interactable objects be close enough.
	public GameObject[] nearbyInteractables;

	void Start(){
		inventoryUIScript = inventoryUI.GetComponent<scr_inventorytext_manager> ();
		// Set the inventory UI's item ID array size.
		inventoryUIScript.SetItemArray(helditemIDs.Length);
		nearbyInteractables = new GameObject[5];
	}

	void Update(){
		// Open up the menu on a button input. This includes functionality that updates what is written in the text UI.
		if (Input.GetKeyDown (KeyCode.Joystick1Button3)) {
			// Close menu
			if (inItemMenu == true) {
				CloseInventoryMenu ();
			}
			// Open menu
			else if (inItemMenu == false) {
				OpenInventoryMenu ();
			}
		}

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
		
			if (Input.GetKeyDown(KeyCode.Joystick1Button5)) {
					// If the next cursor slot is past the end of the array...
					if (cursorIndex + 1 >= helditemIDs.Length) {
						cursorIndex = 0;
					} else {
						cursorIndex++;
					}
					inventoryUIScript.UpdateCursorIndex (cursorIndex);
				}
				// If input up
			if (Input.GetKeyDown(KeyCode.Joystick1Button4)) {
					// If the next cursor slot is below 0...
					if (cursorIndex - 1 < 0) {
						cursorIndex = helditemIDs.Length - 1;
					} else {
						cursorIndex--;
					} 
					inventoryUIScript.UpdateCursorIndex (cursorIndex);
				}
		}
		// To use an item in menu...
		if (inItemMenu){
			if (Input.GetKeyDown (KeyCode.Joystick1Button0)) {
				// If not currently highlighting an empty item ID.
				if (helditemIDs [cursorIndex] != 0) {
					UseItem ();
				}
			}
		}
	}

	public bool CheckFull(){
		bool full = true; // Starts as true, but flips to false as soon as it finds an exception.
		for (int i = 0; i < helditemIDs.Length; i++) {
			if (helditemIDs [i] == 0) {
				full = false;
				return full;
			}
		}
		return full;
	}

	public void AddItem(int newItemID){
		// i is equal to the current index on the array
		for (int i = 0; i < helditemIDs.Length; i++) {
			// If it finds Item ID 0, the ID for an empty item, then it replaces it with something.
			if (helditemIDs [i] == 0) {
				helditemIDs [i] = newItemID;
				// This breaks the loop early
				return;
			}
		}

	}

	void OpenInventoryMenu(){
		inItemMenu = true;
		inventoryUI.SetActive (true);
		// Set the list's item IDs
		for (int i = 0; i < helditemIDs.Length; i++) {
			inventoryUIScript.UpdateItemArray(i, helditemIDs[i]);
		}
		// Updates text (and hopefully soon images) for all the items.
		inventoryUIScript.UpdateMenuSlots();
	}

	void CloseInventoryMenu(){
		inItemMenu = false;
		inventoryUI.SetActive (false);
	}

	public void UseItem(){
		// Check through the array of interactables objects. Interact with the closest one.
		int currentNearestObjectIndex = CheckNearestObjectSlot();
		// If not null, and there are nearby interactables...
		if (currentNearestObjectIndex > -1) {
			// Pass over the item ID at that the cursor is highlighting right now to the nearest object that checks items.
			scr_item_use_check npcItemScript = nearbyInteractables[currentNearestObjectIndex].GetComponent<scr_item_use_check>();
			npcItemScript.UseItemCheck (helditemIDs [cursorIndex]);
			// If the NPC is supposed to receive the item from the player...
			if (npcItemScript.takeItemFromPlayer) {
				// Remove the item from the player's inventory only if it's the right item.
				if (npcItemScript.gotItem) {
					helditemIDs [cursorIndex] = 0;
				}
				// Close menu after you give an item.
				CloseInventoryMenu();
			}
		}
	}

	void SortInventoryArray(){
		int[] sortedInventory = new int[helditemIDs.Length];
		for (int i = 0; i < helditemIDs.Length; i++) {
			
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
		if (col.GetComponent<scr_item_use_check>() != null){// == ("Item")) {
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
		if (col.GetComponent<scr_item_use_check>() != null){// == ("Item")) {
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
