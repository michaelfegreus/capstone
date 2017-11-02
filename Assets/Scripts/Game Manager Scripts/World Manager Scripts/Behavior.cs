using System.Collections;
using UnityEngine;

[CreateAssetMenu()]
public class Behavior : ScriptableObject {

	public string behaviorName;
	public Vector3 myDestination;
	public TextAsset myDialog;

	public bool waitingForConversation;

	public string factToModify;
	public float modifyValue;

	// Fact requirement values
	public FactCollection requiredBlackboard;

	class RequiredFact{
		public string requiredFactName;
		public string requiredFactEquality;
		public float requiredFactValue;
	}

	public RequiredFact[] requiredFactList;
}