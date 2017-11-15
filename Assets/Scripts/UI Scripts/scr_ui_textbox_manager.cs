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

	// To prevent you from going to the next page on the same frame as opening text box.
	bool bufferInput = false;

	public void ActivateTextBox(TextAsset newTextFile){
		textFile = newTextFile;
		if (textFile != null) {
			textBoxActive = true;
			currentLine = 0;

			textLines = new string[1];

			if (textFile != null) {
				textLines = (textFile.text.Split ('\n'));
			}

			endAtLine = textLines.Length - 1;

			onscreenText.text = textLines [currentLine];

			textBoxUI.SetActive (true);
		}
	}

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (textBoxActive) {
			onscreenText.text = textLines [currentLine];
			if (bufferInput == true) {
				if (Input.GetButtonDown("Joystick0") || Input.GetButtonDown("Joystick1") || Input.GetButtonDown("Joystick2")) {
					
					currentLine += 1;
					
				}
			}
			else{
				if (Input.GetButtonUp ("Joystick0") || Input.GetButtonUp ("Joystick1") || Input.GetButtonUp ("Joystick2")) {
					bufferInput = true;
				}
			}
			// If you get to the end of the text, close the textbox and deactivate it.
			if (currentLine > endAtLine) {
				bufferInput = false;
				textBoxUI.SetActive (false);
				textBoxActive = false;
			}
		}
	}
}
