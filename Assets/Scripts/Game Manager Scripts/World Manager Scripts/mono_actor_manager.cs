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

	void Start(){
		dialogScript = GetComponent<scr_mytext_check> ();
		zoneScript = GetComponent<mono_actor_zone_check> ();
		playerZoneScript = thePlayer.GetComponent<mono_actor_zone_check> ();
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
			if (playerZoneScript.myCurrentZone == zoneScript.myCurrentZone) {
				Debug.Log ("Sharing zone, and the player saw me.");
				goalComplete = true;
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
}