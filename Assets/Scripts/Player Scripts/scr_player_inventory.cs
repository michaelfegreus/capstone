using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_player_inventory : MonoBehaviour {

	public int[] helditemIDs;

	// This keeps track of where the player's cursor is over the items.
	int cursorIndex = 0;

	// To check if an item is being picked up.
	bool pickUp = false;

	void Start () {
		
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

	void Update() {

		// Resets picking up
		pickUp = false;

		if (Input.GetKeyDown (KeyCode.JoystickButton2)) {
			if (CheckFull() == false) {
				pickUp = true;
			}
		}
		/*
		// Test placing items
		if (Input.GetKeyDown (KeyCode.H)) {
			PlaceItem();
		}

		// Test using items
		if (Input.GetKeyDown (KeyCode.J)) {
			UseItem();
		}*/
		/*
		// Cursor highlight goes back one slot. Goes to the last slot if the first is highlighted.
		if (Input.GetKeyDown (KeyCode.Q)) {
			if (cursorIndex == 0) {
				// Loops back around to last
				cursorIndex = helditemIDs.Length - 1;
			} else {
				// Otherwise, just goes back one.
				cursorIndex--;
			}
			//inventoryBarUIScript.ChangeCursorIndexHighlight (cursorIndex);
			Debug.Log ("Cursor Index: " + cursorIndex);
		}
		// Cursor highlight goes forward one slot. Goes to first slot if you try to go past last.
		if (Input.GetKeyDown (KeyCode.E)) {
			if (cursorIndex == helditemIDs.Length - 1) {
				// Loops back around to first.
				cursorIndex = 0;
			} else {
				// Otherwise, goes forward one.
				cursorIndex++;
			}
			inventoryBarUIScript.ChangeCursorIndexHighlight (cursorIndex);
			Debug.Log ("Cursor Index: " + cursorIndex);
		}*/
	}

	void OnTriggerStay(Collider col){
		if (col.tag.Trim().Equals("Item".Trim())){// == ("Item")) {
			if (pickUp) {
				int itemID = col.gameObject.GetComponent<scr_item_ID> ().GetItemID ();
				AddItem (itemID);
				Destroy (col.gameObject);
				pickUp = false;
			}
		}
	}
}
