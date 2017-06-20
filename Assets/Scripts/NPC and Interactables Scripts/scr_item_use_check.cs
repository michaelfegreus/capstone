using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_item_use_check : MonoBehaviour {

	public int requiredItemID;

	public bool gotItem = false;

	public bool takeItemFromPlayer;

	// Color debug
	Renderer rend;

	void Start(){
		rend = GetComponent<Renderer> ();
	}

	public void UseItemCheck(int incomingItemID){
		if (incomingItemID == requiredItemID) {
			rend.material.SetColor ("_Color", Color.blue);
			gotItem = true;
		} else {
			rend.material.SetColor ("_Color", Color.red);
		}
	}
}
