using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GameOverUI;
    // public GameObject player;
    private int count=0;

    public bool a;
    private Player alive;

    void Update(){
        // alive=FindObjectOfType<Fox_Move>();
        // a = alive.isAlive;
        print(Player.isAlive);
        GameIsOver();
    }
    
    public void GameIsOver(){
        //display game over just once
        Debug.Log("you died");
        if (Player.isAlive == false && count==0){
            count+=1;
            GameOverUI.SetActive(true);
        }
    }

    public void Menu(){
        GameOverUI.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void TryAgain(){	
        GameOverUI.SetActive(false);													//Just to Call the level again
		SceneManager.LoadScene(2);
	}
}
