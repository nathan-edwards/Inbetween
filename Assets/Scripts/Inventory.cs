using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//jieying was here: creating a class for inventory
public class Inventory : MonoBehaviour
{
	//list to store all items
	public List<Item> itemList = new List<Item>();

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
		itemList.Add(x);
	}

	//remove item to item/inventory list
	public void RemoveItem(Item x){
		Debug.Log("removed " + x);
	}
}
