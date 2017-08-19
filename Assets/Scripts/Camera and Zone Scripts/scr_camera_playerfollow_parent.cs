using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_camera_playerfollow_parent : MonoBehaviour {

	// This is a debug script for an object that allows the camera to follow the player without also tracking the rotation.

	public Transform playerParent;

	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3 (playerParent.transform.position.x, 0f, playerParent.transform.position.z);
	}
}
