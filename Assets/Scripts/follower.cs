using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follower : MonoBehaviour
{
    public Transform player;
    public Rigidbody rb;
    public float moveSpeed = 5f;
    public Vector3 move;
    public float attackRange;
    public float distanceToPlayer;
    public Vector3 pushback;
    public int health=50;

    // Start is called before the first frame update
    void Start()
    {
        rb=this.GetComponent<Rigidbody>();
        pushback= new Vector3(10,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        //roation towards player
        Vector3 direction = player.position -transform.position;
        distanceToPlayer= Vector3.Distance(transform.position, player.position);
        move=direction;
        checkAlive();
       
    }

    void checkAlive(){
        if (health<=0){
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate(){
        moveCharacter(move, distanceToPlayer);
    }

    public void updateHealthE(){
        health=health-10;
        print(health);
    }

    void moveCharacter(Vector3 direction, float distanceToPlayer){
        //when player is close to the attack range enemy should move towards it 
        if (distanceToPlayer <= attackRange){ 
            rb.MovePosition(transform.position +(direction * moveSpeed * Time.deltaTime));
        }
    }

	//function for player to take damage when gets into contact with enemy
	void OnCollisionEnter(Collision x){
		//get player
		controlsMovement p = x.gameObject.GetComponent<controlsMovement>();

		//update player health with damage taken
		if(p != null){
			p.UpdateHealth(-1);
		}

        if (x.gameObject.name == "player_improved"){
            rb.velocity = new Vector3(10, 0, 10);
        }
	}
}
