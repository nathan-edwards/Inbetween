using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Jieying was here: creating a more generic collecting item script
public class CollectItem : MonoBehaviour
{
	public Item item;

	void OnTriggerEnter(Collider c){
		// Make sure it's the player colliding into the object
		if(c.gameObject.tag == "Player"){
			// Play Item Collect Sound
			SoundManager.PlaySound(SoundManager.Sound.PlayerPickup);
			// Add the item player touched to inventory before removing it from world
			Inventory.inventory.AddItem(item);
			Destroy(this.gameObject);
		}
	}
}
