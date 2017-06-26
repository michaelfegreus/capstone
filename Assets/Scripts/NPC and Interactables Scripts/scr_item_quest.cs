using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_item_quest : MonoBehaviour {

	public int[] requiredItemIDs;

	public bool gotItems = false;

	public bool takeItemFromPlayer;

	// Color debug
	Renderer rend;

	scr_npc_MANAGER managerScript;

	void Start(){
		rend = GetComponent<Renderer> ();
		managerScript = GetComponent<scr_npc_MANAGER> ();
	}

	public void UseItemCheck(int incomingItemID){
		// If it hasn't found its items yet...
		if (!gotItems) {
			bool rightItem = false;
			for (int i = 0; i < requiredItemIDs.Length; i++) {
				if (incomingItemID == requiredItemIDs [i]) {
					rend.material.SetColor ("_Color", Color.blue);
					requiredItemIDs [i] = -1; // - Means that it was fulfilled.
					rightItem = true;
					// Now check to see if everything was fulfilled.
					bool fulfilled = true;
					for (int x = 0; i < requiredItemIDs.Length; i++) {
						if (requiredItemIDs [x] != -1) {
							fulfilled = false;
							break;
						}
					}
					if (fulfilled) {
						gotItems = true;
					}
					break;
				}
			}
			if (gotItems) {
				managerScript.QuestComplete ();
				this.enabled = false;
			}
			if (!rightItem && !gotItems) {
				rend.material.SetColor ("_Color", Color.red);
			}
		}
	}
}
