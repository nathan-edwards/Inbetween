using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject controlsUI;
    public GameObject MenuUI;

    // Update is called once per frame
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void Controls()
    {
        Debug.Log("CONTROLS");
        // CONTROLS Enable
        controlsUI.SetActive(true);
        // MENU disabled
        MenuUI.SetActive(false);
    }
    public void Options()
    {
        Debug.Log("OPTIONS");
        // Application.Quit();
    }

}
