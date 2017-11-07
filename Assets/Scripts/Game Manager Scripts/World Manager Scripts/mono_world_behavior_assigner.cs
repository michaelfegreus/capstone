using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mono_world_behavior_assigner : MonoBehaviour {

	// Keep track of all the actors
	[System.Serializable]
	public class Actor{
		public string actorName;
		public BehaviorCollection actorBehaviorCollection;
		public GameObject actorGameObject;
		[System.NonSerialized]
		public mono_actor_manager actorScript;
	}

	// Holds all key actors, like the NPCs and the different game areas, and tells them what they should be doing.
	public Actor[] gameActors;

	// Blackboard script for the World Manager.
	mono_blackboard blackboardScript;

	void Start(){
		blackboardScript = GetComponent<mono_blackboard> (); // Get the script holding the World Blackboard dictionary.

		// Set every ActorBehaviorScript: 
		for (int s = 0; s < gameActors.Length; s++) {
			gameActors [s].actorScript = gameActors [s].actorGameObject.GetComponent<mono_actor_manager> ();
		}

		CheckActorStates (); // Get the Actors set up with their Behaviors!
	}

	void Update(){
		// Check to see if anyone has completed their goals.
		for (int a = 0; a < gameActors.Length; a++) {
			if (gameActors [a].actorScript.goalComplete) {
				Debug.Log ("Completed goal detected!");
				UpdateWorldBlackboard (gameActors [a].actorScript.myCurrentBehavior);
				CheckActorStates ();
			}
		}
	}

	// Run ths to see how high a score a Behavior gets.
	// Points are awarded depending on how many Fact requirements on the Behavior agree with the World Blackboard's current state of Facts.
	int CheckFactRank(ActorBehavior rankingBehavior){
		// Points for having matching facts.
		int rankScore = 0;

		// For every required fact of the Behavior...
		for (int f = 0; f < rankingBehavior.factsRequired.Length; f++) {
			string reqFact = rankingBehavior.factsRequired [f].factNameKey;
			float reqValue = rankingBehavior.factsRequired [f].factValue;

			if (blackboardScript.worldBlackboard [reqFact] == reqValue) {
				rankScore++; // Add to the rankScore if a fact matches.
			}
		}

		return rankScore;
	}

	void UpdateWorldBlackboard(ActorBehavior completedBehavior){
		string factChangeKey = completedBehavior.factChangeOnGoal.factNameKey;
		float factChangeValue = completedBehavior.factChangeOnGoal.factValue;
		// Now find the fact in the blackboard and change it.
		blackboardScript.worldBlackboard[factChangeKey] = factChangeValue;
	}

	// Run this to find out what ActorBehavior everyone should have right now.
	void CheckActorStates(){
		
		Actor currentActor; // The current actor to check and set Behaviors for.

		// Check every actor.
		for (int a = 0; a < gameActors.Length; a++) {
			
			currentActor = gameActors [a]; // Checking this guy currently.

			// Get at least one Behavior in there to not have a null.
			// If this throws an error at runtime, that means I have not set even one Behavior up for the Actor, which is unwanted!
			ActorBehavior highestRankedBehavior = currentActor.actorBehaviorCollection.myActorBehaviors [0];

			// Get a baseline for what to compare other Behaviors against.
			int highestRankValue = CheckFactRank (highestRankedBehavior);

			// For all the Behaviors held by this actor, check each one.
			// Start at index [1] because we've already got the thing from index [0] loaded in.
			for (int b = 1; b < currentActor.actorBehaviorCollection.myActorBehaviors.Length; b++) {

				// Rank of current Behavior being checked.
				int newRankValue = CheckFactRank(currentActor.actorBehaviorCollection.myActorBehaviors[b]);

				// If it beats the current high rank's value, it becomes the new high rank!
				if (newRankValue > highestRankValue) {
					highestRankValue = newRankValue;
					highestRankedBehavior = currentActor.actorBehaviorCollection.myActorBehaviors [b];
				}
			}
			// Done checking through all of the BehaviorCollection for this Actor.
			// Now set whatever you determined to be the winning behavior on the player

			// **** SET WINNING BEHAVIOR HERE
			//Debug.Log("Winning behavior name: " + highestRankedBehavior.behaviorName);
			gameActors [a].actorScript.SetNewBehavior (highestRankedBehavior);
		}
		// Done checking through all of the Actors. Great job~!
	}
}
