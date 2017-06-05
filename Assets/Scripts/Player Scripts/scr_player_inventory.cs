using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_player_inventory : MonoBehaviour {

	public int[] helditemIDs;

	// The inventory UI to visually communicate the inventory.
	public GameObject inventoryUI;
	scr_inventorytext_manager inventoryUIScript;

	// This keeps track of where the player's cursor is over the items.
	int cursorIndex = 0;

	void Start(){
		inventoryUIScript = inventoryUI.GetComponent<scr_inventorytext_manager> ();
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
				ResetUI ();
				return;
			}
		}

	}

	// Flips through InventoryText UI and passes a new line of text.
	void ResetUI(){
		for (int i = 0; i < helditemIDs.Length; i++) {
			inventoryUIScript.SetText (i, helditemIDs [i]);
		}
	}
}
