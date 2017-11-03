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

	[System.Serializable]
	public class RequiredFact{
		public string requiredFactName;
		public Equality requiredFactEquality;
		public float requiredFactValue;

		/*public RequiredFact(string name, string equality, float value){
			requiredFactName = name;
			requiredFactEquality = equality;
			requiredFactValue = value;
		}*/
	}
		
	// Just...use this for now. The other custom inspector setup was a mess.
	// And it'll be better to do it will a full custom editor window in the full game when I know what I need.
	public RequiredFact[] requiredFactArray;

	public enum Equality{

		GreaterThan, LessThan, Equals

	}
}