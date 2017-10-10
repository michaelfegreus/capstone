using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_item_encyclopedia : MonoBehaviour {

	public Item[] itemArray;

	public string GetItemName(int itemID){
		return itemArray[itemID].name;
	}
	public Sprite GetItemSprite(int itemID){
		return itemArray[itemID].itemSprite;
	}

	public GameObject GetItemPrefab(int itemID){
		return itemArray[itemID].itemObject;
	}

/*	public Tool[] toolArray;

	public string GetToolName(int itemID){
		return toolArray[itemID].name;
	}
	public Sprite GetToolSprite(int itemID){
		return toolArray[itemID].toolSprite;
	}

	public GameObject GetToolPrefab(int itemID){
		return toolArray[itemID].toolObject;
	}*/

}
