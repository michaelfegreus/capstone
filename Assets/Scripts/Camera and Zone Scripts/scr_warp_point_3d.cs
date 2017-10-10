using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_warp_point_3d : MonoBehaviour {

	// Where the player will go.
	public Transform destinationWarp;

	GameObject thePlayer;


	void OnTriggerEnter(Collider col){
		if (col.tag == ("Player")) {
			thePlayer = col.gameObject;
			// Warps player to a destination empty object transform
			//thePlayer.GetComponent<scr_player_manager> ().Warp (destinationWarp.position);
			thePlayer.transform.position = destinationWarp.transform.position;
		}
	}
}