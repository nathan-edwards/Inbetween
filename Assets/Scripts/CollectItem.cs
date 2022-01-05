using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//jieying was here: creating a more generic collecting item script
public class CollectItem : MonoBehaviour
{
	public Item item;

    void OnTriggerEnter(Collider c){
		//make sure it's the player colliding into the object
		if(c.gameObject.tag == "Player"){
			//add the item player touched to inventory before removing it from world
			Inventory.inventory.AddItem(item);
			Destroy(this.gameObject);
		}
	}
}
