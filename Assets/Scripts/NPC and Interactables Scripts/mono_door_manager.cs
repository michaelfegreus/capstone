using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mono_door_manager : MonoBehaviour {

	// To tell which side of the door is being opened.
	public GameObject doorFront;
	public GameObject doorBack;

	mono_interactable_door doorFrontScript;
	mono_interactable_door doorBackScript;

	// To run the animator
	Animator anim;

	bool open = false;

	// Track how long until the door will automatically close.
	float doorOpenTimer = 0f;
	float doorOpenTimeLimit = 3f;

	void Start(){
		doorFrontScript = doorFront.GetComponent<mono_interactable_door> ();
		doorBackScript = doorBack.GetComponent<mono_interactable_door> ();

		anim = GetComponent<Animator> ();
	}

	void Update(){
		if (doorFrontScript.doorOpen && !open || doorBackScript.doorOpen && !open) {
			OpenDoor ();
			// Reset the bools.
			doorFrontScript.doorOpen = false;
			doorBackScript.doorOpen = false;
		}
		if (open) {
			doorOpenTimer += Time.deltaTime;
			if (doorOpenTimer > doorOpenTimeLimit) {
				CloseDoor ();
				doorOpenTimer = 0f;
			}
		}
	}

	void OpenDoor(){
		Debug.Log ("Open sesame and such.");
		anim.SetBool ("doorOpen", true);
		doorFront.SetActive (false); // Turn off so you don't interact or collide with them again while it's opening.s
		doorBack.SetActive (false);
		open = true;
	}

	void CloseDoor(){
		anim.SetBool ("doorOpen", false);
		doorFront.SetActive (true);
		doorBack.SetActive (true);
		open = false;
	}
}
