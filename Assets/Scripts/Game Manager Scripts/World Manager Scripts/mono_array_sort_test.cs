using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mono_array_sort_test : MonoBehaviour {

	public string[] alphaArray;
	public int[] numericArray;

	// Use this for initialization
	void Start () {
		System.Array.Sort (alphaArray);
		Debug.Log (alphaArray);
		System.Array.Sort (numericArray);
		Debug.Log (numericArray);
	}
}
