using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_warp_point : MonoBehaviour {

	// Where the player will go.
	public Transform destinationWarp;
	// Where the camera will go.
	public Transform cameraPlacement;

	GameObject thePlayer;

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == ("Player")) {
			thePlayer = col.gameObject;
			// Warps player to a destination empty object transform
			thePlayer.GetComponent<scr_player_movement> ().Warp (destinationWarp.position, cameraPlacement.position);
		}
	}
}