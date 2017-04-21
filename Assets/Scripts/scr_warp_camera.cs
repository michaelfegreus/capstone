﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_warp_camera : MonoBehaviour {

	// If switching actual cameras.
	public Camera myCam;
	public Camera newCam;

	GameObject thePlayer;

	void OnTriggerEnter(Collider col){
		if (col.tag == ("Player")) {
			thePlayer = col.gameObject;

			if (myCam.enabled == true) {
				myCam.enabled = false;
				newCam.enabled = true;
				thePlayer.GetComponent<scr_player_movement_3d> ().ChangeMainCamera (newCam);
			} else {
				newCam.enabled = false;
				myCam.enabled = true;
				thePlayer.GetComponent<scr_player_movement_3d> ().ChangeMainCamera (myCam);
			}
			Debug.Log ("Stuff");
		}
	}
}
