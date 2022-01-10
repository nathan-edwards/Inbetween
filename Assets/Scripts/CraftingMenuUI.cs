using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// jieying was here: script for crafting menu UI
public class CraftingMenuUI : MonoBehaviour
{
	public Transform craftingSlotsContainer;

    // Update is called once per frame
    void Update()
    {
        // OpenCraftingMenu();
		DisplayAllLearnedRecipes();
    }

	//display crafting screen/menu method
	void OpenCraftingMenu(){
		//display & turn off display when Q is pressed
		if(Input.GetKeyDown(KeyCode.E) && craftingSlotsContainer.parent.gameObject.activeSelf == false){
			//display
			craftingSlotsContainer.parent.gameObject.SetActive(true);
		} else if(Input.GetKeyDown(KeyCode.E) && craftingSlotsContainer.parent.gameObject.activeSelf == true){
			//hide
			craftingSlotsContainer.parent.gameObject.SetActive(false);

			craftingSlotsContainer.parent.GetChild(2).GetComponent<CraftItemResultProfile>().HideRecipeDetails();
		}
	}

	void DisplayAllLearnedRecipes(){
		//loop through list of items and set the sprite to the sprite of the item in the list
		for(int i = 0; i < CraftingMenu.craftingMenu.recipeList.Count; i++){
			//set the item in inventory slot to the current item in the list
			craftingSlotsContainer.GetChild(i).GetComponent<CraftingSlot>().recipe = CraftingMenu.craftingMenu.recipeList[i];
			craftingSlotsContainer.GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().sprite = CraftingMenu.craftingMenu.recipeList[i].result.itemImg;

			//make the sprite visible
			craftingSlotsContainer.GetChild(i).GetChild(0).GetComponent<SpriteRenderer>().enabled = true;

			//make the item slot interactable/clickable
			craftingSlotsContainer.GetChild(i).GetComponent<Button>().interactable = true;
		}
	}
}
