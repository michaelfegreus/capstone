using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_tool_manager : MonoBehaviour {

	public GameObject scythe;

	float inputX;
	float inputY;

	bool usingTool = false;

	IEnumerator scytheRoutine(){

		// To prevent using the tool too fast.
		usingTool = true;

		//Temporarily enables tool sprite and triggerbox to cut grass, etc.
		BoxCollider2D toolCol = scythe.GetComponent<BoxCollider2D> ();
		SpriteRenderer toolRend = scythe.GetComponent<SpriteRenderer> ();

		toolCol.enabled = true;
		toolRend.enabled = true;

		yield return new WaitForSeconds (.2f);

		toolCol.enabled = false;
		toolRend.enabled = false;

		usingTool = false;
	}

	void Update () {

		/*inputX = Input.GetAxis ("Horizontal"); // A/D, LeftArrow/RightArrow
		inputY = Input.GetAxis ("Vertical"); // W/S, UpArrow/DownArrow

		if (inputX != 0 && inputY != 0) {
			currentMoveSpeed = moveSpeed * .8f;
		} else {
			currentMoveSpeed = moveSpeed;
		}*/

		if (Input.GetKeyDown (KeyCode.T) && !usingTool) {
			StartCoroutine (scytheRoutine ());
		}
	}
}
