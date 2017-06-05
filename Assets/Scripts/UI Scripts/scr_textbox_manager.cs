using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_textbox_manager : MonoBehaviour {

	public GameObject textBox;
	public Text theText;

	// For TextAssets...
	public TextAsset textFile;
	// For strings... (Play with both. See which ends up being better.)
	public string currentText;
	public string[] textLines;

	public int currentLine;
	public int endAtLine;

	bool textBoxOpened = false;

	// UI Text Elements is an empty object that holds data about

	public bool enableUI = false;

	void Start () {
		if (textFile != null) {
			textLines = (textFile.text.Split ('\n'));
		}
		if (endAtLine == 0) {
			endAtLine = textLines.Length - 1;
		}
		if (currentText != null) {
			textLines = currentText.Split('@');
		}
		if (endAtLine == 0) {
			endAtLine = textLines.Length - 1;
		}
	}
	void Update(){
		// So you can advance to the next line of text.
		if (enableUI == true) {
			if (Input.GetButtonDown ("Joystick0")) {
				// Makes sure it doesn't skip the first line. The damned thing reads an A press for both enableUI AND for advancing to the next line of text. Slightly hacky / bloated solution.
				if (!textBoxOpened) {
					textBoxOpened = true;
				} else if (currentLine < textLines.Length - 1) {
					// Go to the next line, so line, unless it's the end of the array.
					currentLine++;
				} else {
					EnableTextBox (false);
				}
			}
		}
		// ".text" references the actual characters of the file
		// Basically, this grabs the current line from the text file which was broken down from the textFile asset to the textLines array. It dumps it into the onscreen Text appearing in the textBox.

		theText.text = textLines[currentLine];
	}

	// For setting up new text lines based on text assets.
	public void SetNewTextAsset(TextAsset newTextAsset){
		currentLine = 0;
		textFile = newTextAsset;
		textBoxOpened = false;
		if (textFile != null) {
			textLines = (textFile.text.Split ('\n'));
		}
		if (endAtLine == 0) {
			endAtLine = textLines.Length - 1;
		}
	}
	// For setting up new text lines based on strings.
	public void SetNewString(string newLine){
		currentLine = 0;
		currentText = newLine;
		textBoxOpened = false;
		if (currentText != null) {
			textLines = (currentText.Split ('@'));
		}
		if (endAtLine == 0) {
			endAtLine = textLines.Length - 1;
		}
	}

	public void EnableTextBox(bool setEnable){
		enableUI = setEnable;
		textBoxOpened = false;
		currentLine = 0;
		if (setEnable == true) {
			textBox.SetActive (true);
		} else {
			textBox.SetActive (false);
		}
	}
}
