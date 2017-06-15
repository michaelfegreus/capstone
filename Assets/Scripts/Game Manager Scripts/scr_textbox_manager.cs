using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_textbox_manager : MonoBehaviour {

	// State of textbox
	public bool textBoxActive = false;

	public GameObject textBoxUI;

	public Text onscreenText;

	public TextAsset textFile;
	public string[] textLines;

	public int currentLine;
	public int endAtLine;

	public void ActivateTextBox(){
		textBoxActive = true;

		currentLine = 0;

		textLines = new string[1];

		if (textFile != null) {
			textLines = (textFile.text.Split('\n'));
		}
		if (endAtLine == 0) {
			endAtLine = textLines.Length - 1;
		}

		textBoxUI.SetActive (true);
	}

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (textBoxActive) {
			onscreenText.text = textLines [currentLine];
			if (Input.GetKeyDown (KeyCode.Return)) {
				currentLine += 1;
			}
			// If you get to the end of the text, close the textbox and deactivate it.
			if (currentLine > endAtLine) {
				textBoxUI.SetActive (false);
				textBoxActive = false;
			}
		}
	}
}
