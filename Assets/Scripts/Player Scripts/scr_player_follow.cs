using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_player_follow : MonoBehaviour {

	// This script serves as a way for the player cursor to stay parented to the player's transform without getting the player's rotation as well.

	public Transform playerParent;

	float inputX = 0f;
	float inputY = 0f;

	float moveAngle;
	
	// Update is called once per frame
	void Update () {
		inputX = Input.GetAxis("Horizontal");
		inputY = Input.GetAxis("Vertical");

		this.transform.position = playerParent.transform.position;

		// Rotate based on the analog stick's rotation.
		moveAngle = Mathf.Atan2 (inputX, inputY) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0f, moveAngle, 0f));
	}
}
