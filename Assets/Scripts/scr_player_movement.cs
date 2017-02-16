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

	// Test item
	public GameObject item;

	public Camera mainCamera; // Holds the main camera. This allows the player script to tell it when to move.

	void Start () {
		rbody = GetComponent<Rigidbody2D> ();
		currentMoveSpeed = moveSpeed;
	}

	void Update(){

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
	
		// Test placing items
		if (Input.GetKeyDown (KeyCode.X)) {
			Instantiate (item, this.transform.position, Quaternion.identity);
		}
	}

	// FixedUpdate is called once per *PHYSICS* frame, at a fixed framerate. (Fixed frame is run at it's own framerate, indepedent of the visual framerate and sound framerate)
	void FixedUpdate () {
		
		rbody.velocity = moveVec;
			//+ Physics.gravity; // Always apply gravity

		// Instead of using transform.position / transform.translate (basically teleportation), we're giving the rbody velocity to push it along organically.
		// This allows the player .to strafe. By the way, transform.left doesn't exist, so use transform.left and multiply it by -1
	}

	public void Warp(Vector3 warpVec, Vector3 cameraVec){
		transform.position = warpVec;
		mainCamera.transform.position = cameraVec;
		Debug.Log ("Warped");
	}
}
