using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class change_worlds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter( Collision x){
        if (x.gameObject.name == "portal"){
            SceneManager.LoadScene("jay_is_here");
        }
    }
}
