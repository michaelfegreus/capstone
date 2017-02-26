using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_inventory : MonoBehaviour {

	public int[] helditemIDs;
	// Holds the current tool.
	int currentTool = 0;

	// This keeps track of where the player's cursor is over the items.
	int cursorIndex = 0;

	// To interact with the UI bar
	public GameObject inventoryBarUI;
	scr_inventory_ui inventoryBarUIScript;

	// To interact with the tool UI slot
	public GameObject toolInventoryBarUI;
	scr_inventory_tool_ui toolInventoryBarUIScript;

	// To pull item prefabs from to place.
	public GameObject itemEncyclopedia;
	scr_item_encyclopedia itemEncyclopediaScript;

	// To check if an item is being picked up.
	bool pickUp = false;

	void Start () {
		inventoryBarUIScript = inventoryBarUI.GetComponent<scr_inventory_ui> ();
		toolInventoryBarUIScript = toolInventoryBarUI.GetComponent<scr_inventory_tool_ui> ();
		itemEncyclopediaScript = itemEncyclopedia.GetComponent<scr_item_encyclopedia> ();
		Debug.Log ("Cursor Index: " + cursorIndex);
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

	/*public void SortInventory(){
		public int[] tempArray;
		tempArray = 
	}*/

	public void AddItem(int itemID){
		// i is equal to the current index on the array
		for (int i = 0; i < helditemIDs.Length; i++) {
			// If it finds Item ID 0, the ID for an empty item, then it replaces it with something.
			if (helditemIDs [i] == 0) {
				helditemIDs [i] = itemID;
				//Time to put the sprite into the UI...
				Sprite imageSpriteToAdd = itemEncyclopediaScript.GetItemSprite(itemID);
				inventoryBarUIScript.AddItemImage(i, imageSpriteToAdd);
				// This breaks the loop early
				return;
			}
		}
	}

	public void AddTool(int itemID){
		currentTool = itemID;
		Sprite imageSpriteToAdd = itemEncyclopediaScript.GetToolSprite(itemID);
		toolInventoryBarUIScript.AddToolImage (imageSpriteToAdd);
	}

	public void PlaceItem(){
		// Grabs item at cursor index
		int itemIndex = cursorIndex;
		// Tracks what the ID of the item we're about to place is.
		int itemToPlaceID = helditemIDs [itemIndex];
		// If it's not empty...
		if (itemToPlaceID != 0) {
			// Instantiates something from the Item Encyclopedia.
			Instantiate (itemEncyclopediaScript.GetItemPrefab(itemToPlaceID), this.transform.position + new Vector3 (0f, -.5f, -.5f)/*places at player's feet*/, Quaternion.identity);
		}
		// Gets the Inventory bar to remove the sprite from the UI.
		inventoryBarUIScript.RemoveItemImage (itemIndex, itemToPlaceID);
		helditemIDs [itemIndex] = 0;
	}

	public void UseItem(){
		// Grabs item at cursor index
		int itemIndex = cursorIndex;
		if (helditemIDs [itemIndex] != 0) { // If it's not empty
			//Instantiate game object at the slot from items[itemIndex] (which is the item ID)
			Debug.Log(helditemIDs[itemIndex]);
			//GameObject usedItem = Instantiate (itemPrefabs[helditemIDs[itemIndex]], this.transform.position + new Vector3 (0f, -.5f, -.5f)/*places at player's feet*/, Quaternion.identity);
			//usedItem.GetComponent<SpriteRenderer> ().enabled = false;
			//usedItem.GetComponent<Collider2D> ().enabled = false;
			//usedItem.GetComponent<scr_useitem_test> ().UseTestItem ();
			//Destroy (usedItem);
			// Gets the Inventory bar to remove the sprite from the UI.
			inventoryBarUIScript.RemoveItemImage (itemIndex, helditemIDs [itemIndex]);

			//player.UseItem(helditems[itemIndex]);
		}
		helditemIDs [itemIndex] = 0;
	}

	void Update() {

		// Resets picking up
		pickUp = false;

		if (Input.GetKeyDown (KeyCode.G)) {
			if (CheckFull() == false) {
				pickUp = true;
			}
		}

		// Test placing items
		if (Input.GetKeyDown (KeyCode.H)) {
			PlaceItem();
		}

		// Test using items
		if (Input.GetKeyDown (KeyCode.J)) {
			UseItem();
		}

		// Cursor highlight goes back one slot. Goes to the last slot if the first is highlighted.
		if (Input.GetKeyDown (KeyCode.Q)) {
			if (cursorIndex == 0) {
				// Loops back around to last
				cursorIndex = helditemIDs.Length - 1;
			} else {
				// Otherwise, just goes back one.
				cursorIndex--;
			}
			inventoryBarUIScript.ChangeCursorIndexHighlight (cursorIndex);
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
		}
	}

	void OnTriggerStay2D(Collider2D col){
		if (col.tag == ("Item")) {
			if (pickUp) {
				int itemID = col.gameObject.GetComponent<scr_item_ID> ().GetItemID ();
				AddItem (itemID);
				Destroy (col.gameObject);
				pickUp = false;
			}
		}
		if (col.tag == ("ToolItem")) {
			// You must NOT be holding a tool to pick up another tool.
			// This ensures that the players don't cheese the game and drag along multiple tools by swapping out.
			// Tool shed functionality to come soon.
			if (pickUp && currentTool == 0) {
				int itemID = col.gameObject.GetComponent<scr_item_ID> ().GetItemID ();
				AddTool (itemID);
				Debug.Log ("Tried to pickup tool");
				Destroy (col.gameObject);
				pickUp = false;
			}
		}
	}
}
