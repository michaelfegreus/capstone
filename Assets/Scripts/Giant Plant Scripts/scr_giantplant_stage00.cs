using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_giantplant_stage00 : MonoBehaviour {

	// The parent should be the plant manager.
	GameObject plantManager;
	// Plant manager's script
	scr_giantplant_manager plantManagerScript;

	void Start(){
		// Assigns these variables for easy access later in the script.
		plantManager = this.transform.parent.gameObject;
		plantManagerScript = plantManager.GetComponent<scr_giantplant_manager> ();
	}

	void OnTriggerEnter2D(Collider2D col){
		// If the thing it collides with is an item with an item ID.
		if (col.GetComponent <scr_item_ID>() != null) {
			// If that item is the giant seed...
			if (col.GetComponent<scr_item_ID> ().GetItemID () == Items.GIANT_SEED) {
				Debug.Log ("Giant seed planted.");
				// Get rid of the giant seed item.
				Destroy (col.gameObject);
				plantManagerScript.AdvanceStage ();
			}
		}
	}
}
