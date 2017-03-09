using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_anim_test : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat("inputX", Input.GetAxis ("Horizontal"));
		anim.SetFloat("inputY", Input.GetAxis ("Vertical"));
	}
}
