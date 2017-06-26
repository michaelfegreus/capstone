using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Delete this if you end up controlling UI elsewhere.

public class scr_stamina_manager : MonoBehaviour {

	float baseStamina = 60f;
	float currentStamina;

	bool haveStamina;

	// UI for stamina bar. Can move later if it becomes preferred to handle that under a UI manager. Delete "using UnityEngine.UI" if you move this stuff elsewhere.
	public Image staminaBarUI;

	// To get the manager and disable other components when the player is out of stamina. 
	//scr_player_manager playerManagerScript;

	// Use this for initialization
	void Start () {
		//playerManagerScript = GetComponent<scr_player_manager> ();
		StartDayStamina ();
	}
	
	// Update is called once per frame
	void Update () {
		currentStamina = currentStamina - Time.deltaTime;
		// Proportion that calculates how far the stamina bar should be filled.
		staminaBarUI.fillAmount = currentStamina / baseStamina;


		if (-1f < currentStamina && currentStamina < 0f) {
			if (haveStamina == true) {
				StaminaDeplete ();
			}
		}
	}

	// Call this from wherever in the event system the day starts.
	void StartDayStamina(){
		haveStamina = true;
		currentStamina = baseStamina;
	}

	// Call this to add stamina when you consume food.
	public void AddStamina(float staminaToAdd){
		currentStamina += staminaToAdd;
	}

	// Call this for when stamina runs out and the day is over.
	void StaminaDeplete(){
		haveStamina = false;
		Debug.Log ("Day is over.");
		// Can't use inventory or tools when you are out of stamina.
	//	playerManagerScript.DayStaminaDeplete();
	}
}