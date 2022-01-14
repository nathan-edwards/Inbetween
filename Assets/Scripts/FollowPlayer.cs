using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.UI;

 public class FollowPlayer : MonoBehaviour
 {
    private Animator anim;
    // public Transform player; // girl
    private Transform player;
    public float detectRange = 100; // this gets multiplied by itself to compare to a sqr magnitude check (instead of distance)
    public bool inRange = false;
    public float moveSpeed = 5f; // enemy speed
    Rigidbody rb;  
    public float attackRange= 5; // when to attack
    public bool walking;
    float distsqr;
    private SpriteRenderer sp;
    
    

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        detectRange *= detectRange;
        player = GameObject.FindWithTag("Player").transform;
    }
    
    void Start(){
        anim = GetComponent<Animator>();
        anim.SetBool("Walking", false);
        sp=GetComponent<SpriteRenderer>();
        walking=false;
    }
    void Update()
    {
        // a little cheaper than 'distance'.. deleted the code to create a position from the player values.
        distsqr = (player.position - transform.position).sqrMagnitude;
        //if (walking == false){
        whatever();
        //}
    }

    void Turn(){
		// anim.SetBool("Walking",false);
		if(rb.velocity.x<0){
			sp.flipX=true;
		}else if(rb.velocity.x>0){
			sp.flipX=false;
		}
	}

    void whatever(){
        Turn();
        if (distsqr <= detectRange)
        {   
            // if in range walk towards
            anim.SetBool("Walking", true);
            walking=true;
            inRange = true;
            Vector3 velocity = (player.transform.position - transform.position).normalized * moveSpeed;
            rb.velocity = velocity;
            
        }else{
            //disable walking animation as it is just in idle
            anim.SetBool("Walking", false);
            walking=false;
        }
        if (distsqr <attackRange){
            // attack animation
            SoundManager.PlaySound(SoundManager.Sound.EnemyAttack, transform.position);
            anim.SetTrigger("attack");
        }
    }


 }