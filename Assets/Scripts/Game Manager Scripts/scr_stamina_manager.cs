using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_stamina_manager : MonoBehaviour {

	float baseStamina = 60f;
	float dayStamina;

	bool haveStamina;

	// Get other components to disable them when the player is out of stamina.
	scr_inventory inventoryScript;
	scr_tool_manager toolManagerScript;

	// Use this for initialization
	void Start () {
		inventoryScript = GetComponent<scr_inventory> ();
		toolManagerScript = GetComponent<scr_tool_manager> ();
		StartDayStamina ();
	}
	
	// Update is called once per frame
	void Update () {
		dayStamina = dayStamina - Time.deltaTime;
		if (-1f < dayStamina && dayStamina < 0f) {
			if (haveStamina == true) {
				StaminaDeplete ();
			}
		}
	}

	// Call this from wherever in the event system the day starts.
	void StartDayStamina(){
		haveStamina = true;
		dayStamina = baseStamina;
	}

	// Call this to add stamina when you consume food.
	public void AddStamina(float staminaToAdd){
		dayStamina += staminaToAdd;
	}

	// Call this for when stamina runs out and the day is over.
	void StaminaDeplete(){
		haveStamina = false;
		Debug.Log ("Day is over.");
		// Can't use inventory or tools when you are out of stamina.
		inventoryScript.enabled = false;
		toolManagerScript.enabled = false;
	}
}