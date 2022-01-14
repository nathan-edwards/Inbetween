using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//jieying was here: opening and closing inventory/crafting menus
//otherwise if u open inventory and then open crafting, inventory is still open
//so it'll look weird
//also feels clumsy trying to open & close stuff otherwise
//so now it's just one button (Q)
public class OpenSubItemMenu : MonoBehaviour
{
	public Transform craftingSlotsContainer;
	public Transform inventorySlotsParentContainer;
	public Transform craftItemResultProfile;
	public Transform inventoryItemProfile;
	
	void Update(){
		OpenInventory();
	}

	//make crafting visible when crafting menu title selected
    public void OpenCraftingFromInventory(){
		//redraws item result profile so it's empty instead of displaying
		//what the player selected the last time they opened the crafting menu
		craftItemResultProfile.GetComponent<CraftItemResultProfile>().HideRecipeDetails();

		//then make crafting menu visible
		craftingSlotsContainer.parent.gameObject.SetActive(true);
		inventorySlotsParentContainer.parent.gameObject.SetActive(false);
	}

	//make inventory visible when inventory title selected
	public void OpenInventoryFromCrafting(){
		//redraws item result profile so it's empty instead of displaying
		//what the player selected the last time they opened the inventory menu
		inventoryItemProfile.GetComponent<ItemProfile>().HideItemDetails();

		//then make inventory visible
		inventorySlotsParentContainer.parent.gameObject.SetActive(true);
		craftingSlotsContainer.parent.gameObject.SetActive(false);
	}

	//open inventory using Q key press
	void OpenInventory(){
		//display & turn off display when Q is pressed
		if(Input.GetKeyDown(KeyCode.Q) && inventorySlotsParentContainer.parent.gameObject.activeSelf == false){
			//display
			inventorySlotsParentContainer.parent.gameObject.SetActive(true);
			inventoryItemProfile.GetComponent<ItemProfile>().HideItemDetails();

			//pause game while open
			Time.timeScale = 0f;
		} else if(Input.GetKeyDown(KeyCode.Q) && inventorySlotsParentContainer.parent.gameObject.activeSelf == true || Input.GetKeyDown(KeyCode.Q) && craftingSlotsContainer.parent.gameObject.activeSelf == true){
			//hide
			inventorySlotsParentContainer.parent.gameObject.SetActive(false);
			craftingSlotsContainer.parent.gameObject.SetActive(false);

			//resume time when close
			Time.timeScale = 1f;
		}
	}
}
