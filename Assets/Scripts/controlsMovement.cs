using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlsMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody rb;
    Vector3 move;

    public Animator animator;

    //jieying was here: adding health & hunger
    private int health;
    public int maxHealth = 100;
    private int hunger;
    public int maxHunger = 100;

	//jieying was here: variables for timer & wait time respectively
	//feel free to change wait time (t2)
	float t1 = 0.0f;
	float t2 = 5.0f;

	//jieying was here: player alive status
	//I don't know if I'm doing unnecessary things or not
	private bool isAlive;
    
    void Start(){
        //jieying was here: set health and hunger to max at start of game
        // & make player starve periodically/lose hunger at set intervals
        health = maxHealth;
        hunger = maxHunger;
        //change timing later
        InvokeRepeating("Starve", 5.0f, 0.5f);

		isAlive = true;
    }
    ///

    void Update()
    {
        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

		//jieying was here: when hunger has reached 0, begin a timer that will make player lose health at set intervals
		depleteHealth();
		checkAliveStatus();
    }

    void FixedUpdate(){
        rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
    }

    //jieying was here: adding update health function
    public void UpdateHealth(int d){
        //update health &
        //make sure health doesn't go above max or below min
        health = Mathf.Clamp(health + d, 0, maxHealth);

		//update health bar
		HealthBar.instance.updateHealthBar(health);
        
        //test
        Debug.Log("health: " + health + "/" + maxHealth);
    }


    //jieying was here: function to make player starve/lose hunger
	//invokerepeating can't take functions with arguments :(
    void Starve(){
		if(isAlive){
			// hunger -= 5;
			// hunger = Mathf.Clamp(hunger, 0, maxHunger);
			UpdateHunger(-1);

			//update hunger bar UI
			HungerBar.instance.updateHungerBar(hunger);

			Debug.Log("hunger: " + hunger + "/" + maxHunger);
		}
    }

    //jieying was here: adding update hunger function
    public void UpdateHunger(int d){
        //update hunger &
        //make sure hunger doesn't go above max or below min
        hunger = Mathf.Clamp(hunger + d, 0, maxHunger);

		//update hunger bar
		HungerBar.instance.updateHungerBar(hunger);

        //test
        Debug.Log("hunger: " + hunger + "/" + maxHunger);
    }

	//jieying was here: function to deplete player health when hunger is at 0
	void depleteHealth(){
		if(hunger == 0 && isAlive){
			//start timer
			t1 += Time.deltaTime;
			//compare timer with desired wait time
			if(t1 >= t2){
				UpdateHealth(-10);
				//reset timer
				t1 -= t2;
			}
		} else {
			t1 = 0;
		}
	}

    ///
    public void printHealth(){
        // Debug.Log("Your health is: "+ health);
    }

	//jieying was here: check if player should die yet
	void checkAliveStatus(){
		if(health == 0){
			isAlive = false;
			FindObjectOfType<GameOver>().displayGameOver();
			Debug.Log("Player dead");
			Destroy(this.gameObject);
		}
	}

}


