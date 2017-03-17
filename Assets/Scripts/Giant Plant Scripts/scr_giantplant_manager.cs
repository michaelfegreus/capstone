using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_giantplant_manager : MonoBehaviour {

	// This tracks what stage in growth the plant is at.
	// 0 is just the seed hole, 1 is the seed in the ground...
	public int currentStage;

	// An array to keep track of the child game objects - the different plant stages.
	public GameObject[] plantStageObjects;
	void Start () {
		// Makes sure that all the stages are disabled except the one we're on. Can delete this later.
		for (int i = 0; i < plantStageObjects.Length; i++) {
			plantStageObjects [i].SetActive (false);
		}
		//plantStageObjects [0].SetActive (true);
		StageChange (); // Sets up for the stage it should be on. You can change the value to test different stages.
	}

	public void AdvanceStage(){
		// Goes to the next stage of the plant growth.
		currentStage++;
		StageChange ();
	}

	public void StageChange(){
		// Gets the plant going if there's no integer inputed
		if (currentStage < 0) {
			AdvanceStage ();
		} else { // Enables and disables the different GameObjects of the different stages.
			Debug.Log ("Enable Stage " + currentStage + " Plant object");
			// This ensures the game doesn't try to disable a null object.
			if (currentStage > 0) {
				if (plantStageObjects [currentStage - 1] != null) {
					plantStageObjects [currentStage - 1].SetActive (false);
				}
			}
			plantStageObjects [currentStage].SetActive (true);
		}
	}
}
