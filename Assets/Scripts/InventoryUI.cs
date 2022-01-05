using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//jieying was here: to make the inventory UI do things
public class InventoryUI : MonoBehaviour
{
	/*
		to do:
		- stackable items
	*/
	public Transform inventorySlotsParentContainer;
	//boolean to track if inventory screen/menu is open or not
	private bool isDisplayed = false;

    void Update()
    {
		UpdateInventoryContents();
        OpenInventory();
    }

	//method to check list of items in inventory and update UI accordingly
	void UpdateInventoryContents(){
		//loop through list of items and set the sprite to the sprite of the item in the list
		for(int i = 0; i < Inventory.inventory.itemList.Count; i++){
			//set the item in inventory slot to the current item in the list
			inventorySlotsParentContainer.GetChild(i).GetComponent<InventorySlot>().item = Inventory.inventory.itemList[i];
			inventorySlotsParentContainer.GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().sprite = Inventory.inventory.itemList[i].itemImg;

			//make the sprite visible
			inventorySlotsParentContainer.GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
			//make the item slot interactable/clickable
			inventorySlotsParentContainer.GetChild(i).GetComponent<Button>().interactable = true;
		}
	}

	//display inventory screen/menu method
	void OpenInventory(){
		//display & turn off display when Q is pressed
		if(Input.GetKeyDown(KeyCode.Q) && !isDisplayed){
			//display
			inventorySlotsParentContainer.parent.gameObject.SetActive(true);
			isDisplayed = true;
		} else if(Input.GetKeyDown(KeyCode.Q) && isDisplayed){
			//hide
			inventorySlotsParentContainer.parent.gameObject.SetActive(false);
			isDisplayed = false;
		}
	}
}
