using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_warp_receiver : MonoBehaviour {

	public Camera newCam;

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == ("Player")) {
			//newCam.enabled = true;
		}
	}
}