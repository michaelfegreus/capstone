using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_contextsensitive_input : MonoBehaviour {

	// Keeping track of the current context sensitive location. Information gets sent over from player manager when collider picks up change.
	int currentLocation;

	void Update () {
		if (Input.GetButtonDown ("Joystick0")) {
			// Check location, if in a certain location, do a certain thing in a separate void.
		}
	}

	public void changeContextLocation(int newLocation){
		currentLocation = newLocation;
	}
}
