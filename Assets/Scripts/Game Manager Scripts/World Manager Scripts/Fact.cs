using System.Collections;
using System; // This allows the IComparable Interface
using UnityEngine;

[System.Serializable]
public class Fact /* : IComparable<Fact> */ { 

	public string factNameKey;
	public float factValue;
	//public string actorAssociated;

	public Fact(string newName, float newValue/*, string actor*/){
		factNameKey = newName;
		factValue = newValue;
		//actorAssociated = actor;
	}
	/*
	// This methor is required by the IComparable interface.
	public int CompareTo(Fact other){
		if (other == null) {
			return 1;
		}

		// Return the difference in power.
		retur
	}*/
}