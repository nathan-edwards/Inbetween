using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//jieying was here: creating a class for inventory
public class Inventory : MonoBehaviour
{
	//list to store all items
	//and list to store item quantities (will work as parallel lists)
	public List<Item> itemList = new List<Item>();
	public List<int> itemQuantity = new List<int>();

	//creating a single instance of inventory
	public static Inventory inventory;

	void Awake(){
		if(inventory != null){
			Debug.Log("an inventory already exists");
		} else {
			inventory = this;
		}
	}

	//add item to item/inventory list
	public void AddItem(Item x){
		//check if the same item is already in the inventory
		bool isAlreadyInInventory = false;
		int index = 0;

		for(int i = 0; i < itemList.Count; i++){
			if(Equals(x.itemName, itemList[i].itemName)){
				isAlreadyInInventory = true;
				index = i;
				break;
			}
		}

		//if already in inventory, then change quantity number (stacking)
		//otherwise add new item to inventory with quantity 1
		if(isAlreadyInInventory){
			itemQuantity[index] += 1;
		} else{
			itemList.Add(x);
			itemQuantity.Add(1);
		}
	}

	//remove item from item/inventory list
	public void RemoveItem(Item x){
		//check if there is more than one item
		//(to adjust for stacked items)
		bool isMoreThanOne = false;
		int index = 0;

		for(int i = 0; i < itemList.Count; i++){
			if(Equals(x.itemName, itemList[i].itemName)){
				if(itemQuantity[i] > 1){
					isMoreThanOne = true;
					index = i;
					break;
				}
			}
		}

		//if more than one item then just reduce quantity by one
		//otherwise remove item from inventory and remove counterpart quantity from other list
		if(isMoreThanOne){
			itemQuantity[index] -= 1;
		} else{
			itemList.Remove(x);
			itemQuantity.RemoveAt(index);
		}
	}
}
