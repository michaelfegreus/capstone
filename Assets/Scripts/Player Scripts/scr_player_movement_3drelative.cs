using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_player_movement_3drelative : MonoBehaviour {

	float inputX;
	float inputY;

	public Camera mainCam;

	public float moveSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		inputX = Input.GetAxis ("Horizontal"); // A/D, LeftArrow/RightArrow
		inputY = Input.GetAxis ("Vertical"); // W/S, UpArrow/DownArrow

		Vector3 forward = mainCam.transform.forward;
		Vector3 right = mainCam.transform.right;

		forward.y = 0f;
		right.y = 0f;
		forward.Normalize ();
		right.Normalize ();

		Vector3 desiredMoveDirection = forward * inputY + right * inputX;

		transform.Translate(desiredMoveDirection * moveSpeed * Time.deltaTime);
	}
}
