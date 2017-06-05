using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_inventorytext_manager : MonoBehaviour {

	public Text[] itemTextArray;

	// This is accessed by scr_player_inventory component on the player.
	// At a slot specified by the player inventory script, a new string of text is set.
	public void SetText(int arraySlot, int itemID){
		// For now, I'm just converting the item ID to a string to demo this functionality.
		// Later, you're going to want to make it the name of the item.
		itemTextArray [arraySlot].text = itemID.ToString();
		Debug.Log ("Accessed. Item ID: " + itemID);
		Debug.Log ("Notice me");
	}
}
