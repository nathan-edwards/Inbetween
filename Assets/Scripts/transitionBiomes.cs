using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transitionBiomes : MonoBehaviour
{	
	public Transform canvasUI;
    
    void OnCollisionEnter(Collision other) {						//Case of Touch
		if(other.gameObject.tag=="Player"){
			if (SceneManager. GetActiveScene () != SceneManager. GetSceneByName ("Biome 2")){
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
			}else{
				// canvasUI.SetActive(false);
				
			}
		}
	}
}
