using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// jieying was here: class for sword items
[CreateAssetMenu(fileName = "new sword item", menuName = "jay-is-items/sworditem")]
public class SwordItem : Item
{
	PlayerMove player;
	bool isEquipped = false;

	//override use method to equip sword to player
	public override void Use()
	{
		player = FindObjectOfType<PlayerMove>();
		player.swordOn = true;
		isEquipped = true;
	}
}
