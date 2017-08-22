using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_take_video : MonoBehaviour {

	public string screenshotName = "screenshot";
	int frameNum = 1;

	// Update is called once per frame
	void Update () {
		ScreenCapture.CaptureScreenshot (screenshotName + frameNum + ".png", 2);
		frameNum++;
	}
}
