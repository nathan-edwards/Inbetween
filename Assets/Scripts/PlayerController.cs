using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed = 1;
    public Animator animator;

	//jay was here: adding health & hunger
	private int health;
	public int maxHealth = 100;
	private int hunger;
	public int maxHunger = 100;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

		//jay was here - set health and hunger to max at start of game
		// & make player starve periodically/lose hunger at set intervals
		health = maxHealth;
		hunger = maxHunger;
		//change timing later
		InvokeRepeating("Starve", 5.0f, 0.5f);
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        // Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        // rb.AddForce(movement * speed);
        animator.SetFloat("Speed", Mathf.Abs(movementX * speed ));
        rb.velocity = new Vector3(movementX * speed, rb.velocity.y, movementY * speed);
    }

	//jay was here: adding update health function
	public void UpdateHealth(int d){
		//update health &
		//make sure health doesn't go above max or below min
		health = Mathf.Clamp(health + d, 0, maxHealth);

		//update health bar
		HealthBar.instance.updateHealthBar(health);
		
		//test
		Debug.Log(health + "/" + maxHealth);
	}

	//probably a cooler way of doing this out there but oh well
	//it works
	//¯\_(ツ)_/¯
	void Starve(){
		hunger -= 5;
		hunger = Mathf.Clamp(hunger, 0, maxHunger);
		Debug.Log(hunger + "/" + maxHunger);

		//update hunger bar
		HungerBar.instance.updateHungerBar(hunger);
	}

	//jay was here: adding update hunger function
	public void UpdateHunger(int d){
		//update hunger &
		//make sure hunger doesn't go above max or below min
		hunger = Mathf.Clamp(hunger + d, 0, maxHunger);

		//update hunger bar
		HungerBar.instance.updateHungerBar(hunger);

		//test
		Debug.Log(hunger + "/" + maxHunger);
	}
}