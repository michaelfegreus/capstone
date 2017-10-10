using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class scr_dolly_track_offset : MonoBehaviour {

	CinemachineTrackedDolly myDollyCam;

	public float trackPositionOffset;

	// Use this for initialization
	void Start () {
		myDollyCam = this.GetComponent<CinemachineTrackedDolly> ();
	}
	
	// Update is called once per frame
	void Update () {
		myDollyCam.m_PathPosition = myDollyCam.m_PathPosition + trackPositionOffset;
	}
}
