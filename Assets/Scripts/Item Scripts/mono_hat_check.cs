using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mono_hat_check : MonoBehaviour {

	//This is very inefficient to check this every frame, but I'm very tired :p

	public GameObject player;
	mono_item_inventory playerInventory;
	public Item myHatItem;

	Renderer myRenderer;

	void Start(){
		playerInventory = player.GetComponent<mono_item_inventory> ();
		myRenderer = GetComponent<Renderer> ();
	}

	// Update is called once per frame
	void Update () {
		if (playerInventory.CheckInventoryForItem (myHatItem)) {
			myRenderer.enabled = true;
		} else {
			myRenderer.enabled = false;
		}
	}
}
