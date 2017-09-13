using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_player_movement_rigidbody : MonoBehaviour {

	public float baseMoveSpeed;
	float targetMoveSpeed;
	float currentMoveSpeed = 0f;
	public float accelerationRate; // Rate at which the player accelerates to meet the target velocity.
	public float deccelerationRate;
	public float skidDeccelerationRate; // How quickly the player slows to a stop when skidding.
	public float skidRegainControlSpeed; // What speed does the player have to deccelerate to in order to begin moving again after a skid.
	public float skidJumpForce; // How far forward you leap when jumping during a skid.

	Quaternion desiredRotation; // Calculated rotation of where the player is analog sticks are rotating the player towards.

	public float baseRotationSpeed;
	public float walkRotationSpeed;
	public float runRotationSpeed;
	float rotationSpeed; // Rate at which the player rotates to meet the target rotation. 
	public float pivotThreshold; // The degree of change in angle needed to pass the Pivot Check and skid.
	public float rotationToMoveThreshold; // The player must be have rotated to within this threshold to begin walking.
	Vector3 lastDirection;

	float angleDifference; // The difference between the angle of the current rotation and the desired rotation. If it's above 180 degrees, skid.

	public float jumpForce;
	public float groundDrag;
	public float airDrag;

	bool moving;
	bool jump;
	bool skidding;

	public bool free = true;

	float inputX = 0f;
	float inputY = 0f;

	RaycastHit hit;

	Vector3 movement;

	Rigidbody rb;

	//public Transform moveCursor; // The cursor that the player moves towards.


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
		targetMoveSpeed = baseMoveSpeed;
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

		// Consider changing this to a case statement series when implementing more run speeds.
		// Temporary run controls
		if (Input.GetKeyDown (KeyCode.JoystickButton1)) {
			targetMoveSpeed = baseMoveSpeed *2;
			running = true;
		}
		if (Input.GetKeyUp (KeyCode.JoystickButton1)) {
			EndRun ();
			targetMoveSpeed = baseMoveSpeed;
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
			desiredRotation = Quaternion.LookRotation (movement); // Get the desired rotation.

			// Checks to see if, while walking/running, the player has dramatically changed the direction of desired movement vs. the current rotation.
			if (movement != Vector3.zero && !skidding && onGround) {
				PivotCheck ();
			}

			if (inputX < -.01f || inputX > .01f || inputY > .01f || inputY < -.01f) {
				if(!skidding){ // Can only turn if you aren't currently skidding!
					transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed); // Trying to reach analog stick's rotation angle.
				}
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
		} else if (!onGround){
			rb.drag = airDrag;

			grassStep.windTurbulence = 1.75f;
		}

		DustcloudCheck ();
	}


	void FixedUpdate (){
		
		Ray groundRay = new Ray(transform.position, -transform.up);
		/*if (Physics.Raycast(groundRay, out hit, 1000f)) {
			// Sets you to heightAdjust's distance above the ground.
		}*/
			
		if (onGround) {
			// Move input that pushes the character forward towards the direction faced
			if (inputX < -.01f || inputX > .01f || inputY > .01f || inputY < -.01f) {
				if (!skidding) { // Can only change move speed if you're not skidding.
					// If you're already facing the direction, apply velocity. Otherwise, turn before beginning to walk.
					if (angleDifference > rotationToMoveThreshold && !moving) {
						Debug.Log ("Rotating to target direction");
					} else {
						if (!moving) {
							moving = true;
							movingStopTimer = 0f;
						}
						// Lerp to the desired movement speed.
						if (currentMoveSpeed < targetMoveSpeed) { // Must accelerate.
							currentMoveSpeed = Mathf.Lerp (currentMoveSpeed, targetMoveSpeed, Time.deltaTime * accelerationRate);
						} else if (currentMoveSpeed > targetMoveSpeed) { // Must deccelerate.
							currentMoveSpeed = Mathf.Lerp (currentMoveSpeed, targetMoveSpeed, Time.deltaTime * deccelerationRate);
						}
						// Apply force to begin moving!
						rb.AddForce (transform.forward * currentMoveSpeed, ForceMode.Impulse);
						grassStep.windTurbulence = 1.4f;
					}
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

				//Instantiate (dustcloudCircle, transform.position, transform.rotation);

				jump = false;

				rb.drag = airDrag;
				rb.AddForce (transform.up * jumpForce, ForceMode.Impulse);
				onGround = false;

				if (skidding) { // Bounce in the opposite direction if you're skidding, on top of jumping upwards.
					transform.rotation = desiredRotation;
					rb.AddForce (transform.forward * skidJumpForce, ForceMode.Impulse);
					skidding = false;
				}

				// Ground drag off, air drag on
			}
		}
		if (skidding) {
			Skid ();
		}
	}

	void PivotCheck(){
		angleDifference = Quaternion.Angle (transform.rotation, desiredRotation);
		if (angleDifference > pivotThreshold) {
			//Debug.Log (angleDifference);
			if(moving && running && onGround){
				//transform.rotation =
				//Instantiate (dustcloudCircle, transform.position, transform.rotation);
				Debug.Log ("Begin skid");
				skidding = true;
			}
		}
	}

	void Skid(){
		// Eventually, this will pair with animation.
		if (currentMoveSpeed > skidRegainControlSpeed) {
			rb.AddForce (transform.forward * currentMoveSpeed, ForceMode.Impulse); // Continue to apply force as you slow down to get a decceleration, not an abrupt stop.
			currentMoveSpeed = Mathf.Lerp (currentMoveSpeed, 0f, Time.deltaTime * skidDeccelerationRate);
			Debug.Log ("Skidding!");
		} else if (currentMoveSpeed < skidRegainControlSpeed || !onGround){ // Skid stops when you slow down enough OR when you leave the ground.
			transform.rotation = desiredRotation; // Flip around the character for the skid.
			skidding = false;
			Debug.Log ("End skid.");
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
			// Lerp to the desired movement speed of zero.
			if (currentMoveSpeed != 0f) {
				rb.AddForce (transform.forward * currentMoveSpeed, ForceMode.Impulse); // Continue to apply force as you slow down to get a decceleration, not an abrupt stop.
				currentMoveSpeed = Mathf.Lerp (currentMoveSpeed, 0f, Time.deltaTime * deccelerationRate);
			}
		}
	}
}
