using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class BehaviorCollection : ScriptableObject {

	// These are important behaviors to be checked and acted upon first.
	// i.e. "Cat gives the player the keys at the beginning of the game."
	public Behavior[] highPriorityBehaviors;

	// Other events that rely on world facts.
	// i.e. "You should start gardening in the afternoons if the Giant Plant is at a growth of 5.5f or higher, and you aren't fully transformed."
	public Behavior[] mediumPriorityBehaviors;

	// What to do if no major facts are affecting the actor.
	// i.e. "Go home at 6pm on a normal day."
	public Behavior[] idlePriorityBehaviors;


	// Geez I hope this all works.
}