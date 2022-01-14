using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseMenuUI;
    public static bool GamePaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)){
            if (GamePaused){
                Debug.Log("Continue Game");
                Resume();
            } else {
            Debug.Log("Paused Game");
                Pause();
            }
        } 
    }

    void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale =0f;
        GamePaused= true;
    }
    
    public void Options(){
        SceneManager.LoadScene(4);
    }

    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale =1f;
        GamePaused= false;
    }

    public void ContinueGame(){
        Resume();
    }

    public void Menu(){
        SceneManager.LoadScene(0);
    }
}
