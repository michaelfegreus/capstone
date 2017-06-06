using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_player_inventory : MonoBehaviour {

	public int[] helditemIDs;

	// The inventory UI to visually communicate the inventory.
	public GameObject inventoryUI;
	scr_inventorytext_manager inventoryUIScript;

	// Keeps track of when the UI menu is open.
	bool showMenuUI = false;

	// This keeps track of where the player's cursor is over the items.
	int cursorIndex = 0;

	void Start(){
		inventoryUIScript = inventoryUI.GetComponent<scr_inventorytext_manager> ();
		// Set the inventory UI's item ID array size.
		inventoryUIScript.SetItemArray(helditemIDs.Length);
	}

	void Update(){
		// Open up the menu on a button input. This includes functionality that updates what is written in the text UI.
		if (Input.GetKeyDown (KeyCode.Joystick1Button3)) {
			// Close menu
			if (showMenuUI == true) {
				showMenuUI = false;
				inventoryUI.SetActive (false);
			}
			// Open menu
			else if (showMenuUI == false) {
				showMenuUI = true;
				inventoryUI.SetActive (true);
				// Set the list's item IDs
				for (int i = 0; i < helditemIDs.Length; i++) {
					inventoryUIScript.UpdateItemArray(i, helditemIDs[i]);
				}
				// Updates text (and hopefully soon images) for all the items.
				inventoryUIScript.UpdateMenuSlots();
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

	public void AddItem(int itemID){
		// i is equal to the current index on the array
		for (int i = 0; i < helditemIDs.Length; i++) {
			// If it finds Item ID 0, the ID for an empty item, then it replaces it with something.
			if (helditemIDs [i] == 0) {
				helditemIDs [i] = itemID;
				// This breaks the loop early
				return;
			}
		}

	}
}
