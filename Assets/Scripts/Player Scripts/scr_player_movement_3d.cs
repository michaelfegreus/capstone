using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_player_movement_3d : MonoBehaviour {

	Rigidbody rbody; // Variable to hold a reference to our rigidbody.

	public float moveSpeed;
	float currentMoveSpeed;

	float scaleAmount;

	//public GameObject scalerObject;
	//float scalerDistance;

	/*public float scalingNumber;
	Vector3 playerHeightVec;
	float playerHeight;
	float playerDepth;
	Vector3 newPlayerHeightVec;
	float newPlayerHeight;*/

	float inputX;
	float inputY;

	Vector3 moveVec; // tracks rigidbody movement

	public Camera mainCamera; // Holds the main camera. This allows the player script to tell it when to move.

	void Start () {
		rbody = GetComponent<Rigidbody> ();
		currentMoveSpeed = moveSpeed;
	}
	void Update(){

		// Directional Movement Controls

		inputX = Input.GetAxis ("Horizontal"); // A/D, LeftArrow/RightArrow
		inputY = Input.GetAxis ("Vertical"); // W/S, UpArrow/DownArrow

		Vector3 forward = mainCamera.transform.forward;
		Vector3 right = mainCamera.transform.right;

		if (inputX != 0 && inputY != 0) {
			currentMoveSpeed = moveSpeed * .8f;
		} else {
			currentMoveSpeed = moveSpeed;
		}

		forward.y = 0f;
		right.y = 0f;
		forward.Normalize ();
		right.Normalize ();

		Vector3 desiredMoveDirection = forward * inputY + right * inputX;


		moveVec = forward * inputY * currentMoveSpeed // Forward and backward movement
			+ right * inputX * currentMoveSpeed // Left and right movement
			+ Physics.gravity; // Always apply gravity.
		//transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);// The all important background Z-space layer movement experiment.

		//transform.position = transform.position + Camera.main.transform.forward * 2f * Time.deltaTime;

		/*transform.localEulerAngles = 
			new Vector3	(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z);*/

		/*float sizeChange = transform.localPosition.z;
		sizeChange = sizeChange * (-1f);
		sizeChange *= scaleAmount;

		transform.localScale = new Vector3 (sizeChange, sizeChange, sizeChange);*/

		/*playerHeightVec = transform.localScale;
		playerDepth = transform.position.z;
		playerHeight = transform.localScale.y;
		playerHeight = scalingNumber * playerDepth;
		playerHeight = playerHeight;
		newPlayerHeightVec = new Vector3 (playerHeight, playerHeight, playerHeight);
		transform.localScale = newPlayerHeightVec;*/

		//More Prototype Scaling code

		/*scalerDistance = Vector3.Distance (this.gameObject.transform.position, scalerObject.transform.position);
		float sizeChange = scalerDistance; 
		scaleAmount = sizeChange * -1f;
		transform.localScale = new Vector3 (sizeChange, sizeChange, sizeChange);*/



		/*if (inputY > 0) {
			transform.localScale += new Vector3 (-0.01f, -0.01f, -0.01f);
		}
		if (inputY < 0) {
			transform.localScale += new Vector3 (0.01f, 0.01f, 0.01f);
		}*/


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
