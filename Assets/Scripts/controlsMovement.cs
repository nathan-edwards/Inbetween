using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlsMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody rb;
    Vector3 move;

    public Animator animator;

    //jay was here: adding health & hunger
    private int health;
    public int maxHealth = 100;
    public int hunger;
    public int maxHunger = 100;
    
    void start(){
        //jay was here - set health and hunger to max at start of game
        // & make player starve periodically/lose hunger at set intervals
        health = maxHealth;
        hunger = maxHunger;
        //change timing later
        InvokeRepeating("starve", 5.0f, 0.5f);
    }
    ///

    void Update()
    {
        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

    }

    void FixedUpdate(){
        rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
    }

    //jay was here: adding update health function
    public void UpdateHealth(int d){
        //update health &
        //make sure health doesn't go above max or below min
        health = Mathf.Clamp(health + d, 0, maxHealth);
        
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
    }

    //jay was here: adding update hunger function
    public void UpdateHunger(int d){
        //update hunger &
        //make sure hunger doesn't go above max or below min
        hunger = Mathf.Clamp(hunger + d, 0, maxHunger);

        //test
        Debug.Log(hunger + "/" + maxHunger);
    }
    ///
    public void printHealth(){
        Debug.Log("Your health is: "+ health);
    }

    // stop the player from moving when touches an object
    //     void OnCollisionEnter(Collision collision) 
    // {
    //         if(collision.gameObject.name == "YourWallName")  // or if(gameObject.CompareTag("YourWallTag"))
    //         {
    //                     rigidbody.velocity = Vector3.zero;
    //         }
    // }
}


