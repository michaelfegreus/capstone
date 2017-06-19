using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_player_movement_rigidbody : MonoBehaviour {

	public float baseMoveSpeed;
	float moveSpeed;

	public float jumpForce;
	public float groundDrag;
	public float airDrag;

	bool jump;

	public bool free = true;

	float inputX = 0f;
	float inputY = 0f;

	RaycastHit hit;

	Vector3 movement;

	Rigidbody rb;

	public bool onGround = true;
	bool holdingRunButton = false;

	// Alpha dustcloud fun times.
	public GameObject dustcloudPrefab;
	public GameObject smallDustcloudPrefab; // For transitioning between walk and run
	// Place where dustclouds start.
	public Transform dustcloudSpawn;
	// Times the intervals between dustclouds.
	float dustcloudTimer = 0f;
	// How long you've been running
	float runningTimer = 0f;
	float endRunTimer = 100f; // Start with high number so it doesn't trigger until ready

	scr_player_groundcheck groundcheckScript;

	void Start () {
		moveSpeed = baseMoveSpeed;
		rb = GetComponent<Rigidbody> ();
		rb.drag = groundDrag;

		groundcheckScript = GetComponent<scr_player_groundcheck> ();
	}

	void Controls(){
		// see RigidbodyControl.cs for full info on these input axes
		inputX = Input.GetAxis("Horizontal");
		inputY = Input.GetAxis("Vertical");

		// Temporary run controls
		if (Input.GetKeyDown (KeyCode.Joystick1Button1)) {
			moveSpeed = baseMoveSpeed *2;
			holdingRunButton = true;
		}
		if (Input.GetKeyUp (KeyCode.Joystick1Button1)) {
			EndRun ();
			moveSpeed = baseMoveSpeed;
			holdingRunButton = false;
		}
		if(Input.GetKeyDown (KeyCode.Joystick1Button0) && onGround){
			jump = true;
		}
	}

	void EndRun(){
		
		// If you've been running for a bit, start the cooldown on the run dust clouds.
		if (runningTimer > .4f) {
			endRunTimer = 0f;
		}
		runningTimer = 0f;
	}

	public void ResetMovementValues(){
		rb.velocity = Vector3.zero;
		inputX = 0f;
		inputY = 0f;
		EndRun ();
	}

	void Update () {

		onGround = groundcheckScript.onGround;
		
		Controls ();

		if (onGround) {

			rb.drag = groundDrag;

			movement = new Vector3 (inputX, 0.0f, inputY);
			if (inputX < -.001f || inputX > .001f || inputY > .001f || inputY < -.001f) {
				transform.rotation = Quaternion.LookRotation (movement);
			} else {
				if (holdingRunButton) {
					EndRun ();
				}
			}

			// Lerp from the air drag to the ground drag
			if (rb.drag != groundDrag) {
				rb.drag = Mathf.Lerp (rb.drag, groundDrag, .02f);
				if (groundDrag - rb.drag < 0.5f) {
					rb.drag = groundDrag;
				}
			}
		} else {
			rb.drag = airDrag;
		}

		// If running and on ground (makes sure you are moving).
		// Also keeps track of how long you've been running.
		if (holdingRunButton && onGround && (inputX < -.001f || inputX > .001f || inputY > .001f || inputY < -.001f)) {
			runningTimer += Time.deltaTime;
			// Play with the .3f value to change how frequently they appear.
			if (runningTimer > .15f && runningTimer < .4f) {
				if (dustcloudTimer > .05f) {
					// Instantiate dustclouds roughly at feet location.
					Instantiate (smallDustcloudPrefab, dustcloudSpawn.position, transform.rotation);
					dustcloudTimer = 0f;
				} else {
					dustcloudTimer = dustcloudTimer + Time.deltaTime;

				}
			}
			if (runningTimer > .4f) {
				if (dustcloudTimer > .05f) {
					// Instantiate dustclouds roughly at feet location.
					Instantiate (dustcloudPrefab, dustcloudSpawn.position, transform.rotation);
					dustcloudTimer = 0f;
				} else {
					dustcloudTimer = dustcloudTimer + Time.deltaTime;
				}
			}
		}
		// To transition out of run
		if (endRunTimer < .3f) {
			if (dustcloudTimer > .05f) {
				// Instantiate dustclouds roughly at feet location.
				Instantiate (smallDustcloudPrefab, dustcloudSpawn.position, transform.rotation);
				dustcloudTimer = 0f;
			} else {
				dustcloudTimer += Time.deltaTime;
			}
			endRunTimer += Time.deltaTime;
		}

	}


	void FixedUpdate(){
		
		Ray groundRay = new Ray(transform.position, -transform.up);
		if (Physics.Raycast(groundRay, out hit, 1000f)) {
			// Sets you to heightAdjust's distance above the ground.
		}

		if (onGround) {
			// Move input that pushes the character forward towards the direction faced
			if (inputX < -.001f || inputX > .001f || inputY > .001f || inputY < -.001f) {
				rb.AddForce (transform.forward * moveSpeed, ForceMode.Impulse);
			}

			// Jump input
			if(jump) {
				
				jump = false;

				rb.drag = airDrag;
				rb.AddForce (transform.up * jumpForce, ForceMode.Impulse);
				onGround = false;
				// Ground drag off, air drag on
			}
		}
	}
}
