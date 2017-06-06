using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_tool_manager : MonoBehaviour {

	// To get general info about what the player's doing
	scr_player_manager playerManagerScript;

	// ID for the tool being used.
	int currentTool;
	//ID for the current location. Tools can change depending on the context, like the watering can fills up if you're standing by water.
	int currentTrigger;

	public GameObject scythe;

	bool usingTool = false;

	int wateringCanLevel = 0;

	void Start(){
		playerManagerScript = GetComponent<scr_player_manager> ();
	}

	void WateringCanRoutine(){
		// If by water, fill up watering can. Otherwise, drop the value of watering can uses by one.
		if (currentTrigger == Triggers.WATER) {
			wateringCanLevel = 3;
		} else {
			wateringCanLevel--;
		}
		Debug.Log ("Watering Can level: " + wateringCanLevel);
	}

	IEnumerator ScytheRoutine(){

		// To prevent using the tool too fast.
		usingTool = true;

		//Temporarily enables tool sprite and triggerbox to cut grass, etc.
		BoxCollider2D toolCol = scythe.GetComponent<BoxCollider2D> ();
		SpriteRenderer toolRend = scythe.GetComponent<SpriteRenderer> ();

		toolCol.enabled = true;
		toolRend.enabled = true;

		yield return new WaitForSeconds (.2f);

		toolCol.enabled = false;
		toolRend.enabled = false;

		usingTool = false;
	}

	void Update () {

		if (Input.GetKeyDown (KeyCode.T) && !usingTool) {

			// Checks the current tools and location context.
			currentTool = playerManagerScript.currentTool;
			currentTrigger = playerManagerScript.trigger;

			switch (currentTool) {

			case Items.SCYTHE:
				StartCoroutine (ScytheRoutine ());
				break;

			case Items.WATERING_CAN:
				WateringCanRoutine ();
				break;
			
			default:
				Debug.Log ("No tool held");
				break;
			}
		}
	}
}
