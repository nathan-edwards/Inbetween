using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// jieying was here: assigning camera to inventory & hunger and health bars to player when biome 2 scene loads
public class AssignCamera : MonoBehaviour
{
	Canvas inventory;
	Transform healthHunger;
	Fox_Move player;
	GameObject portal;

    // Start is called before the first frame update
    void Start()
    {
		//find player object
		player = GameObject.FindWithTag("Player").GetComponent<Fox_Move>();

		//find canvas that displays inventory
		//assign biome 2 camera to canvas
		inventory = GameObject.FindWithTag("inventory").GetComponent<Canvas>();
        inventory.worldCamera = Camera.main;

		//find the object that has the health and hunger UI
		healthHunger = GameObject.FindWithTag("Health").GetComponent<RectTransform>();
		
		//assign player the hunger and health UI bars
		player.healthBar = healthHunger.GetChild(0).GetComponent<HealthBar>();
		player.hungerBar = healthHunger.GetChild(1).GetComponent<HungerBar>();

		// find portal
		portal = GameObject.FindWithTag("Portal");
		portal.GetComponent<transitionBiomes>().canvasUI = healthHunger;
    }
}
