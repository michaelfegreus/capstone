using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_tool_scythe_use : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == ("Item") || col.tag == ("Grass")) {
			Destroy (col.gameObject);
		}
	}
}
