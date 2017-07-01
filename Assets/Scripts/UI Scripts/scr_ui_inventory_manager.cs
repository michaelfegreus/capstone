using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_ui_inventory_manager : MonoBehaviour {

	public Text[] itemTextArray;
	public int[] inventoryItemsID;

	// UI cursor sprite driven by the cursor's index integer.
	public Transform cursorSprite;
	int cursorIndexUI = 0;

	// Inventory Description Box objects
	public Text highlightedItemText;
	public Text itemDescriptionText;
	public Image itemSprite;

	// Sets up the item array to match the inventory's array.
	// Try this for now. If later you don't want to have two arrays holding the same data, just pass information directly into the text slot from the inventory.
	public void SetItemArray(int inventorySize){
		inventoryItemsID = new int[inventorySize];
	}

	// Refreshes the items in this UI for when the menu opens.
	public void UpdateItemArray(int arraySlot, int newItemID){
		inventoryItemsID [arraySlot] = newItemID;
		// Update the item description box to reflect the newly highlighted item.
		UpdateItemDescription();
	}

	// Sets and refreshes what is in the actual text boxes.
	public void UpdateMenuSlots(){
		for (int i = 0; i < itemTextArray.Length; i++) {
			// Pull from static Item Dictionary object to get the information.
			itemTextArray [i].text = scr_item_dictionary.itemDictionary.GetName(inventoryItemsID [i]);
		}
	}

	// Updates the current index of the cursor.
	public void UpdateCursorIndex(int newCursorIndex){
		cursorIndexUI = newCursorIndex;
		// Sets the Y position of the cursor sprite equal to the y position of the current UI spot of the index.
		cursorSprite.transform.position = new Vector3(cursorSprite.transform.position.x, itemTextArray [cursorIndexUI].transform.position.y, cursorSprite.transform.position.z);
		// Update the item description box to reflect the newly highlighted item.
		UpdateItemDescription();
	}

	// Updates the title, description, and sprite in the Inventory Description Box
	void UpdateItemDescription(){
		// Pull from static Item Dictionary object to get the information. Pull item ID from the spot the cursor is currently over in item array.
		highlightedItemText.text = scr_item_dictionary.itemDictionary.GetName(inventoryItemsID [cursorIndexUI]);
		itemDescriptionText.text = scr_item_dictionary.itemDictionary.GetDescription (inventoryItemsID [cursorIndexUI]);

	}
}
