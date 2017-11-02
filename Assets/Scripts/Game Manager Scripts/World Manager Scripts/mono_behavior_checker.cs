using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mono_behavior_checker : MonoBehaviour {

	// Keep track of all the actors
	[System.Serializable]
	public class GameActor{
		public string actorName;
		public BehaviorCollection actorBehaviorCollection;
		public GameObject actorGameObject;
		[System.NonSerialized]
		public mono_behavior_manager actorBehaviorScript;
	}

	Renderer rend;

	public GameActor[] gameActors;

	void Start(){
		// Gets all the actors' Behavior Manager scripts
		for (int i = 0; i < gameActors.Length; i++) {
			gameActors[i].actorBehaviorScript = gameActors[i].actorGameObject.GetComponent<mono_behavior_manager>();
		}

		// Test giving a Behavior out by giving the first high priority behavior to the object.
		for (int i = 0; i < gameActors.Length; i++) {
			gameActors [i].actorBehaviorScript.SetNewBehavior (gameActors [i].actorBehaviorCollection.highPriorityBehaviors [0]);
		}


	}

}
