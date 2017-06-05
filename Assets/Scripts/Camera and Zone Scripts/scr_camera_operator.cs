using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_camera_operator : MonoBehaviour {

	Camera currentCam;
	GameObject currentBG;

	public GameObject thePlayer;

	public void SetNewCamera(Camera newCam, GameObject newBG){
		Camera oldCam = currentCam;
		GameObject oldBG = currentBG;

		if (oldCam != null) {
			oldCam.enabled = false;
		}
		if (oldBG != null) {
			oldBG.SetActive (false);
		}
		newCam.enabled = true;
		newBG.SetActive (true);

		currentCam = newCam;
		currentBG = newBG;




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