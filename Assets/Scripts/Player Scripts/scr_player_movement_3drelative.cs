using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_player_movement_3drelative : MonoBehaviour {

	float inputX;
	float inputY;

	public Camera mainCam;

	public float moveSpeed;
	float currentMoveSpeed;

	Rigidbody rbody;

	// Use this for initialization
	void Start () {
		currentMoveSpeed = moveSpeed;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		inputX = Input.GetAxis ("Horizontal"); // A/D, LeftArrow/RightArrow
		inputY = Input.GetAxis ("Vertical"); // W/S, UpArrow/DownArrow

		Vector3 forward = mainCam.transform.forward;
		Vector3 right = mainCam.transform.right;

		/*if (inputX != 0 && inputY != 0) {
			currentMoveSpeed = moveSpeed * .95f;
		} else {
			currentMoveSpeed = moveSpeed;
		}*/

		forward.y = 0f;
		right.y = 0f;
		forward.Normalize ();
		right.Normalize ();

		Vector3 desiredMoveDirection = forward * inputY + right * inputX;

		transform.Translate(desiredMoveDirection * currentMoveSpeed * Time.deltaTime);
	}
}
