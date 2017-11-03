using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Behavior))]

public class editor_behavior_asset : Editor {
	/*
	int requiredFactsCount = 0;

	int[] indexDropDownFact;

	// Gonna need to update this to be dynamic depending on what blackboard is being used.
	// Or maybe just expand options to include all relevant dictionaries? Might be loooong.
	string[] options;

	string[] comparison = new string[]{ ">", "<", "=" };

	int[] comparisonIndeces;

	float[] comparisonFloats;

	class RequiredFactMenu{
		public string[] factOptions = new string[]{ ">", "<", "=" };
		public int dropDownIndex;
		public string[] equalityOption = new string[]{ ">", "<", "=" };
		public int equalityIndex;
		public float comparisonFloat = 0f;
	}

	RequiredFactMenu[] requiredFactsMenuArray;

	public override void OnInspectorGUI(){
		// This line keeps all the original inspector code on top of the custom stuff - so you don't lose serialized public variables, etc.
		base.OnInspectorGUI ();
		// Target is the object currently being inspected (in this case, Behavior)
		// Target is default of type GameObject. So we recast it by writing (Behavior) in parenthesis before target.
		Behavior thisBehavior = (Behavior)target;

		// Set the amount of fact menus.
		requiredFactsMenuArray = new RequiredFactMenu[requiredFactsCount];

		// How many selectable fact options there are from this blackboard.
		int factsInBlackboardCount = thisBehavior.requiredBlackboard.myFactCollection.Length;
	
		// Set up each of the fact menus.
		for(int x = 0; x < requiredFactsCount; x++){
			GUILayout.BeginHorizontal ();


			// Set up arrays depending on how many facts are in the blackboards
		//	requiredFactsMenuArray [x].factOptions = new string[factsInBlackboardCount];

		//	for (int i = 0; i < factsInBlackboardCount; i++) {
				// Set the strings in the drop down menu for this RequiredFactMenu
		//		requiredFactsMenuArray [x].factOptions [i] = thisBehavior.requiredBlackboard.myFactCollection [i].factNameKey;
		//	}

			//requiredFactsMenuArray [x].dropDownIndex = EditorGUILayout.Popup (requiredFactsMenuArray [x].dropDownIndex, requiredFactsMenuArray [x].factOptions);
			//requiredFactsMenuArray [x].equalityIndex = EditorGUILayout.Popup (requiredFactsMenuArray [x].equalityIndex, requiredFactsMenuArray [x].equalityOption);
			//requiredFactsMenuArray [x].comparisonFloat = EditorGUILayout.FloatField (requiredFactsMenuArray [x].comparisonFloat);


			options = new string[thisBehavior.requiredBlackboard.myFactCollection.Length];
			for(int i = 0; i < thisBehavior.requiredBlackboard.myFactCollection.Length; i++){
				options[i] = thisBehavior.requiredBlackboard.myFactCollection [i].factNameKey;
			}


			indexDropDownFact[x] = EditorGUILayout.Popup (indexDropDownFact[x], options);

		//	comparisonIndeces = EditorGUILayout.Popup (comparisonIndeces, comparison);

		//	comparisonFloats = EditorGUILayout.FloatField (comparisonFloats);

			GUILayout.EndHorizontal ();
		}

		GUILayout.BeginHorizontal ();

		if(GUILayout.Button("Add Required Fact")){
			// This runs if you click the custom button.
			requiredFactsCount++;
			requiredFactsMenuArray = new RequiredFactMenu[requiredFactsCount];
			indexDropDownFact = new int[requiredFactsCount];
		}
		if(GUILayout.Button("Remove Required Fact")){
			// This runs if you click the custom button.
			requiredFactsCount--;
			requiredFactsMenuArray = new RequiredFactMenu[requiredFactsCount];
			indexDropDownFact = new int[requiredFactsCount];
		}

		GUILayout.EndHorizontal ();

		//thisBehavior.UpdateReqFactLength (requiredFactsCount);
		// Finds which indeces were chosen through the Fact Menus, then it passes the string along according to the slot.
		/*if (requiredFactsCount > 0) {
			for (int y = 0; y < requiredFactsCount; y++) {
				thisBehavior.SaveEditorUpdates (y, options [indexDropDownFact [y]]);
			}
		}*/
	//}

}
