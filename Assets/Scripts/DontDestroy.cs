using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
	// public Transform player;

	//the UI - health, hunger, game over screen - to preserve between biomes
	public Canvas healthHunger;
	public Canvas inventory;
    // Update is called once per frame
    void Update()
    {
        // DontDestroyOnLoad(player.gameObject);
		DontDestroyOnLoad(healthHunger);
		DontDestroyOnLoad(inventory);
    }
}
