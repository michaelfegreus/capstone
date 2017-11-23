using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mono_demo_startscreen : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return) || Input.GetKeyDown (KeyCode.KeypadEnter)) {
			Destroy (gameObject);
		}
	}
}
