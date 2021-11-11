using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class change_worlds : MonoBehaviour
{

    public Transform player;
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
            SceneManager.LoadScene("Biome 2");
            player.position= new Vector3(401,33,15);
        }
    }
}
