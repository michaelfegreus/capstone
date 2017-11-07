using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mono_blackboard : MonoBehaviour {

	// Load the ScriptableObject serialized blackboard asset.
	public BlackboardSerialized loadedBlackboard;

	public Dictionary<string, float> worldBlackboard;

	void Awake(){
		// Initialize dictionary:
		worldBlackboard = new Dictionary<string, float> ();
		// Elements from ScriptableObject go inside the dictionary!
		for (int i = 0; i < loadedBlackboard.myFactCollection.Length; i++) {
			worldBlackboard.Add (loadedBlackboard.myFactCollection [i].factNameKey, loadedBlackboard.myFactCollection [i].factValue);
		}
	}
}
