using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_take_screenshot : MonoBehaviour {

	public string screenshotName = "screenshot";

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.P)) {
			Application.CaptureScreenshot (screenshotName + ".png", 2);
		}
	}
}
