using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_camera_zone : MonoBehaviour {

	public Camera myCam;

	// Use this for initialization
	void OnTriggerEnter (Collider col) {
		if (col.tag == ("Player")) {

			// Goes through every enabled camera and disables them.
			for (int i = 0; i < Camera.allCameras.Length; i++) {
				Camera.allCameras [i].enabled = false;
			}

			myCam.enabled = true;
		}
	}
}
