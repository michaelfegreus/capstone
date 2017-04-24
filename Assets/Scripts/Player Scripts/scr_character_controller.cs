using UnityEngine;
using System.Collections;

public class scr_character_controller : MonoBehaviour {

	bool grounded = true;

	float inputX;
	float inputY;
	float mouseX;

	CharacterController cController;
	float jumpTimer;

	public float baseMoveSpeed;
	float moveSpeed;
	public float jumpHeight;

	public Camera mainCam;

	// Use this for initialization
	void Start () {
		cController = GetComponent<CharacterController>();
		moveSpeed = baseMoveSpeed;
	}

	// Update is called once per frame
	void Update () {
		// see RigidbodyControl.cs for full info on these input axes
		inputX = Input.GetAxis("Horizontal");
		inputY = Input.GetAxis("Vertical");
		mouseX = Input.GetAxis("Mouse X");

		// Temporary run controls
		if (Input.GetKeyDown (KeyCode.Joystick1Button1)) {
			moveSpeed = baseMoveSpeed *2;
		}
		if (Input.GetKeyUp (KeyCode.Joystick1Button1)) {
			moveSpeed = baseMoveSpeed;
		}

		// actually turn the player capsule now
		//transform.Rotate(0f, mouseX * 5f, 0f );

		// if player presses space bar...
		// then cController.Move upwards
		if ( Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown (KeyCode.Joystick1Button2) ) {
			jumpTimer = Time.time + jumpHeight;
		}

		if ( Time.time < jumpTimer ) {
			cController.Move( new Vector3(0f, jumpHeight, 0f) );
		}


		/*	Vector3 forward = mainCam.transform.forward;
			Vector3 right = mainCam.transform.right;

			forward.y = 0f;
			right.y = 0f;
			forward.Normalize ();
			right.Normalize ();
*/

		Vector3 movement = new Vector3(inputX, 0.0f, inputY);
		if (inputX < -.001f || inputX > .001f || inputY > .001f || inputY < -.001f) {
			transform.rotation = Quaternion.LookRotation (movement);
		}

		/*
		 transform.Translate(speed * movement.normalized * Time.deltaTime);
		 */
		// actually apply movement now
		//if (isGrounded()) {
		cController.SimpleMove (moveSpeed * movement.normalized * Time.deltaTime);
	//	}
	}
	void FixedUpdate(){
		
			

	}

	private bool isGrounded(){

		if (grounded) {
			return true;
		}

		Vector3 bottom = this.transform.position - new Vector3 (0, 1.5f / 2, 0);

		RaycastHit hit;
		if (Physics.Raycast (bottom, new Vector3 (0, -1, 0), out hit, 0.5f)) {
			cController.Move(new Vector3(0, hit.distance, 0));
			return true;
		}

		return false;
	}
}