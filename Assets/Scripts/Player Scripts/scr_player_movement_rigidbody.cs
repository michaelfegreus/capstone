using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_player_movement_rigidbody : MonoBehaviour {

	public float baseMoveSpeed;
	float moveSpeed;

	public float jumpForce;
	public float myGravity;
	public float groundDrag;
	public float airDrag;

	public bool jump;

	public float heightAdjust;

	public bool inMenu = false;

	float inputX = 0f;
	float inputY = 0f;

	RaycastHit hit;

	Vector3 movement;

	Rigidbody rb;

	bool onGround = true;

	private delegate void StateMachine();
	private StateMachine stateMachine;

	void Start () {
		moveSpeed = baseMoveSpeed;
		rb = GetComponent<Rigidbody> ();
		rb.drag = groundDrag;
	}

	void WalkControls(){
		// see RigidbodyControl.cs for full info on these input axes
		inputX = Input.GetAxis("Horizontal");
		inputY = Input.GetAxis("Vertical");

		// Temporary run controls
		if (Input.GetKeyDown (KeyCode.Joystick1Button1)) {
			moveSpeed = baseMoveSpeed *2;
		}
		if (Input.GetKeyUp (KeyCode.Joystick1Button1)) {
			moveSpeed = baseMoveSpeed;
		}
	}
	void JumpControls(){ if(Input.GetKeyDown (KeyCode.Joystick1Button0)){ jump = true; } }

	void Update () {

		if (stateMachine != null) { stateMachine; }

		if (!inMenu) { stateMachine = WalkControls; stateMachine += JumpControls; }

		// Checks to see if you're on the ground and not falling currently.
		if (rb.velocity.y < 0.05f && Vector3.Distance (transform.position, hit.point) <= heightAdjust) {
			onGround = true;
			rb.drag = groundDrag;
			transform.position = new Vector3 (transform.position.x, hit.point.y + heightAdjust, transform.position.z);
			// Ground drag back on
			//Debug.Log("On Ground reset accessed");
		} else if (Vector3.Distance (transform.position, hit.point) > heightAdjust + 0.05f) {
			rb.drag = airDrag;
			onGround = false;
		}

		if (onGround) {
			movement = new Vector3 (inputX, 0.0f, inputY);
			if (inputX < -.001f || inputX > .001f || inputY > .001f || inputY < -.001f) {
				transform.rotation = Quaternion.LookRotation (movement);
			}

			// Lerp from the air drag to the ground drag
			if (rb.drag != groundDrag) {
				rb.drag = Mathf.Lerp (rb.drag, groundDrag, .02f);
				if (groundDrag - rb.drag < 0.5f) {
					rb.drag = groundDrag;
				}
			}
		}

		//Debug.Log ("Grounded : " + onGround);
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

		// Always apply significant gravity
		rb.AddForce (-transform.up * myGravity, ForceMode.Impulse);

		//Debug.Log (hit.point);
		Debug.DrawLine(transform.position, hit.point, Color.red);
	}
}
