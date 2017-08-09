using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_interactable_check : MonoBehaviour {

	public MonoBehaviour myScript;

	// This runs the "child" component that is unique to this interactable object.
	// i.e. a door script that is also attached to this object which opens when you interact with it
	public void RunAction(){
		myScript.enabled = true;
	}
}
