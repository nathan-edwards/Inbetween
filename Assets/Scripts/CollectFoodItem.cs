using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//jieying was here: update hunger on collision and then make item disappear
public class CollectFoodItem : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
		//get player
		ControlsMovement p = other.GetComponent<ControlsMovement>();

		//check if it's player and update health it is
		if(other.gameObject.tag == "Player"){
			p.UpdateHunger(10);

			//then destroy food item collected
			Destroy(this.gameObject);
		} else {
			print("it is null");
		}
	}
}
