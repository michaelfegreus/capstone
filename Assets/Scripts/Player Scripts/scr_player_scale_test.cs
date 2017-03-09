using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_player_scale_test : MonoBehaviour {

	public Camera mainCam;
	public float sizeMultiplier;
	[Range(.25f,2f)]public float baseSize;

	// Use this for initialization
	void Start ()
	{
		mainCam = Camera.main;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 w2s = mainCam.WorldToViewportPoint (transform.position);
		transform.localScale =  Vector3.one * (baseSize + 1 - w2s.y) * sizeMultiplier;

		Debug.Log ("Y axis viewport point " + w2s.y);
	}
}
