using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options_Script : MonoBehaviour
{
    public int level;
    public GameObject easyUI;
    public GameObject mediumUI;
    public GameObject hardUI;
    //starve faster
    //enemy attack range increased
    //enemy damage increased

    public void easyLevel(){
        easyUI.SetActive(true);
        mediumUI.SetActive(false);
        hardUI.SetActive(false);
        level=1;
        Debug.Log("easy level");
    }

    public void mediumLevel(){
        mediumUI.SetActive(true);
        hardUI.SetActive(false);
        easyUI.SetActive(false);
        level=2;
        Debug.Log("medium level");
    }

    public void hardLevel(){
        hardUI.SetActive(true);
        mediumUI.SetActive(false);
        easyUI.SetActive(false);
        level=3;
        Debug.Log("hard level");
    }

    public void Back()
    {
       SceneManager.LoadScene(0);
    }

}
