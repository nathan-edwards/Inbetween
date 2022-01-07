using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//jieying was here: making a script for crafting slot
//it's just inventoryslot.cs but changed a little bit
public class CraftingSlot : MonoBehaviour
{
	//make crafting slot have a reipe
	public CraftingRecipe recipe;
	//to store the crafting item result profile object from hierarchy
	GameObject profile;

	//find the profile gameobject
	void Start(){
		profile = GameObject.Find("CraftingItemResultProfile");
	}

	//when the crafting slot is clicked,
	//pass the item that the crafting slot is holding to the crafting item result profile
	//and make the profile display the result item details
	public void SelectSlot(){
		profile.GetComponent<CraftItemResultProfile>().recipe = this.recipe;
		profile.GetComponent<CraftItemResultProfile>().DisplayRecipeDetails();
	}
}
