using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ControlsMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody rb;
    Vector3 move;
    public Transform player;
    public Follower E;
    public Animator animator;

    //jieying was here: adding health & hunger & their respective UI elements
    private int health;
    public int maxHealth = 100;
    private float hunger;
    public float maxHunger = 100;

	public HealthBar healthBar;
	public HungerBar hungerBar;

	//jieying was here: variables for timer & wait time respectively
	//feel free to change wait time (t2)
	float t1 = 0.0f;
	float t2 = 5.0f;

	//jieying was here: player alive status
	//I don't know if I'm doing unnecessary things or not
	private bool isAlive;
    
    void Start(){
        //jieying was here: set health and hunger to max at start of game
		// & find health and hunger UI elements
        // & make player starve periodically/lose hunger at set intervals
        health = maxHealth;
        hunger = maxHunger;

		healthBar = FindObjectOfType<HealthBar>();
		hungerBar = FindObjectOfType<HungerBar>();

        //change timing later
        InvokeRepeating("Starve", 5.0f, 0.5f);
		isAlive = true;
    }

    void Update()
    {
        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		//when hunger has reached 0, begin a timer that will make player lose health at set intervals
		depleteHealth();
		checkAliveStatus();
        checkIfFalling();
        
    }

    public void OnMouseDown(){
            // this object was clicked - do something
            // if (this.gameObject.name == "Enemy1"){
            //     Destroy(this.gameObject);
            //     E.updateHealthE();
            //     print("touched enemy1");
            // }else{
            //     print("something else");
            // }
        Destroy (this.gameObject);
        print("niceeee");
        
    }

    void checkIfFalling(){
        if(rb.position.y < 0){
            print(rb.position.y);
            UpdateHunger(-100f);
            UpdateHealth(-100);
            UpdateHunger(-100.0f);
            Destroy(this.gameObject);
            // FindObjectOfType<GameOver>().displayGameOver();
            StartCoroutine(waiter());
            Application.LoadLevel("Biome 1");
        }
    }

    void FixedUpdate(){
        rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
    }

    IEnumerator waiter()
    {
        //Wait for 4 seconds
        yield return new WaitForSeconds(10);
    }

    //jieying was here: adding update health function
    public void UpdateHealth(int d){
        //make sure health doesn't go above max or below min
        health = Mathf.Clamp(health + d, 0, maxHealth);
		//update health bar
		healthBar.updateHealthBar(health);
    }

    //jieying was here: function to make player starve/lose hunger
    void Starve(){
		if(isAlive){
			UpdateHunger(-0.1f);
			//update hunger bar UI
			hungerBar.updateHungerBar(hunger);
		}
    }

    //jieying was here: adding update hunger function
    public void UpdateHunger(float d){
        //make sure hunger doesn't go above max or below min
        hunger = Mathf.Clamp(hunger + d, 0, maxHunger);
		//update hunger bar
		hungerBar.updateHungerBar(hunger);
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
			//probably not the best fix but this helps transferring health from biome 1 over to biome 2
			//otherwise health ui will show as full in biome 2 even though the value of player's current health might not be 100%
			//will make ui display as current health
			//since depleteHealth() gets called in update, it will draw hence temporary fix
			UpdateHealth(0);
		}
	}

	//jieying was here: check if player should die yet
	void checkAliveStatus(){
		//if player dies then end game and do the end game related things like show game over screen
		if(health <= 0){
			isAlive = false;
			FindObjectOfType<GameOver>().displayGameOver();
			Debug.Log("Player dead");
		}
	}

}


