using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_rig_controller : MonoBehaviour {

	Animator anim;

	float inputX;
	float inputY;

	//bool running = false;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

		// Temporary run controls
		if (Input.GetKeyDown (KeyCode.Joystick1Button1)) {
			//running = true;
			anim.SetBool ("running", true);
		}
		if (Input.GetKeyUp (KeyCode.Joystick1Button1)) {
			anim.SetBool ("running", false);
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
