using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_npc_MANAGER : MonoBehaviour {

	public int questLength;
	int currentQuest;

	scr_item_use_check itemCheckScript;

	// Use this for initialization
	void Start () {
		itemCheckScript = GetComponent<scr_item_use_check> ();
		// Later, get the current quest status from a master object in Start()
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
