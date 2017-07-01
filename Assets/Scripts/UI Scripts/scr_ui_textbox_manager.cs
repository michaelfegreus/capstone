using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_ui_textbox_manager : MonoBehaviour {

	// State of textbox
	public bool textBoxActive = false;

	public GameObject textBoxUI;

	public Text onscreenText;

	public TextAsset textFile;
	public string[] textLines;

	public int currentLine;
	public int endAtLine;

	public void ActivateTextBox(TextAsset newTextFile){
		textFile = newTextFile;
		textBoxActive = true;
		currentLine = 0;

		textLines = new string[1];

		if (textFile != null) {
			textLines = (textFile.text.Split('\n'));
		}

		endAtLine = textLines.Length - 1;

		onscreenText.text = textLines [currentLine];

		textBoxUI.SetActive (true);
	}

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (textBoxActive) {
			onscreenText.text = textLines [currentLine];
			if (Input.GetKeyDown (KeyCode.Return) || Input.GetKeyDown (KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.JoystickButton2)) {
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
