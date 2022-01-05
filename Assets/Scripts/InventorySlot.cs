using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//jieying was here: making a script for inventory slot
public class InventorySlot : MonoBehaviour
{
	//make inventory slot have an item
	public Item item;
	//to store the item profile object from hierarchy
	GameObject profile;

	//find the profile gameobject
	void Start(){
		profile = GameObject.Find("ItemProfile");
	}

	//when the inventory slot is clicked,
	//pass the item that the inventory slot is holding to the item profile
	//and make the profile display the item details
	public void SelectItemSlot(){
		profile.GetComponent<ItemProfile>().item = this.item;
		profile.GetComponent<ItemProfile>().DisplayItemDetails();
	}
}
