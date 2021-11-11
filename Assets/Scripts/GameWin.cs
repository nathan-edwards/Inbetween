using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//jieying was here: making game over screen
public class GameWin : MonoBehaviour
{

    //Selects which Canvas object to interact with
    public Image img;

    //Variable for use by other scripts and functions to know the game has ended
    bool gameWin = false;

    //Game win screen is hidden in unity so function to set screen to active/visible when game has ended
    public void displayGameWin(){
        if(!gameWin){
            gameWin = true;
            img.gameObject.SetActive(true);
        }
    }
}