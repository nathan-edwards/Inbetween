using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//jay was here - update hunger on collision and then make item disappear
public class CollectFoodItem : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
		PlayerController p = other.GetComponent<PlayerController>();

		if(p != null){
			p.UpdateHunger(10);

			//test
			Destroy(gameObject);
		}
	}
}
