﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_player_movement_rigidbody : MonoBehaviour {

	public float baseMoveSpeed;
	float moveSpeed;
	public float baseRotationSpeed;
	public float walkRotationSpeed;
	public float runRotationSpeed;
	float rotationSpeed;

	public float jumpForce;
	public float groundDrag;
	public float airDrag;

	bool moving;
	bool jump;

	public bool free = true;

	float inputX = 0f;
	float inputY = 0f;

	RaycastHit hit;

	Vector3 movement;

	Rigidbody rb;

	//public Transform moveCursor; // The cursor that the player moves towards.

	Vector3 lastDirection;
	public float oppositeDirectionThreshold; // Range for the detection of the opposite direction turnaround.

	float angleDifference; // The difference between the angle of the current rotation and the desired rotation. If it's above 180 degrees, skid.

	public bool onGround = true;
	bool running = false;

	float movingStopTimer = 0f;

	// Alpha dustcloud fun times.
	public GameObject dustcloudPrefab;
	public GameObject smallDustcloudPrefab; // For transitioning between walk and run
	public GameObject dustcloudCircle; // For jumping / pivoting.
	// Place where dustclouds start.
	public Transform dustcloudSpawn;
	// Times the intervals between dustclouds.
	float dustcloudTimer = 0f;
	// How long you've been running
	float runningTimer = 0f;
	float endRunTimer = 100f; // Start with high number so it doesn't trigger until ready

	// Windzone for stepping on and displacing grass or other terrain elements.
	WindZone grassStep;

	scr_player_groundcheck groundcheckScript;

	void Start () {
		moveSpeed = baseMoveSpeed;
		rotationSpeed = baseRotationSpeed;
		rb = GetComponent<Rigidbody> ();
		rb.drag = groundDrag;

		grassStep = GetComponent<WindZone> ();
		grassStep.windTurbulence = 0f;

		groundcheckScript = GetComponent<scr_player_groundcheck> ();
	}

	void Controls(){
		// see RigidbodyControl.cs for full info on these input axes
		inputX = Input.GetAxis("Horizontal");
		inputY = Input.GetAxis("Vertical");

		if (!moving) {
			rotationSpeed = baseRotationSpeed;
		} else if (moving && !running) {
			rotationSpeed = walkRotationSpeed;
		} else if (moving && running) {
			rotationSpeed = runRotationSpeed;
		}

		// Temporary run controls
		if (Input.GetKeyDown (KeyCode.JoystickButton1)) {
			moveSpeed = baseMoveSpeed *2;
			running = true;
		}
		if (Input.GetKeyUp (KeyCode.JoystickButton1)) {
			EndRun ();
			moveSpeed = baseMoveSpeed;
			running = false;
		}
		if(Input.GetKeyDown (KeyCode.JoystickButton0) && onGround){
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

			if (inputX < -.01f || inputX > .01f || inputY > .01f || inputY < -.01f) {
				//transform.rotation = Quaternion.LookRotation (movement);
				transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation (movement), Time.deltaTime * rotationSpeed); // Trying to reach analog stick's rotation angle.
				//transform.rotation = Quaternion.Lerp(transform.rotation, moveCursor.rotation, Time.deltaTime * rotationSpeed);
			} else {
				if (running) {
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

			grassStep.windTurbulence = 1.75f;
		}

		// Checks to see if, while walking/running, the player has dramatically changed the direction of desired movement vs. the current rotation.
		if (movement != Vector3.zero) {
			angleDifference = Quaternion.Angle (transform.rotation, Quaternion.LookRotation (movement));
			if (angleDifference > 90f) {
				Debug.Log (angleDifference);
				Instantiate (dustcloudCircle, transform.position, transform.rotation);
			}
		}

		DustcloudCheck ();
	}


	void FixedUpdate(){
		
		Ray groundRay = new Ray(transform.position, -transform.up);
		if (Physics.Raycast(groundRay, out hit, 1000f)) {
			// Sets you to heightAdjust's distance above the ground.
		}
			
		if (onGround) {
			// Move input that pushes the character forward towards the direction faced
			if (inputX < -.01f || inputX > .01f || inputY > .01f || inputY < -.01f) {
				// If you're already facing the direction, apply velocity. Otherwise, turn before beginning to walk.
				if (angleDifference > 5f && !moving) {
					Debug.Log ("Rotating to target direction");
				}else{
					if (!moving) {
						moving = true;
						movingStopTimer = 0f;
					}
					rb.AddForce (transform.forward * moveSpeed, ForceMode.Impulse);
					grassStep.windTurbulence = 1.4f;
				}
			}
			// If you're on the ground and not moving
			else {
				if (onGround) {
					if (moving) {
						MovingStopCheck ();
					}
					grassStep.windTurbulence = 0f;
				}
			}

			// Jump input
			if(jump) {

				Instantiate (dustcloudCircle, transform.position, transform.rotation);

				jump = false;

				rb.drag = airDrag;
				rb.AddForce (transform.up * jumpForce, ForceMode.Impulse);
				onGround = false;
				// Ground drag off, air drag on
			}
		}
	}

	void DustcloudCheck(){
		// Dust cloud scripting:
		// If running and on ground (makes sure you are moving).
		// Also keeps track of how long you've been running.
		if (running && onGround && (inputX < -.01f || inputX > .01f || inputY > .01f || inputY < -.01f)) {
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

	void MovingStopCheck(){
		movingStopTimer += Time.deltaTime;
		if (movingStopTimer > .1f) {
			moving = false;
		}
	}
}
