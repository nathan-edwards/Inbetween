using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//jay was here - update health on collision and then make item disappear
public class CollectHealthItem : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
		PlayerController p = other.GetComponent<PlayerController>();

		if(p != null){
			p.UpdateHealth(10);

			//test
			Destroy(gameObject);
		}
	}
}
