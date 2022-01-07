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
		//make item do different things depending on item type
		//then remove item/reduce quantity of item
		// if(Equals(item.itemType, "health")){
		// 	item.Use();
		// 	Inventory.inventory.RemoveItem(item);
		// } else if(Equals(item.itemType, "food")){
			
		// 	Debug.Log("f");
		// 	Inventory.inventory.RemoveItem(item);
		// } else if(Equals(item.itemType, "recipe")){
		// 	Inventory.inventory.RemoveItem(item);
		// }

		item.Use();
		Inventory.inventory.RemoveItem(item);

		btn.parent.GetComponent<ItemProfile>().HideItemDetails();
	}
}
