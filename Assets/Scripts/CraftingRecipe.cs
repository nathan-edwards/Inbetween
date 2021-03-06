using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// jieying was here: scriptable object for crafting recipes
//inherits from Item class
[CreateAssetMenu(fileName = "crafting recipe", menuName = "jay-is-items/crafting recipes")]
public class CraftingRecipe : Item
{
	//parallel arrays
    public Item[] materials;
	public int[] quantities;
	public Item result;

	//add new recipe to player's learned recipes list
	//then remove item from inventory
	public override void Use(){
		CraftingMenu.craftingMenu.LearnRecipe(this);
		Inventory.inventory.RemoveItem(this);
	}

	public void CreateItem(){
		//take away item from inventory
		for(int i = 0; i < materials.Length; i++){
			for(int j = 0; j < quantities[i]; j++){
				Inventory.inventory.RemoveItem(materials[i]);
			}
		}

		//add new created item to inventory
		Inventory.inventory.AddItem(result);
	}
}
