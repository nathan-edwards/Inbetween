using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class OptionsScript : MonoBehaviour
{
    public static int level;
    public static int damagerate;
    public static int attackRange;
    public GameObject easyUI;
    public GameObject mediumUI;
    public GameObject hardUI;
    public AudioMixer audioMixer;
    
    //starve faster
    //enemy attack range increased
    //enemy damage increased
    void Start(){
        //if no level selected then considered level easy
        level=1;
        damagerate=5;
        attackRange=10;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
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
