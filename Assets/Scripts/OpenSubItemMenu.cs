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

	void Update(){
		OpenInventory();
	}

    public void OpenCraftingFromInventory(){
		craftingSlotsContainer.parent.gameObject.SetActive(true);
		inventorySlotsParentContainer.parent.gameObject.SetActive(false);
	}

	public void OpenInventoryFromCrafting(){
		inventorySlotsParentContainer.parent.gameObject.SetActive(true);
		craftingSlotsContainer.parent.gameObject.SetActive(false);
	}

	void OpenInventory(){
		//display & turn off display when Q is pressed
		if(Input.GetKeyDown(KeyCode.Q) && inventorySlotsParentContainer.parent.gameObject.activeSelf == false){
			//display
			inventorySlotsParentContainer.parent.gameObject.SetActive(true);

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
