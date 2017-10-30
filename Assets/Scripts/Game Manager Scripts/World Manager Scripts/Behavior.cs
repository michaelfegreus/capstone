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
}