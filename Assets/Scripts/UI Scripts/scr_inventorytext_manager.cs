using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_inventorytext_manager : MonoBehaviour {

	public Text[] itemTextArray;
	public int[] inventoryItemsID;

	// UI cursor sprite driven by the cursor's index integer.
	public Transform cursorSprite;
	int cursorIndexUI = 0;

	// Sets up the item array to match the inventory's array.
	// Try this for now. If later you don't want to have two arrays holding the same data, just pass information directly into the text slot from the inventory.
	public void SetItemArray(int inventorySize){
		inventoryItemsID = new int[inventorySize];
	}

	// Refreshes the items in this UI for when the menu opens.
	public void UpdateItemArray(int arraySlot, int newItemID){
		inventoryItemsID [arraySlot] = newItemID;
	}

	// Sets and refreshes what is in the actual text boxes.
	public void UpdateMenuSlots(){
		for (int i = 0; i < itemTextArray.Length; i++) {
			if (inventoryItemsID [i] == 0) {
				itemTextArray [i].text = "Empty";
			} else {
				// For now, just shows item IDs.
				itemTextArray [i].text = inventoryItemsID [i].ToString ();
			}
		}
	}

	// Updates the current index of the cursor.
	public void UpdateCursorIndex(int newCursorIndex){
		cursorIndexUI = newCursorIndex;
		// Sets the Y position of the cursor sprite equal to the y position of the current UI spot of the index.
		cursorSprite.transform.position = new Vector3(cursorSprite.transform.position.x, itemTextArray [cursorIndexUI].transform.position.y, cursorSprite.transform.position.z);
	}
}
