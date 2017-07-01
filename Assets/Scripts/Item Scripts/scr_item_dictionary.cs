using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_item_dictionary : MonoBehaviour {

	public static scr_item_dictionary itemDictionary;

	public Item[] gameItems;

	void Awake(){
		if (itemDictionary == null) {
			DontDestroyOnLoad (gameObject);
			itemDictionary = this;
		} else if (itemDictionary != null) {
			Destroy (gameObject);
		}
	}

	public string GetName(int itemID){
		return gameItems [itemID].name;
	}

	public string GetDescription(int itemID){
		return gameItems [itemID].description;
	}
}
