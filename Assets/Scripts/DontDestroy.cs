using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
	//the UI - health, hunger, game over screen - to preserve between biomes
	public Canvas healthHunger;
	//jieying was here: carry inventory over to next biome
	public Canvas inventory;

    void Update()
    {
		DontDestroyOnLoad(healthHunger);
		DontDestroyOnLoad(inventory);
    }
}
