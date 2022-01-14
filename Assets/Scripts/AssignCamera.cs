using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// jieying was here: assigning camera to inventory & hunger and health bars to player when biome 2 scene loads
public class AssignCamera : MonoBehaviour
{
	Canvas inventory;
	Transform healthHunger;
	Player player;
	GameObject portal, healthHunger2;

    // Start is called before the first frame update
    void Start()
    {
		//find player object
		player = GameObject.FindWithTag("Player").GetComponent<Player>();

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
		//assign health hunger bars to transition biomes script using code
		//since it cant be done via inspector
		healthHunger2= GameObject.FindWithTag("Health");
		portal.GetComponent<TransitionBiomes>().canvasUI = healthHunger2;

		
    }
}
