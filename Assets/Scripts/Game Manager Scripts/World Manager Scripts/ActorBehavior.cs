using System.Collections;
using UnityEngine;

[System.Serializable]
public class ActorBehavior {

	public string behaviorName; // For now, let's just start with getting the behavior names going.
	public BehaviorPriority executionPriority; // Haven't built implementation for this yet in the fact check function of mono_world_behavior_assigner - will do eventually.

	// What is required to satisfy the behavior:
	public BehaviorGoal myGoal;
	// If there's a goal, what fact should be altered to what value?
	public Fact factChangeOnGoal;

	public bool hasDestinationLocation;
	public Vector3 destinationLocation;

	// Item to give to player for this behavior.
	public Item itemToGive;
	// Item to take or check from the player for this behavior.
	public Item itemToTake;

	//public string childStateSwitchKey; // If it's a setActiveChildPrefab goal, what does this thing transform into?
	// *** ALTERNATIVELY, I could just have the ActorBehavior asset have a reference to the prefab, and then it just checks to see if has the right prefab...?
	public GameObject childStateSwitch; // ^ Use this variable if done with references like said above.

	public Fact[] factsRequired; // What facts must return at which values in order to run this Behavior?

	public TextAsset behaviorDialogText; // This might not be the best overall way to do it, since you won't always want things to say the same things on a behavior, but for now, the Actor can load its scr_mytext_check with this.

	// The goal for this Actor while performing this before (if there is a goal).
	public enum BehaviorGoal{

		noGoal, conversationGoal, shareZoneGoal, keyItemPickup, giveItemGoal, deactivateActor, takeItem, transformActorChildState
		// NoGoal when the Actor is waiting for the next step of things to do.
		// DeactivateActor when you're finished using this Actor and don't want to check for updates on it further. This is the dead end of it.
	}

	// Ranks for importance of assigning this behavior.
	public enum BehaviorPriority{

		highPriority, midPriority, idlePriority

	}
}
