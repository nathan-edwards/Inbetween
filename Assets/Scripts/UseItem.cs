using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// jieying was here: use item from inventory
public class UseItem : MonoBehaviour
{
	public Transform btn;
	Item item;

	//set item to know which item is being used
	public void SetItem(Item x){
		item = x;
	}

	//use item, then remove item from inventory, hide the side profile that was opened on the item that got used
	public void UseTheItem(){
		item.Use();
		Debug.Log("here");
		if(item is SwordItem){
			Debug.Log("wow");
		}
		Inventory.inventory.RemoveItem(item);

		//checks inventory quantity of used item to see if to display item profile or not
		//better UX (in my opinion)
		//lets use click on the available item multiple times if its available without reselecting the item
		if(Inventory.inventory.SearchListForItemQuantity(item) > 0){
			btn.parent.GetComponent<ItemProfile>().DisplayItemDetails();
		} else {
			btn.parent.GetComponent<ItemProfile>().HideItemDetails();
		}
	}
}
