using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// jieying was here: create health item class
[CreateAssetMenu(fileName = "new health item", menuName = "jay-is-items/healthitem")]

public class HealthItem : Item
{
	//how much health that can be recovered using item
	public int healthStat;

	//override Item class use method to add health to player health upon use
	public override void Use()
	{
		Debug.Log("added " + healthStat + "to player health");
	}
}
