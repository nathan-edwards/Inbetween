using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//jieying was here: to make the inventory UI do things
public class InventoryUI : MonoBehaviour
{
	public Transform inventorySlotsParentContainer;

    void Update()
    {
		UpdateInventoryContents();
    }

	//method to check list of items in inventory and update UI accordingly
	void UpdateInventoryContents(){
		//clear inventory (remove items if they have been removed before redrawing the new inventory)
		for(int i = 0; i < inventorySlotsParentContainer.childCount; i++){
			//set the item and item sprite in inventory slot to null so it's empty
			inventorySlotsParentContainer.GetChild(i).GetComponent<InventorySlot>().item = null;
			inventorySlotsParentContainer.GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().sprite = null;

			//hide item sprite
			inventorySlotsParentContainer.GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
			//reset item quantity number & hide item quantity
			inventorySlotsParentContainer.GetChild(i).GetChild(1).GetComponent<Text>().text = "0";
			inventorySlotsParentContainer.GetChild(i).GetChild(1).GetComponent<Text>().enabled = false;
			//make the item slot not clickable
			inventorySlotsParentContainer.GetChild(i).GetComponent<Button>().interactable = false;
		}

		//loop through list of items and set the sprite to the sprite of the item in the list
		for(int i = 0; i < Inventory.inventory.itemList.Count; i++){
			//set the item in inventory slot to the current item in the list
			inventorySlotsParentContainer.GetChild(i).GetComponent<InventorySlot>().item = Inventory.inventory.itemList[i];
			inventorySlotsParentContainer.GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().sprite = Inventory.inventory.itemList[i].itemImg;

			//make the sprite visible
			inventorySlotsParentContainer.GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
			//set item quantity & make item quantity visible
			inventorySlotsParentContainer.GetChild(i).GetChild(1).GetComponent<Text>().text = Inventory.inventory.itemQuantity[i].ToString();
			inventorySlotsParentContainer.GetChild(i).GetChild(1).GetComponent<Text>().enabled = true;
			//make the item slot interactable/clickable
			inventorySlotsParentContainer.GetChild(i).GetComponent<Button>().interactable = true;
		}
	}
}
