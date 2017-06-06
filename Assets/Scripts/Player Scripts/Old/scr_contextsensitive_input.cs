using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_contextsensitive_input : MonoBehaviour {

	// Keeping track of the current context sensitive location. Information gets sent over from player manager when collider picks up change.
	int currentTrigger;

	// To enable and disable the textBoxManager
	public GameObject textBoxManager;
	scr_textbox_manager textBoxManagerScript;

	void Start () {
		textBoxManagerScript = textBoxManager.GetComponent<scr_textbox_manager> ();
	}

	void Update () {
		if (Input.GetButtonDown ("Joystick0")) {
			// Check location, if in a certain location, perform an action.
			switch (currentTrigger) {

			case Triggers.SIGNBOARD:
				if (textBoxManagerScript.enableUI != true) {
					textBoxManagerScript.EnableTextBox(true);
				}
				break;

			case Items.WATERING_CAN:
				//WateringCanRoutine ();
				break;

			default:
				Debug.Log ("General Trigger button input");
				break;
			}
		}
	}

	public void changeContextLocation(int newTrigger){
		currentTrigger = newTrigger;
	}
}
