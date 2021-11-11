using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
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
        Vector3 player = GameObject.FindGameObjectsWithTag("Player")[0].transform.position;
        //roation towards player
        Vector3 direction = player -transform.position;
        distanceToPlayer= Vector3.Distance(transform.position, player);
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

    public void UpdateHealthE(){
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
		ControlsMovement p = x.gameObject.GetComponent<ControlsMovement>();

		//update player health with damage taken
		if(p != null){
			p.UpdateHealth(-1);
		}

        if (x.gameObject.name == "player_improved"){
            rb.velocity = new Vector3(10, 0, 10);
        }
	}
}
