using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mono_item_pickup_manager : MonoBehaviour {

	// *** Remember to tag common items as "Item" and key items as "KeyItem"

	public Item myItem;
	//[System.NonSerialized]
	//public bool pickedUp = false; // Use this bool to send information regarding its status to the World Manager if its a Key Item.

	public Item GetItemReference(){
		//pickedUp = true;
		return myItem;
	}
}
