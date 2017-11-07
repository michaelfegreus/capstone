﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class scr_virtualcamera_zone : MonoBehaviour {

	public GameObject myCam;
	public CinemachineBrain mainCamBrain;

	public Zone thisZone;

	void OnTriggerEnter (Collider col) {
		if (col.tag == ("Player")) {
			SwapCameras ();
		}
		if (col.tag == ("Player") || col.tag == ("Actor")) {
			col.gameObject.GetComponent<mono_actor_zone_check> ().myCurrentZone = thisZone;
		}
	}

	void SwapCameras(){
		//mainCamBrain.

		mainCamBrain.ActiveVirtualCamera.VirtualCameraGameObject.SetActive (false);

		myCam.SetActive (true);
	}

	// All Camera Zone names. Should probably keep this updated.
	public enum Zone{

		ally, bathroom, couch, crossRoad, frontDoor, frontYard, gardenBack, gardenMid, gardenPassage, gardenTunnel, hallway, kitchen, kitchenWindow, mudroom, porch, rafterDoor, seed, sideRoad, southRoad, stumpEntrance, wishingWell

	}
}
