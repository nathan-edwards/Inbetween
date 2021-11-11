using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public Transform player;

	//the UI - health, hunger, game over screen - to preserve between biomes
	public GameObject canvas;
    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(player.gameObject);
		DontDestroyOnLoad(canvas);
    }
}
