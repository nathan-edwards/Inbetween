using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class Fox_Move : MonoBehaviour {

    public float speed,jumpForce;
	public bool running,up,down,jumping,crouching,dead,attacking,special;
    private Rigidbody rb;
    private Animator anim;
	private SpriteRenderer sp;
	public Transform player;
    public Follower E;
	public HealthBar healthBar;
	public HungerBar hungerBar;
	private bool isAlive;

	//character's needs
    private int health;
    public int maxHealth = 100;
    private float hunger;
    public float maxHunger = 100;
	public float moveSpeed = 5f;

	//jieying was here: variables for timer & wait time respectively
	//feel free to change wait time (t2)
	float t1 = 0.0f;
	float t2 = 5.0f;
	

	void Start () {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
		sp=GetComponent<SpriteRenderer>();
		running=false;
		up=false;
		down=false;
		jumping=false;
		crouching=false;

		health = maxHealth;
        hunger = maxHunger;

		// healthBar = FindObjectOfType<HealthBar>();
		// hungerBar = FindObjectOfType<HungerBar>();

        //change timing later
        InvokeRepeating("Starve", 5.0f, 0.5f);
		isAlive = true;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if(dead==false){
		//preventing character to change direction in Jump									
			if(attacking==false){													
				if(crouching==false){
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
		if(Input.GetKeyDown(KeyCode.Space)){
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
		
	}

	void Dead(){
	
	}

	//jieying was here: adding update health function
    public void UpdateHealth(int d){
        //make sure health doesn't go above max or below min
        health = Mathf.Clamp(health + d, 0, maxHealth);
		//update health bar
		healthBar.updateHealthBar(health);
    }

	void Starve(){
		if(isAlive){
			UpdateHunger(-0.1f);
			//update hunger bar UI
			// hungerBar.updateHungerBar(hunger);
		}
    }

	public void UpdateHunger(float d){
        //make sure hunger doesn't go above max or below min
        hunger = Mathf.Clamp(hunger + d, 0, maxHunger);
		//update hunger bar
		// hungerBar.updateHungerBar(hunger);
    }

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
			UpdateHealth(0);
		}
	}

	void checkAliveStatus(){
		//if player dies then end game and do the end game related things like show game over screen
		if(health <= 0){
			isAlive = false;
			FindObjectOfType<GameOver>().displayGameOver();
			Debug.Log("Player dead");
		}
	}

	  void checkIfFalling(){
        if(rb.position.y < 0){
            print(rb.position.y);
            UpdateHunger(-100f);
            UpdateHealth(-100);
            UpdateHunger(-100.0f);
            Destroy(this.gameObject);
            // FindObjectOfType<GameOver>().displayGameOver();
            TryAgain();
        }
    }

	public void TryAgain(){														//Just to Call the level again
		SceneManager.LoadScene("Fox_Demo");
	}
}
