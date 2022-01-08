using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// jieying was here: food item class
[CreateAssetMenu(fileName = "new food item", menuName = "jay-is-items/food")]
public class FoodItem : Item
{
	//stat to add to player hunger when they use food item
	public int hungerStat;

	// override use method to add to player hunger
	public override void Use()
	{
		Debug.Log("added " + hungerStat + "to player hunger");
	}
}
