using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_warp_point_3d : MonoBehaviour {

	// Where the player will go.
	public Transform destinationWarp;
	// If switching actual cameras.
	public Camera newCam;
	public GameObject myBG;

	GameObject thePlayer;

	public GameObject cameraOp;
	scr_camera_operator cameraOpScript;

	void Start(){
		if (cameraOp != null) {
			cameraOpScript = cameraOp.GetComponent<scr_camera_operator> ();
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == ("Player")) {
			thePlayer = col.gameObject;
			// Warps player to a destination empty object transform
			//thePlayer.GetComponent<scr_player_manager> ().Warp (destinationWarp.position);
			thePlayer.transform.position = destinationWarp.transform.position;

			// Swap the camera
			if (cameraOp != null) {
				cameraOpScript.SetNewCamera (newCam, myBG);
			}
		}
	}
}