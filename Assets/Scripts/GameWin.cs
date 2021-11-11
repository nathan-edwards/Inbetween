using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//jieying was here: making game over screen
public class GameWin : MonoBehaviour
{

    //to get game over screen
    public Image img;

    //to check if game ended
    bool gameWin = false;

    //game over screen is hidden in unity so function to set screen to active/visible when game has ended
    public void displayGameWin(){
        if(!gameWin){
            gameWin = true;
            img.gameObject.SetActive(true);
        }
    }
}