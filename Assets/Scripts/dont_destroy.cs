using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dont_destroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public Transform player;
    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(player.gameObject); 
    }
}
