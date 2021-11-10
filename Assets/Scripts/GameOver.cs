using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//jieying was here: making game over screen
public class GameOver : MonoBehaviour
{

	//to get game over screen
	public Image img;

	//to check if game ended
	bool gameEnd = false;

	//game over screen is hidden in unity so function to set screen to active when game has ended
    public void displayGameOver(){
		if(!gameEnd){
			gameEnd = true;
			img.gameObject.SetActive(true);
		}
	}
}
