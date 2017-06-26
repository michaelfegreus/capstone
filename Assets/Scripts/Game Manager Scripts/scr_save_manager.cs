using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;

public class scr_save_manager : MonoBehaviour {

	public static scr_save_manager progress;

	public int bearQuest;

	void Awake(){
		if (progress == null) {
			DontDestroyOnLoad (gameObject);
			progress = this;
		} else if (progress != null) {
			Destroy (gameObject);
		}
	}
}
