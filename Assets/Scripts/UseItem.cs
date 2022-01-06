using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// jieying was here: use item from inventory
public class UseItem : MonoBehaviour
{
	public Transform btn;
	Item item;

	public void SetItem(Item x){
		item = x;
	}

	public void UseTheItem(){
		//make item do different things depending on item type
		//then remove item/reduce quantity of item
		if(Equals(item.itemType, "health")){
			Debug.Log("h");
			Inventory.inventory.RemoveItem(item);
		} else if(Equals(item.itemType, "food")){
			Debug.Log("f");
			Inventory.inventory.RemoveItem(item);
		}

		btn.parent.GetComponent<ItemProfile>().HideItemDetails();
	}
}
