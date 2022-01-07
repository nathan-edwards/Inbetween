using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//jieying was here: creating a scriptable object for items that can go in inventory
[CreateAssetMenu(fileName = "Item", menuName = "jay-is-trying/items")]
public class Item : ScriptableObject {
    public string itemName;
	public string itemDesc;
	public string itemType;
	public int itemStat;
	public Sprite itemImg;

	//virtual method for using item
	public virtual void Use(){
		Debug.Log("Item of type " + itemType + " used.");
	}
}
