using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_item_use_check : MonoBehaviour {

	public int requiredItemID;

	// Color debug
	Renderer rend;

	void Start(){
		rend = GetComponent<Renderer> ();
	}

	public void UseItemCheck(int incomingItemID){
		if (incomingItemID == requiredItemID) {
			Debug.Log ("Got correct item. Happy.");
			rend.material.SetColor ("_Color", Color.blue);
		} else {
			Debug.Log ("Got incorrect item. F'ing pissed.");
			rend.material.SetColor ("_Color", Color.red);
		}
	}
}
