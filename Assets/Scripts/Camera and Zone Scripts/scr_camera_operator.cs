using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_camera_operator : MonoBehaviour {

	Camera currentCam;

	public GameObject thePlayer;

	public void SetNewCamera(Camera newCam){
		Camera oldCam = currentCam;

		if (oldCam != null) {
			oldCam.enabled = false;
		}
		newCam.enabled = true;

		currentCam = newCam;




		/*if (currentCam.enabled == true) {
			currentCam.enabled = false;
			newCam.enabled = true;
			thePlayer.GetComponent<scr_player_movement_3d> ().ChangeMainCamera (newCam);
		} else {
			newCam.enabled = false;
			myCam.enabled = true;
			thePlayer.GetComponent<scr_player_movement_3d> ().ChangeMainCamera (myCam);
		}*/
	}
}