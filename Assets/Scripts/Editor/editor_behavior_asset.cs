using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Behavior))]

public class editor_behavior_asset : Editor {

	int requiredFactsCount = 0;

	int[] indexDropDownFact;

	// Default string
	string[] options = new string[]{ "Cube", "Sphere", "Plane" };

	string[] comparison = new string[]{ ">", "<", "=" };

	int[] comparisonIndeces;

	float[] comparisonFloats;

	class RequiredFactMenu{
		string[] factOptions;
		int dropDownIndex;
		string[] equalityOption = new string[]{ ">", "<", "=" };
		int equalityIndex;
		float comparisonFloat;
	}

	RequiredFactMenu[] requiredFactsMenuArray;

	public override void OnInspectorGUI(){
		// This line keeps all the original inspector code on top of the custom stuff - so you don't lose serialized public variables, etc.
		base.OnInspectorGUI ();
		// Target is the object currently being inspected (in this case, Behavior)
		// Target is default of type GameObject. So we recast it by writing (Behavior) in parenthesis before target.
		Behavior thisBehavior = (Behavior)target;

		for(int x = 0; x < requiredFactsCount; x++){
			GUILayout.BeginHorizontal ();

			int factsInBlackboardCount = thisBehavior.requiredBlackboard.myFactCollection.Length;

			requiredFactsMenuArray = new RequiredFactMenu[factsInBlackboardCount];



			/*
			options = new string[thisBehavior.requiredBlackboard.myFactCollection.Length];
			for(int i = 0; i < thisBehavior.requiredBlackboard.myFactCollection.Length; i++){
				options[i] = thisBehavior.requiredBlackboard.myFactCollection [i].factNameKey;
			}
			indexDropDownFact[x] = EditorGUILayout.Popup (indexDropDownFact, options);

			comparisonIndeces = EditorGUILayout.Popup (comparisonIndeces, comparison);

			comparisonFloats = EditorGUILayout.FloatField (comparisonFloats);*/

			GUILayout.EndHorizontal ();
		}

		GUILayout.BeginHorizontal ();

		if(GUILayout.Button("Add Required Fact")){
			// This runs if you click the custom button.
			requiredFactsCount++;
		}
		if(GUILayout.Button("Remove Required Fact")){
			// This runs if you click the custom button.
			requiredFactsCount--;
		}

		GUILayout.EndHorizontal ();

	}/*
	void OnGUI(){
		index = EditorGUILayout.Popup(index, options);
	}*/
}
