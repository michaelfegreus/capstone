using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_player_interaction : MonoBehaviour {

	// To check if an item is being picked up.
	//bool buttonInput = false;

	// An array that keeps track of all the things the trigger collider is colliding with.
	// This prevents the player from interacting with more than one thing at a time, should interactable objects be close enough.
	public GameObject[] nearbyInteractables;
	// Cartoon thing that pops up above the player's head to notify that you're in front of something interactable.
	public GameObject exclamationUI;
	// To deal with inventory when the player interacts with items
	mono_item_inventory inventoryScript;
	// Interact with Player Manager
	scr_player_MANAGER managerScript;
	// To deal with the textbox UI when the player enters dialogue.
	public GameObject textBoxManager;
	scr_ui_textbox_manager textBoxScript;

	public bool inDialogue;

	// Use this for initialization
	void Start () {
		inventoryScript = GetComponent<mono_item_inventory> ();
		managerScript = GetComponent<scr_player_MANAGER> ();
		textBoxScript = textBoxManager.GetComponent<scr_ui_textbox_manager> ();
		// Can change amount of nearby interactable objects if need be, but there should not be too many.
		nearbyInteractables = new GameObject[5];
	}
	
	// Update is called once per frame
	void Update () {

		CheckExclamationUI (); // Doing this every frame right now because I'm still working out this script.

		// Interact button.
		if (!inDialogue && Input.GetKeyDown (KeyCode.JoystickButton2) || Input.GetKeyDown (KeyCode.P) ) {

			// Check through the array of interactables objects. Interact with the closest one.
			int currentNearestObjectIndex = CheckNearestObjectSlot();

			// If not null, and there are nearby interactables...
			if (currentNearestObjectIndex > -1) {
				// If it's an item, do this:
				if (nearbyInteractables [currentNearestObjectIndex].tag.Trim ().Equals ("Item".Trim ()) || nearbyInteractables [currentNearestObjectIndex].tag.Trim ().Equals ("KeyItem".Trim ())) {
					if (!inventoryScript.CheckFull ()) { // If not full.
						Item itemPickup = nearbyInteractables [currentNearestObjectIndex].GetComponent<mono_item_pickup_manager> ().GetItemReference ();
						inventoryScript.AddItem (itemPickup);
						// Get rid of object from scene if it's not a Key Item. (Key Items so far are destroyed/deactivated by World Manager after recording pickup data.)
						if (nearbyInteractables [currentNearestObjectIndex].tag.Trim ().Equals ("Item".Trim ())) { // Checking to see if it is a key item or common item
							Destroy (nearbyInteractables [currentNearestObjectIndex]); // If it's a common item, destroy it on pickup.
						}
						// Remove from interactable objects array.
						nearbyInteractables [currentNearestObjectIndex] = null;
					}
				}
				// And if it's an Actor...
				else if (nearbyInteractables [currentNearestObjectIndex].tag.Trim ().Equals ("Actor".Trim ())) {
					// Get that actor's info
					GameObject interactingActor = nearbyInteractables [currentNearestObjectIndex];
					mono_actor_manager interactingActorScript = interactingActor.GetComponent<mono_actor_manager> ();
					if(interactingActorScript.myCurrentBehavior!=null){
						// Get that actor's current ActorBehavior
						ActorBehavior interactingActorBehavior = interactingActorScript.myCurrentBehavior;
						// If the Actor is waiting to give you an item.
						if(interactingActorBehavior.myGoal == ActorBehavior.BehaviorGoal.giveItemGoal){
							if (!inventoryScript.CheckFull ()) { // If not full on items.
								Item itemPickup = interactingActorScript.GetMyBehaviorItem(); // Use the Get function so you can trigger a certain bool to alert tha							t the task has been completed.
								inventoryScript.AddItem (itemPickup);
							}
							// If it has text to share.
							if (interactingActor.GetComponent<scr_mytext_check> () != null) {
								RunDialog (interactingActor);
							}
						}
					}

				}
				// And if it's a character or signboard, do this.
				else if (nearbyInteractables [currentNearestObjectIndex].tag.Trim ().Equals ("Dialogue".Trim ())) {
					RunDialog (nearbyInteractables [currentNearestObjectIndex]);
				}
				// And if it's something that reacts upon interaction, like a door, do this.
				else if (nearbyInteractables [currentNearestObjectIndex].tag.Trim ().Equals ("Interactable".Trim ())) {
					// Make sure it has a script that allows
					if (nearbyInteractables [currentNearestObjectIndex].GetComponent<scr_interactable_check> () != null) {
						// Get script reference.
						scr_interactable_check interactableScript = nearbyInteractables [currentNearestObjectIndex].GetComponent<scr_interactable_check> ();
						// if it doesn't have an item in inventory requirement...
						if (interactableScript.requiredItem == null) {
							interactableScript.RunAction ();
						} else {
							// If the player has the required item to interact...
							if (inventoryScript.CheckInventoryForItem (interactableScript.requiredItem)) {
								interactableScript.RunAction ();
							}
						}
					} else {
						Debug.Log ("This interactable doesn't have an Interactable Check script attached to it.");
					}
					// And if it has a dialogue script attached to it, run that too.
					if (nearbyInteractables [currentNearestObjectIndex].GetComponent<scr_mytext_check> () != null) {
						inDialogue = true;
						// Activates the text box and sends along the text asset to parse.
						textBoxScript.ActivateTextBox (nearbyInteractables [currentNearestObjectIndex].GetComponent<scr_mytext_check> ().GetText ());
					}
				}
			}
		}
		// Check to see if dialogue is finished.
		if (inDialogue) {
			if (!textBoxScript.textBoxActive) {
				inDialogue = false;
			}
		}

		CheckExclamationUI ();
	}

	void RunDialog(GameObject dialogInteractable){
		inDialogue = true;
		// Activates the text box and sends along the text asset to parse.
		textBoxScript.ActivateTextBox (dialogInteractable.GetComponent<scr_mytext_check> ().GetText ());
	}

	int CheckNearestObjectSlot(){
		
		// Run a check of nearest object's index in the nearbyInteractables array.
		int nearestObjectIndex = -1; // Setting values because Unity asking that they not be empty.
		float nearestObjectDistance = 0; // Setting values because Unity asking that they not be empty.
		for (int i = 0; i < nearbyInteractables.Length; i++) {
			// If not null, check how far from the player object.
			if (nearbyInteractables [i] != null) {
				// If there's nothing in the nearestObjectDistance check yet, just take the first value. -1 means nothing was put in there.
				if (nearestObjectIndex == -1) {
					nearestObjectDistance = Vector3.Distance (nearbyInteractables [i].transform.position, transform.position);
					nearestObjectIndex = i; // The new nearest object is set.
				}
				// If there's a smaller distance between another object and the player, make that the thing to interact with.
				else if (Vector3.Distance (nearbyInteractables [i].transform.position, transform.position) < nearestObjectDistance) {
					nearestObjectDistance = Vector3.Distance (nearbyInteractables [i].transform.position, transform.position);
					nearestObjectIndex = i; // The new nearest object is set.
				}
			}
		}
		return nearestObjectIndex;
	}

	// If there are no nearby interactable objects, turn off the exclamation object UI.
	void CheckExclamationUI(){
		
		bool interactablesEmpty = true;

		for (int i = 0; i < nearbyInteractables.Length; i++) {
			if (nearbyInteractables [i] != null) {
				// In case the item was deactivated, but not destroyed (i.e. Key Items), take it out of the array.
				if (nearbyInteractables [i].activeInHierarchy == false) {
					nearbyInteractables [i] = null;
				} else {
					interactablesEmpty = false;
				}
				// UI on!
				exclamationUI.SetActive (true);
				return;
			}
		}
		if (interactablesEmpty) {
			// UI off
			exclamationUI.SetActive (false);
		}
	}

	public void DeactivateExclamationUI(){
		exclamationUI.SetActive (false);
	}

	public bool UseInventoryItemInteraction(Item usedItem){	// usedItem is whatever the player selected in the inventory.
		bool itemWasUsed = false;
		// Check through the array of interactables objects. Interact with the closest one.
		if (CheckNearestObjectSlot () != -1) { // Since I've been using -1 as the response for an empty array.
			GameObject nearestInteractable = nearbyInteractables [CheckNearestObjectSlot ()];
			mono_actor_manager actorScript;
			// If the nearest thing is an Actor.
			if (nearestInteractable.tag.Trim ().Equals ("Actor".Trim ())) {
				actorScript = nearestInteractable.GetComponent<mono_actor_manager> ();
				// If it's looking for an item...
				if (actorScript.myCurrentBehavior.myGoal == ActorBehavior.BehaviorGoal.takeItem) {
					// If you've got the item the actor is looking for...
					if (usedItem == actorScript.myCurrentBehavior.itemToTake) {
						Debug.Log ("The Actor got the " + usedItem.itemName);
						itemWasUsed = true;
					} else {
						Debug.Log ("The Actor was looking for an item, but not this item.");
					}
				}
			}
		} else {
			Debug.Log ("No nearby Actors to use the Item on.");
		}
		return itemWasUsed;
	}

	// Check to see if the player entered the range of interactable objects.
	void OnTriggerEnter(Collider col){
		if (col.tag.Trim().Equals("Item".Trim()) || col.tag.Trim().Equals("KeyItem".Trim()) || col.tag.Trim().Equals("Dialogue".Trim()) || col.tag.Trim().Equals("Interactable".Trim()) || col.tag.Trim().Equals("Actor".Trim())){
			// UI on!
			exclamationUI.SetActive (true);
			// Add to array of nearby interactables.
			for (int i = 0; i < nearbyInteractables.Length; i++) {
				// If it finds a null slot, then it replaces it with the interactable.
				if (nearbyInteractables [i] == null) {
					nearbyInteractables [i] = col.gameObject;
					// This breaks the loop early
					return;
				}
			}
		}
	}

	// Check to see if the player exited the range of interactable objects.
	void OnTriggerExit(Collider col){
		if (col.tag.Trim().Equals("Item".Trim()) || col.tag.Trim().Equals("KeyItem".Trim()) || col.tag.Trim().Equals("Dialogue".Trim()) || col.tag.Trim().Equals("Interactable".Trim()) ||  col.tag.Trim().Equals("Actor".Trim())){
			// Remove from list of nearby interactables.
			for (int i = 0; i < nearbyInteractables.Length; i++) {
				// Remove the interactable from the array.
				if (nearbyInteractables [i] == col.gameObject) {
					nearbyInteractables [i] = null;
					// This breaks the loop early
					return;
				}
			}
		}
	}
}