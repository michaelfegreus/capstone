using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mono_behavior_manager : MonoBehaviour {

	// Current Behavior asset to read info from and act upon.
	public Behavior currentBehavior;
	// Dialog script to check if the player has talked to this object.
	scr_mytext_check dialogScript;
	// Blackboard of Facts about this object.
	mono_blackboard_serialized myBlackboard;

	// If the Behavior is looking for a conversation, and has had it, mark this as true.
	public bool checkConversation;

	// If the current Behavior's needs have been completed.
	public bool behaviorCompleted;

	void Start(){
		dialogScript = GetComponent<scr_mytext_check> ();
		myBlackboard = GetComponent<mono_blackboard_serialized> ();
	}

	void Update(){

		// When the current Behavior is looking to satisfy a conversation with the player.
		if (currentBehavior.waitingForConversation) {
			if (dialogScript.myTextBeingAccessed) {
				Debug.Log ("We had a conversation.");
				checkConversation = true;
				CheckCompleteBehavior ();
			}
		}
	}

	// Prepares for incoming Behavior from list of Behaviors
	public void SetNewBehavior(Behavior newBehavior){
		checkConversation = false;
		behaviorCompleted = false;
		currentBehavior = newBehavior;
	}

	void CheckCompleteBehavior(){
		if (currentBehavior.waitingForConversation && checkConversation) {
			behaviorCompleted = true;
		}
		if (behaviorCompleted) {
			Debug.Log ("Behavior complete. Should check for the next Behavior, and set any facts that need to be set.");
	
			// Goes to the blackboard, finds out what fact needs to be modified from the associated factToModify, then changes the fact according to to the modifyValue variable.
			// So if it's a fact about how many times the player has talked to this character, it should add 1 to the fact on dialog trigger.
			myBlackboard.factBlackboard [currentBehavior.factToModify] += currentBehavior.modifyValue;
			Debug.Log ("How many times spoken to player according to the blackboard: " + myBlackboard.factBlackboard [currentBehavior.factToModify]);
		}
	}


}
