using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_npc_MANAGER : MonoBehaviour {

	//public int questLength;

	public Quest[] questList;
	public int currentQuest;

	scr_item_quest itemQuestScript;
	scr_mytext_check textCheckScript;

	// Use this for interacting with special case work!
	//public Component customComponent;

	// Enum for quest types. Helps determine what script should be running right now.
	public enum QuestType{

		item, talk, custom

	}

	// Use this for initialization
	void Start () {
		itemQuestScript = GetComponent<scr_item_quest> ();
		textCheckScript = GetComponent<scr_mytext_check> ();

		currentQuest = 0; // Get the current quest status from Progress Manager object in Start() when game saving is implementing.
		QuestSetup();
	}
	
	void QuestSetup(){
		// Item/Fetch Quest:
		if (questList [currentQuest].GetQuestType() == QuestType.item) {
			// Set up a new required item ID array in the item quest script.
			int itemAmount = questList [currentQuest].myQuestItemIDs.Length;
			itemQuestScript.requiredItemIDs = new int[itemAmount];
			for(int i = 0; i < itemAmount; i++){
				itemQuestScript.requiredItemIDs [i] = questList [currentQuest].GetQuestItemID (i);
			}
			// Reset the status of the component. 
			itemQuestScript.gotItems = false;
			// Enable the script so it can get to business!
			itemQuestScript.enabled = true;
		}
		// Set the dialogue to match the quest's specification.
		textCheckScript.SetText(questList[currentQuest].GetQuestText());

	}

	public void QuestComplete(){
		// Go to next quest, if there's another one after this.
		// Need to make sure there's a quest to end for this to work in the full game. 
		// 8/9/2017 ^ This might not be necessary to end a quest. Eventually you may want to create an "End" quest type to indicate what should be done when a quest is over.
		//if (currentQuest + 1 < questList.Length) {
			currentQuest++;
		//}
		Debug.Log (this.name + " Quest level : " + currentQuest);
		QuestSetup();
	}
}
