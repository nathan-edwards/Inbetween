using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

	public Image img;
	bool gameEnd = false;
    public void displayGameOver(){
		if(!gameEnd){
			gameEnd = true;
			img.gameObject.SetActive(true);
		}
	}
}
