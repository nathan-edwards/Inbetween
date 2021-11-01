using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//jay was here - update health on collision and then make item disappear
public class CollectHealthItem : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
		controlsMovement p = other.GetComponent<controlsMovement>();

		if(p != null){
			p.UpdateHealth(10);
			print("got health potion");
			//test
			Destroy(gameObject);
		} else{
			print("it is null");
		}
	}
}
