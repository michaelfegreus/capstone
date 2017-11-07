using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class FactCollection : ScriptableObject {

	// Okay, so this guy is a ScriptableObject asset that allows you to create a set of facts for an actor's blackboard to read from and set up a dictionary.
	// Basically, it's a way to create a set of facts that work across the board when you attach it.
	// At the start of runtime, the game will go through and take this set of facts and feed them to a dictionary that gets initialized on play.
	// Again, should be a good standard setup for a serialized dictionary.

	// The Fact class within this. This mimics the Key / Value setup that the dictionary will take from.
	/*[System.Serializable]
	public class Fact{
		public string factNameKey;
		public float factValue;
	}*/

	public Fact[] myFactCollection;
}
