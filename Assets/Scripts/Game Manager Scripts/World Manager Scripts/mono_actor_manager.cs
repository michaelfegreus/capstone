using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mono_actor_manager : MonoBehaviour {

	public ActorBehavior myCurrentBehavior;

	bool hasGoal;
	public bool goalComplete;

	bool traveling;

	// Dialog script to check if the player has talked to this object.
	scr_mytext_check dialogScript;

	// For checking to see if their zones match.
	mono_actor_zone_check zoneScript;
	// This is messy with actors looking at each other, but it'll have to work for now.
	public GameObject thePlayer;
	mono_actor_zone_check playerZoneScript;
	// If the actor is a Key Item, and uses the item script...
	mono_item_pickup_manager itemPickupScript;
	// If it's the giant plant...
	mono_giantplant_level plantLevelScript;

	void Start(){
		if (GetComponent<scr_mytext_check> () != null) {
			dialogScript = GetComponent<scr_mytext_check> ();
		}
		if (GetComponent<mono_actor_zone_check> () != null) {
			zoneScript = GetComponent<mono_actor_zone_check> ();
		}
		if (thePlayer != null) { // Like said above, a messy system. I'll have to remember to attach the Player to anything that might be checking to see if they're in the same zone.
			playerZoneScript = thePlayer.GetComponent<mono_actor_zone_check> ();
		}
		if (GetComponent<mono_item_pickup_manager> () != null) {
			itemPickupScript = GetComponent<mono_item_pickup_manager> ();
		}
		if (GetComponent<mono_giantplant_level> () != null) {
			itemPickupScript = GetComponent<mono_item_pickup_manager> ();
		}
	}

	void Update(){
		// If the current ActorBehavior has a goal, then check to see if it was completed!
		if (hasGoal) {
			GoalCheck ();
		}
		// If there's a destination location for the current ActorBehavior, run traveling method.
		if (traveling) {
			Travel ();
		}
	}

	public void SetNewBehavior(ActorBehavior newBehavior){
		myCurrentBehavior = newBehavior;
		Debug.Log (this.name + " new ActorBehavior: " + myCurrentBehavior.behaviorName);

		goalComplete = false; // Reset goal.

		if (myCurrentBehavior.myGoal != ActorBehavior.BehaviorGoal.noGoal) {
			hasGoal = true;
		} else {
			hasGoal = false;
		}
		if (myCurrentBehavior.hasDestinationLocation) {
			traveling = true;
		} else {
			traveling = false;
		}

	}

	void GoalCheck(){
		// When the current ActorBehavior is looking to satisfy a conversation with the player.

		/*if (myCurrentBehavior.myGoal == ActorBehavior.BehaviorGoal.conversationGoal) {
			if (dialogScript.myTextBeingAccessed) {
				Debug.Log ("We had a conversation.");
				goalComplete = true;
			}
		}*/

		switch (myCurrentBehavior.myGoal) {

		case ActorBehavior.BehaviorGoal.conversationGoal:
			if (dialogScript.myTextBeingAccessed) {
				Debug.Log ("We had a conversation.");
				goalComplete = true;
			}
			break;
		
		case ActorBehavior.BehaviorGoal.shareZoneGoal:
			// Make sure that the Actor is sharing a zone with the player while not traveling.
			// The !traveling check ensures that the game doesn't trigger this twice immediately with back to back Share Zone behavior goals.
			if (playerZoneScript.myCurrentZone == zoneScript.myCurrentZone && !traveling) {
				Debug.Log ("Sharing zone, and the player saw me.");
				goalComplete = true;
			}
			break;
			/*
		case ActorBehavior.BehaviorGoal.keyItemPickup:
			if (gaveBehaviorItem) {
				Debug.Log ("I, a Key Item, got picked up.");
				gaveBehaviorItem = false; // Reset this bool for the next time
				goalComplete = true;
				gameObject.SetActive (false); // Deactivate after being picked up.
			}
			break;
*/
		case ActorBehavior.BehaviorGoal.giveItemGoal:
			if (gaveBehaviorItem) {
				Debug.Log ("We had a conversation, and I gave the player the item as a part of the conversation.");
				gaveBehaviorItem = false; // Reset this bool for the next time
				goalComplete = true;
			}

			break;

		case ActorBehavior.BehaviorGoal.deactivateActor:
			// DeactivateActor when you're finished using this Actor and don't want to check for updates on it further.
			// This is the dead end of this Actor.
			gameObject.SetActive(false);
			break;
		
		case ActorBehavior.BehaviorGoal.takeItem:
			if (tookBehaviorItem) {
				gaveBehaviorItem = false; // Reset this bool for the next time
				goalComplete = true; // This is for a one-time situation -- not for when it keeps taking the item, like with the plant and spirit water.
			}
			break;
		} 
	}
		
	void Travel(){
		// Get the Actor to the desired location.
		// Right now, we're warping the actor when the player moves off from being in the same screen.
		if (playerZoneScript.myCurrentZone != zoneScript.myCurrentZone) {
			gameObject.transform.position = myCurrentBehavior.destinationLocation;
			traveling = false;
		}
	}

	bool gaveBehaviorItem = false;

	public Item GetMyBehaviorItem(){
		// For the giveItemGoal, return items and check off that this happened.
		gaveBehaviorItem = true;
		return myCurrentBehavior.itemToGive;
	}

	bool tookBehaviorItem;

	public void TakeMyBehaviorItem(){
		// Fpr the takeItemGoal, the player interaction script should access this and give it to this actor.
		tookBehaviorItem = true;
	}
}