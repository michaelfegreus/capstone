using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class scr_virtualcamera_zone : MonoBehaviour {

	public GameObject myCam;

	public CinemachineBrain mainCamBrain;

	void OnTriggerEnter (Collider col) {
		if (col.tag == ("Player")) {
			SwapCameras ();
		}
	}

	void SwapCameras(){
		//mainCamBrain.

		mainCamBrain.ActiveVirtualCamera.VirtualCameraGameObject.SetActive (false);

		myCam.SetActive (true);
	}
}
