using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_player_movement : MonoBehaviour {

	Rigidbody2D rbody; // Variable to hold a reference to our rigidbody.

	float moveSpeed = 5f;
	float currentMoveSpeed;

	float inputX;
	float inputY;

	Vector3 moveVec; // tracks rigidbody movement

	public Camera mainCamera; // Holds the main camera. This allows the player script to tell it when to move.

	void Start () {
		rbody = GetComponent<Rigidbody2D> ();
		currentMoveSpeed = moveSpeed;
	}
	void Update(){

		// Directional Movement Controls

		inputX = Input.GetAxis ("Horizontal"); // A/D, LeftArrow/RightArrow
		inputY = Input.GetAxis ("Vertical"); // W/S, UpArrow/DownArrow

		if (inputX != 0 && inputY != 0) {
			currentMoveSpeed = moveSpeed * .8f;
		} else {
			currentMoveSpeed = moveSpeed;
		}

		moveVec = transform.up * inputY * currentMoveSpeed // Forward and backward movement
			+ transform.right * inputX * currentMoveSpeed; // Left and right movement
		transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);// The all important background Z-space layer movement experiment.
	
	}

	// FixedUpdate is called once per *PHYSICS* frame, at a fixed framerate. (Fixed frame is run at it's own framerate, indepedent of the visual framerate and sound framerate)
	void FixedUpdate () {
		// Movement actually executes in Fixed Update, as it is a physics-based operation.
		rbody.velocity = moveVec;
	}

	public void Warp(Vector3 warpVec, Vector3 cameraVec){
		// For screen transitions.
		transform.position = warpVec;
		mainCamera.transform.position = cameraVec;
		//Debug.Log ("Warped");
	}
}
