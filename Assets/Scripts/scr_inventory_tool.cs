using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_inventory_tool : MonoBehaviour {

	public int heldToolID;

	// Keeps track of how much water is in the watering can at a given time.
	int wateringCanLevel = 3;

	public void AddTool(int newID){
		heldToolID = newID;
	}
	public void UseTool(){
		if (heldToolID == 1) { // In this case, ID #1 is watering can
			if (wateringCanLevel > 0) {
				Debug.Log ("Used Watering Can");
				wateringCanLevel--;
			} else {
				Debug.Log ("Watering Can Empty");
			}
		}

		switch (heldToolID) {

			case 1:

				if (wateringCanLevel > 0) {
					Debug.Log ("Used Watering Can");
					wateringCanLevel--;

				} else {
					Debug.Log ("Watering Can Empty");
				}	
			break;

			case 2:

			break;
		}
	}
}
