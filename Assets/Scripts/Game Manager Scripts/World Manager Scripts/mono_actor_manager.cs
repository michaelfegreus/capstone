using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mono_actor_manager : MonoBehaviour {

	public ActorBehavior myCurrentBehavior;

	bool hasGoal;
	public bool goalComplete;

	// Dialog script to check if the player has talked to this object.
	scr_mytext_check dialogScript;

	void Start(){
		dialogScript = GetComponent<scr_mytext_check> ();
	}

	void Update(){
		// If the current ActorBehavior has a goal, then check to see if it was completed!
		if (hasGoal) {
			GoalCheck ();
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
	}

	void GoalCheck(){
		// When the current ActorBehavior is looking to satisfy a conversation with the player.
		if (myCurrentBehavior.myGoal == ActorBehavior.BehaviorGoal.conversationGoal) {
			if (dialogScript.myTextBeingAccessed) {
				Debug.Log ("We had a conversation.");
				goalComplete = true;
			}
		}
	}
}