using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_inventory_ui : MonoBehaviour {

	// The image UI game objects. They begin inactive.
	public Image[] itemImages;
	// Maybe need a faster / more efficient way of doing this, like just inputting parents into a public array, rather than two children. For now, using a public array to grab the highlight Image objects.
	public Image[] slotHighlights;

	// This keeps track of where the player's cursor highlight is over the items.
	int cursorIndexHighlight = 0;

	public void AddItemImage(int slotIndex, Sprite newSprite){
		// Adds a sprite in the designated slot Image. Called by scr_inventory, at the Inventory Game Object
		itemImages [slotIndex].sprite = newSprite;
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
