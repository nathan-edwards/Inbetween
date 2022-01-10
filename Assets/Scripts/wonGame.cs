using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wonGame : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject winUI;
    public void Menu(){
        Time.timeScale =1f;
        winUI.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void TryAgain(){	
        Time.timeScale =1f;
        winUI.SetActive(false);													//Just to Call the level again
		SceneManager.LoadScene(2);
	}
}
