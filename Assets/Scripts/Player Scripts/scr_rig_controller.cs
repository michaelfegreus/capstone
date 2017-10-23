using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_rig_controller : MonoBehaviour {

	Animator anim;

	float inputX;
	float inputY;

	// *** Try doubling the speed of the walk as a temporary fix. Delete this later.
	public float runAnimationPatchSpeed;

	//bool running = false;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

	}

	// Update is called once per frame
	void Update () {

		// Temporary run controls
		if (Input.GetKeyDown (KeyCode.JoystickButton1) || (Input.GetKeyDown (KeyCode.RightShift) )) {
			//running = true;
			anim.SetBool ("running", true);
			// *** Try doubling the speed of the walk as a temporary fix. Delete this later.
			anim.speed = runAnimationPatchSpeed;
		}
		if (Input.GetKeyUp (KeyCode.JoystickButton1) || (Input.GetKeyUp (KeyCode.RightShift) )) {
			anim.SetBool ("running", false);
			// *** Try doubling the speed of the walk as a temporary fix. Delete this later.
			anim.speed = 1.0f;
		}

		inputX = Input.GetAxis("Horizontal");
		inputY = Input.GetAxis("Vertical");

		if (inputX < -.001f || inputX > .001f || inputY > .001f || inputY < -.001f) {
			anim.SetBool ("moving", true);
		} else {
			anim.SetBool ("moving", false);
		}

		//anim.SetFloat("inputX", Input.GetAxis ("Horizontal"));
		//anim.SetFloat("inputY", Input.GetAxis ("Vertical"));
	}
}
