using System.Collections;
using UnityEngine;

[CreateAssetMenu()]
public class Item : ScriptableObject {
	
	public string itemName;
	public string itemDescription;
	public bool useAnywhereReaction; // To get a message when you use something anywhere.
	public TextAsset useAnywhereText;
}