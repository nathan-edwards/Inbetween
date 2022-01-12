using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// jieying was here: assigning camera to inventory & hunger and health bars to player in biome 2
public class AssignCamera : MonoBehaviour
{
	Canvas inventory;
	Transform hungerBar;
	Transform healthBar;
	GameObject player;

    // Start is called before the first frame update
    void Start()
    {
		player = GameObject.FindWithTag("Player");

		inventory = GameObject.FindWithTag("inventory").GetComponent<Canvas>();
        inventory.worldCamera = Camera.main;

		// hungerBar = Transform.Find("HungerUI");
		// healthBar = Transform.Find("HealthUI");

		// player.GetComponent<Fox_Move>().HealthBar = healthBar;
		// player.GetComponent<Fox_Move>().HungerBar = hungerBar;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
