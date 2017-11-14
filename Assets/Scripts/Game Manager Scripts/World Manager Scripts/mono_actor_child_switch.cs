using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mono_actor_child_switch : MonoBehaviour {

	// Use this Dictionary system to switch out the GameObject holding the model and collider of an actor. I think it's a pretty solid solution.
	// i.e. The giant plant as it grows will switch out with deterministic models of it's different sizes.
	// Or, it could be used to swap out NPC rigs as the transform over the course of the game.

	// *** ALTERNATIVELY, I could just have the ActorBehavior asset have a reference to the prefab, and then it just checks to see if has the right prefab...? Going to try that now.

	[System.Serializable]
	public class ChildObjectState
	{
		public string objectStateName;
		public GameObject childObject;
	}

	public ChildObjectState[] childArray;

	public Dictionary<string, GameObject> myChildStates;

	void Awake(){
		// Initialize dictionary:
		myChildStates = new Dictionary<string, GameObject> ();
		// Elements from the ChildObjectState public array go inside the dictionary!
		for (int i = 0; i < childArray.Length; i++) {
			myChildStates.Add (childArray [i].objectStateName, childArray [i].childObject);
		}
	}
}
