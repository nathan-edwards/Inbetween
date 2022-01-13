using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options_Script : MonoBehaviour
{
    public static int level;
    public int damagerate;
    public int attackRange;
    public GameObject easyUI;
    public GameObject mediumUI;
    public GameObject hardUI;
    //starve faster
    //enemy attack range increased
    //enemy damage increased
    void Start(){
        level=1;
    }
    public void easyLevel(){
        easyUI.SetActive(true);
        mediumUI.SetActive(false);
        hardUI.SetActive(false);
        level=1;
        damagerate=5;
        attackRange=10;
        Debug.Log("easy level");
    }

    public void mediumLevel(){
        mediumUI.SetActive(true);
        hardUI.SetActive(false);
        easyUI.SetActive(false);
        level=2;
        damagerate=10;
        attackRange=15;
        Debug.Log("medium level");
    }

    public void hardLevel(){
        hardUI.SetActive(true);
        mediumUI.SetActive(false);
        easyUI.SetActive(false);
        level=3;
        damagerate=15;
        attackRange=20;
        Debug.Log("hard level");
    }

    public void Back()
    {
       SceneManager.LoadScene(0);
    }

}
