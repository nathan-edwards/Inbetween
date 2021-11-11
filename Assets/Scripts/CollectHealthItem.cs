using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//jieying was here: update health on collision and then make item disappear
public class CollectHealthItem : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
		//get player
		ControlsMovement p = other.GetComponent<ControlsMovement>();

		//check if it's player and update health if it is
		if(other.gameObject.tag == "Player"){
			p.UpdateHealth(10);

			//then destroy collectible health item
			Destroy(this.gameObject);
		} else {
			print("it is null");
		}
	}
}
