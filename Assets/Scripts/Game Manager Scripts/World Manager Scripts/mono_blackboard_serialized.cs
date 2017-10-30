using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mono_blackboard_serialized : MonoBehaviour{

	// List of facts. This list can be serialized.
	public FactCollection factsFromAsset;
	public Dictionary<string, float> factBlackboard;

	void Awake(){
		factBlackboard = new Dictionary<string, float> ();
		for (int i = 0; i < factsFromAsset.myFactCollection.Length; i++) {
			factBlackboard.Add (factsFromAsset.myFactCollection [i].factNameKey, factsFromAsset.myFactCollection [i].factValue);
		}
	}
}