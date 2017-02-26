using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_inventory_tool_ui : MonoBehaviour {

	public GameObject itemEncyclopedia;
	Sprite testSprite;

	// The image UI game objects. They begin inactive.
	public Image currentToolImage;

	public void AddToolImage(Sprite newToolSprite){
		// Adds a sprite in the designated slot Image. Called by scr_inventory, at the Player Game Object
		currentToolImage.sprite = newToolSprite;
		currentToolImage.enabled = true;
	}
}
