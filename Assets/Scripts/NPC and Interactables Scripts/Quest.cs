using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Quest {

	public scr_npc_MANAGER.QuestType myQuestType;
	public TextAsset myText;
	public int[] myQuestItemIDs;

	public Quest(scr_npc_MANAGER.QuestType newQuestType, TextAsset newText){
		myQuestType = newQuestType;
		myText = newText;
	}

	public scr_npc_MANAGER.QuestType GetQuestType(){
		return myQuestType;
	}

	public TextAsset GetQuestText(){
		return myText;
	}

	public int GetQuestItemID(int itemIndex){
		return myQuestItemIDs [itemIndex];
	}
}
