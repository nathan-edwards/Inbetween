using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeWorlds : MonoBehaviour
{

    public Transform player;

    private void OnCollisionEnter( Collision x){
        if (x.gameObject.name == "portal"){
            SceneManager.LoadScene("Biome 2");
            player.position= new Vector3(401,33,15);
        }
    }
}
