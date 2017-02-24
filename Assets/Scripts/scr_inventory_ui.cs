using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_inventory_ui : MonoBehaviour {

	// The image UI game objects. They begin inactive.
	public Image[] itemImages;
	// This is the array of UI sprites. use the itemID coding to match the right sprites to the itemID. This should help lighten the load on the system, as well as the workflow.
	public Sprite[] itemIDSprites;
	// Maybe need a faster / more efficient way of doing this, like just inputting parents into a public array, rather than two children. For now, using a public array to grab the highlight Image objects.
	public Image[] slotHighlights;

	// This keeps track of where the player's cursor highlight is over the items.
	int cursorIndexHighlight = 0;

	public void AddItemImage(int slotIndex, int itemID){
		// Adds a sprite in the designated slot Image. Called by scr_inventory, at the Inventory Game Object
		itemImages [slotIndex].sprite = itemIDSprites [itemID];
		itemImages [slotIndex].enabled = true;
	}
	public void RemoveItemImage(int slotIndex, int itemID){
		// Gets rid of the sprite in the designated slot Image. Called by scr_inventory, at the Inventory Game Object
		itemImages [slotIndex].sprite = null;
		itemImages [slotIndex].enabled = false;
	}
	public void ChangeCursorIndexHighlight(int newCursorIndex){
		slotHighlights [cursorIndexHighlight].enabled = false;
		cursorIndexHighlight = newCursorIndex;
		slotHighlights [cursorIndexHighlight].enabled = true;
	}
}
