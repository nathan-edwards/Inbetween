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
            // SceneManager.MoveGameObjectToScene(player, 0);
            print("yayy");
            // DontDestroyOnLoad(x.gameObject);
            // Scene sceneToLoad = SceneManager.GetSceneByName("jay_is_here");
            // SceneManager.MoveGameObjectToScene(x.gameObject, 'jay_is_here');
            SceneManager.LoadScene("jay_is_here");
            player.position= new Vector3(223,5,109);
        }
    }
}
