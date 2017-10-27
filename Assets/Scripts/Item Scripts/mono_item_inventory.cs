using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mono_item_inventory : MonoBehaviour {

	// A generic item inventory --
	// Thus, ideally useable by multiple actor types, including the Player, NPCs, and treasure chests / backpacks, etc.

	public Item[] itemsHeld;

	// Add an item during run time.
	public void AddItem(Item newItem){
		// If there's an empty slot, add the Item asset to that slot.
		for (int i = 0; i < itemsHeld.Length; i++) {
			if (itemsHeld [i] == null) {
				itemsHeld [i] = newItem;
				// This breaks the loop early
				return;
			}
		}
	}

	public bool CheckFull(){
		bool full = true; // Starts as true, but flips to false as soon as it finds an exception.
		for (int i = 0; i < itemsHeld.Length; i++) {
			if (itemsHeld [i] == null) {
				full = false;
				return full;
			}
		}
		return full;
	}
}