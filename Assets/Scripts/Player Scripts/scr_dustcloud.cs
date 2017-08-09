using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_dustcloud : MonoBehaviour {

	float myRiseSpeed;

	public void Start(){
		myRiseSpeed = Random.Range (.005f, .015f);
		transform.rotation = Random.rotation;
	}

	public void DestroyMe(){
		Destroy (this.gameObject);
	}

	public void Update(){
		// Rise a little every frame.
		transform.position += new Vector3 ( 0f, myRiseSpeed, 0f);
	}
}
