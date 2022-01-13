using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// jieying was here: script for crafting menu UI
public class CraftingMenuUI : MonoBehaviour
{
	public Transform craftingSlotsContainer;

    void Update()
    {
		DisplayAllLearnedRecipes();
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
