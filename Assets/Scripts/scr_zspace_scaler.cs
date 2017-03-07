using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_zspace_scaler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector3(-1f * transform.position.y + 7f, -1f * transform.position.y + 7f, -1f * transform.position.y + 7f);
	}
}
