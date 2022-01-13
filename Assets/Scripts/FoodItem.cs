using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// jieying was here: food item class
[CreateAssetMenu(fileName = "new food item", menuName = "jay-is-items/food")]
public class FoodItem : Item
{
	//stat to add to player hunger when they use food item
	public int hungerStat;
	Fox_Move player;

	// override use method to add to player hunger
	public override void Use()
	{
		//find player and update their hunger with the stat of the food item
		//then remove item from inventory
		player = FindObjectOfType<Fox_Move>();
		player.UpdateHunger((float)hungerStat);
		Inventory.inventory.RemoveItem(this);
	}
}
