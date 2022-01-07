using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// jieying was here: create an item from crafting menu when you click on the button
public class CreateItem : MonoBehaviour
{
	public Transform btn;
	CraftingRecipe recipe;

	public void SetItem(CraftingRecipe x){
		recipe = x;
	}

	//when button gets clicked, create the item
	public void CraftItem(){
		recipe.CreateItem();

		// btn.parent.GetComponent<CraftItemResultProfile>().HideItemDetails();
	}
}
