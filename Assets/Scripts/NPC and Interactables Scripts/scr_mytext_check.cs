using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_mytext_check : MonoBehaviour {

	public TextAsset myText;

	public void SetText(TextAsset newText){
		myText = newText;
	}

	public TextAsset GetText(){
		return myText;
	}
}
