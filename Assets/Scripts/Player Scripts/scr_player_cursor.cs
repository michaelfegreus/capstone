using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_player_cursor : MonoBehaviour {

	float inputX = 0f;
	float inputY = 0f;

	//float cursorMoveSpeed = 20f;


	//Vector3 movement;

	//float moveAngle;
	
	// Update is called once per frame
	void Update () {
		inputX = Input.GetAxis("Horizontal");
		inputY = Input.GetAxis("Vertical");

		// Directional movement when the analog stick is pushed.
		/*
		movement = new Vector3 (inputX, 0.0f, inputY);
		if (inputX < -.001f || inputX > .001f || inputY > .001f || inputY < -.001f) {
			transform.rotation = Quaternion.LookRotation (movement);
		}

		if (inputX < -.001f || inputX > .001f || inputY > .001f || inputY < -.001f) {
			transform.position += transform.forward * Time.deltaTime * cursorMoveSpeed;
		}*/

		/*if (inputX > .1) {
			transform.position = transform.position + new Vector3 (cursorMoveSpeed, 0f, 0f);
		}
		if (inputX < -.1) {
			transform.position = transform.position + new Vector3 (-cursorMoveSpeed, 0f, 0f);
		}
		if (inputY > .1) {
			transform.position = transform.position + new Vector3 (0f, 0f, cursorMoveSpeed);
		}
		if (inputY < -.1) {
			transform.position = transform.position + new Vector3 (0f, 0f, -cursorMoveSpeed);
		}*/

		//moveAngle = Mathf.Atan2 (inputX, inputY) * Mathf.Rad2Deg;
		//transform.rotation = Quaternion.Euler(new Vector3(0f,0f, moveAngle));
			
		//Debug.Log (moveAngle);

		// Reset position if no movement.
		if (inputX < .1f && inputX > -.1f && inputY > -.1f && inputY < .1f) {
			transform.localPosition = new Vector3 (0f, 0f, 0f);
		} else {
			// This limits how far it can move.
			// This is just for debug display visualization - the actual player script shouldn't care how far away the cursor is - just what direction it is from the player's position.
			/*if (transform.localPosition.x > 1f) {
				transform.localPosition = new Vector3 (1f, transform.localPosition.y, transform.localPosition.z);
			}
			if (transform.localPosition.x < -1f) {
				transform.localPosition = new Vector3 (-1f, transform.localPosition.y, transform.localPosition.z);
			}
			if (transform.localPosition.z > 1f) {
				transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y, 1f);
			}
			if (transform.localPosition.z < -1f) {
				transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y, -1f);
			}*/
		transform.localPosition = new Vector3 (0f, 0f, 2f);
		}
	}
}
