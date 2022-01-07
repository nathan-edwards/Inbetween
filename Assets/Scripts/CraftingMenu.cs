using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// jieying was here: creating a crafting menu
public class CraftingMenu : MonoBehaviour
{
	//list to store all crafting recipes
	public List<CraftingRecipe> recipeList = new List<CraftingRecipe>();

	//creating a single instance of inventory
	public static CraftingMenu craftingMenu;

	void Awake(){
		if(craftingMenu != null){
			Debug.Log("a crafting thing already exists");
		} else {
			craftingMenu = this;
		}
	}

	//what recipes the player knows, add to list
	public void LearnRecipe(CraftingRecipe recipe){
		recipeList.Add(recipe);
	}
}
