using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_rig_controller : MonoBehaviour {

	float inputX;
	float inputY;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		inputX = Input.GetAxis("Horizontal");
		inputY = Input.GetAxis("Vertical");

		Vector3 look = new Vector3(inputX, 0.0f, inputY);
		transform.rotation = Quaternion.LookRotation(look);
	}
}
