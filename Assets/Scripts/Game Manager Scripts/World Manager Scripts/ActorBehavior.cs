﻿using System.Collections;
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

	public Fact[] factsRequired; // What facts must return at which values in order to run this Behavior?

	// The goal for this Actor while performing this before (if there is a goal).
	public enum BehaviorGoal{

		noGoal, conversationGoal, shareZoneGoal, keyItemPickup, giveItemGoal, deactivateActor, takeItem
		// NoGoal when the Actor is waiting for the next step of things to do.
		// DeactivateActor when you're finished using this Actor and don't want to check for updates on it further. This is the dead end of it.
	}

	// Ranks for importance of assigning this behavior.
	public enum BehaviorPriority{

		highPriority, midPriority, idlePriority

	}
}
