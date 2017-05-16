using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_3d_anim_test : MonoBehaviour {

	Animator anim;

	float inputX;
	float inputY;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		inputX = Input.GetAxis("Horizontal");
		inputY = Input.GetAxis("Vertical");

		if (inputX < -.001f || inputX > .001f || inputY > .001f || inputY < -.001f) {
			anim.SetBool ("walk", true);
		} else {
			anim.SetBool ("walk", false);
		}

		//anim.SetFloat("inputX", Input.GetAxis ("Horizontal"));
		//anim.SetFloat("inputY", Input.GetAxis ("Vertical"));
	}
}
