﻿using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class Fox_Move : MonoBehaviour {

    public float speed,jumpForce,cooldownHit;
	public bool running,up,down,jumping,crouching,dead,attacking,special;
    private Rigidbody rb;
    private Animator anim;
	private SpriteRenderer sp;
	private float rateOfHit;
	private GameObject[] life;
	private int qtdLife;

	public float moveSpeed = 5f;

	void Start () {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
		sp=GetComponent<SpriteRenderer>();
		running=false;
		up=false;
		down=false;
		jumping=false;
		crouching=false;
		rateOfHit=Time.time;
		life=GameObject.FindGameObjectsWithTag("Life");
		qtdLife=life.Length;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if(dead==false){
		//preventing character to change direction in Jump									
			if(attacking==false){													
				if(jumping==false&&crouching==false){
					Movement();
					Attack();
					Special();
				}
				Jump();
				Crouch();
			}
			Dead();
		}

	}

	void Movement(){
		//Character Move
		float move_x = Input.GetAxisRaw("Horizontal");
		float move_z = Input.GetAxisRaw("Vertical");
		// vertical = z
		// horizontal = x
		// up = y
		//  if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f){
        //     rb.velocity = new Vector3(move_x, rb.velocity.y, move_z *speed*Time.deltaTime*3);
        // }

		if(Input.GetKey(KeyCode.Z)){
			//Run (x2 faster than walking)
			rb.velocity = new Vector3(move_x*speed*Time.deltaTime*4,rb.velocity.y, move_z *speed*Time.deltaTime*4);
			running=true;
		}else{
			//Walk
			rb.velocity = new Vector3(move_x*speed*Time.deltaTime*2,rb.velocity.y, move_z *speed*Time.deltaTime*2);
			running=false;
		}

		//Turn
		if(rb.velocity.x<0){
			sp.flipX=true;
		}else if(rb.velocity.x>0){
			sp.flipX=false;
		}

		//Movement Animation
		if(rb.velocity.x!=0&&running==false){
			anim.SetBool("Walking",true);
		}else{
			anim.SetBool("Walking",false);
		}
		if(rb.velocity.x!=0&&running==true){
			anim.SetBool("Running",true);
		}else{
			anim.SetBool("Running",false);
		}

		if(rb.velocity.z!=0&&running==false){
			anim.SetBool("Walking",true);
		}
		if(rb.velocity.z!=0&&running==true){
			anim.SetBool("Running",true);
		}
	}

	void Jump(){
		//Jump
		if(Input.GetKeyDown(KeyCode.Space)&&rb.velocity.y==0){
			rb.AddForce(new Vector3(0f,10f,0f));

		}
		//Jump Animation

		//NOT WORKING ATM
		if(rb.velocity.y>0 && up==false){
			up=true;
			jumping=true;
			anim.SetTrigger("Up");
		}else if(rb.velocity.y<0 && down==false){
			down=true;
			jumping=true;
			anim.SetTrigger("Down");
		}else if(rb.velocity.y==0 && (up==true||down==true)){
			up=false;
			down=false;
			jumping=false;
			anim.SetTrigger("Ground");
		}
	}

	void Attack(){																//I activated the attack animation and when the 
		//Atacking																//animation finish the event calls the AttackEnd()
		if(Input.GetKeyDown(KeyCode.X)){
			rb.velocity=new Vector3(0,0,0);
			anim.SetTrigger("Attack");
			attacking=true;
		}
	}

	void AttackEnd(){
		attacking=false;
	}

	void Special(){
		if(Input.GetKey(KeyCode.F)){
			anim.SetBool("Special",true);
		}else{
			anim.SetBool("Special",false);
		}
	}

	void Crouch(){
		//Crouch
		if(Input.GetKey(KeyCode.C)){
			anim.SetBool("Crouching",true);
		}else{
			anim.SetBool("Crouching",false);
		}
	}

	void OnTriggerEnter(Collider other){							//Case of Bullet
		if(other.tag=="Enemy"){
			anim.SetTrigger("Damage");
			Hurt();
		}
	}								

	void OnCollisionEnter(Collision other) {						//Case of Touch
		if(other.gameObject.tag=="Enemy"){
			anim.SetTrigger("Damage");
			Hurt();
		}
	}

	void Hurt(){
		if(rateOfHit<Time.time){
			rateOfHit=Time.time+cooldownHit;
			// Destroy(life[qtdLife-1]);
			qtdLife -=1;
		}
	}

	void Dead(){
		// here add code on how it can be killed

		// if(qtdLife<=0){
		// 	anim.SetTrigger("Dead");
		// 	dead=true;

		// }
	}

	public void TryAgain(){														//Just to Call the level again
		SceneManager.LoadScene("Fox_Demo");
	}
}
