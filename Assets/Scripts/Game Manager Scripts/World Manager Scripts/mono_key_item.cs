using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mono_key_item : MonoBehaviour {

	public Fact factChangeOnPickup;

	[System.NonSerialized]
	public bool pickedUp = false; // Use this bool to send information regarding its status to the World Manager if its a Key Item.
}