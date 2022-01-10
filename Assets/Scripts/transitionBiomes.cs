using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class transitionBiomes : MonoBehaviour
{
    
    void OnCollisionEnter(Collision other) {						//Case of Touch
		if(other.gameObject.tag=="Player"){
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}
}
