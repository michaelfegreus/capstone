using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mono_blackboard : MonoBehaviour {

	//public Fact[] myFacts;

	public Dictionary<string, float> factBlackboard;

	void Start(){
		// Initialize dictionary:
		factBlackboard = new Dictionary<string, float>();

		// Elements inside the dictionary. Eventually going to want to serialize this.
		factBlackboard.Add("TimesSpokenToPlayer", 0f);
	}
}
