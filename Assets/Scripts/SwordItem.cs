using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// jieying was here: class for sword items
[CreateAssetMenu(fileName = "new sword item", menuName = "jay-is-items/sworditem")]
public class SwordItem : Item
{
	//jieying was here: do u want to add attack stat?
	// public int hungerStat;

	//override use method to equip sword to player
	public override void Use()
	{
		Debug.Log("equip sword");
	}
}
