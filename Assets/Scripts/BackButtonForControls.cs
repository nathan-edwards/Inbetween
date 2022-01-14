using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonForControls : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject controlsUI;
    public static bool GamePaused = false;
    public GameObject MenuUI;

    // Update is called once per frame
    void Update()
    {
		Debug.Log("here2");
        if (Input.GetKeyDown(KeyCode.C)){
            if (GamePaused){
                Resume();
				Debug.Log("here");
            } else { 
                Debug.Log("Controls visible + game paused");
                Pause();
				Debug.Log("here1");
            }
			Debug.Log("here3");
        } 
    }

    void Pause(){
        controlsUI.SetActive(true);
        Time.timeScale =0f;
        GamePaused= true;
    }

    // if BACK pressed
    public void Resume(){
        // CONTROLS disabled
        controlsUI.SetActive(false);
        Time.timeScale =1f;
        GamePaused= false;

        //if menu scene
        if(SceneManager. GetActiveScene () == SceneManager. GetSceneByName ("Menu") ){
            MenuUI.SetActive(true);
        }
    }
    
}
