using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class Fox_Move : MonoBehaviour {

    public float speed,jumpForce;
	public bool running,up,down,jumping,crouching,attacking,special,walking, swordOn;
    private Rigidbody rb;
    private Animator anim;
	private SpriteRenderer sp;
	public Transform player;
    public Follower E;
	public HealthBar healthBar;
	public HungerBar hungerBar;
	private bool isAlive;

	public Transform Enemy;

	//character's needs
    private int health;
    public int maxHealth = 100;
    private float hunger;
    public float maxHunger = 100;
	public float moveSpeed = 3f;

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
		swordOn=false;
		walking=false;
		health = 100;
        hunger = maxHunger;

		// healthBar = FindObjectOfType<HealthBar>();
		// hungerBar = FindObjectOfType<HungerBar>();

        //change timing later
        InvokeRepeating("Starve", 5.0f, 0.5f);
		isAlive = true;

	}
	void Update(){
		
	}
	// Update is called once per frame
	void FixedUpdate () {
		if(isAlive==true){								
			if(attacking==false){													
					Movement();
					Attack();
			}
		}else {
			Dead();
			anim.SetBool("Walking", false);
		}
	}

	public void Movement(){
		anim.SetBool("Walking",false);

		//Character Move
		float move_x = Input.GetAxisRaw("Horizontal");
		float move_z = Input.GetAxisRaw("Vertical");
		
		if (Input.GetKey(KeyCode.A) ||  
			Input.GetKey(KeyCode.LeftArrow) || 
			Input.GetKey(KeyCode.S) ||  
			Input.GetKey(KeyCode.D) ||
			Input.GetKey(KeyCode.RightArrow) ||
			Input.GetKey(KeyCode.UpArrow) ||
			Input.GetKey(KeyCode.DownArrow) ||
			Input.GetKey(KeyCode.W) ){

			if(Input.GetKey(KeyCode.Z)){
				//Run (x2 faster than walking)
				rb.velocity = new Vector3(move_x*speed*Time.deltaTime*4,rb.velocity.y, move_z *speed*Time.deltaTime*4);
				running=true;
				walking=false;
				anim.SetBool("Walking",false);
				// down=true;
			}else{
				//Walk
				rb.velocity = new Vector3(move_x*speed*Time.deltaTime*2,rb.velocity.y, move_z *speed*Time.deltaTime*2);
				running=false;
				walking=true;
				// down=true;
			}
		}
		//chekc if falling
		Fall();
		//Movement Animation
		moveAnim();
		//flip vertically
		Turn();
	}


	void moveAnim(){
			// down=true;
			
			if(rb.velocity.x!=0 && walking==true){
				anim.SetBool("Walking",true);
				
			}else{
				anim.SetBool("Walking",false);
				walking=false;
			}
			if(rb.velocity.x!=0&&running==true){
				anim.SetBool("Running",true);
				
			}else{
				anim.SetBool("Running",false);
			}

			if(rb.velocity.z!=0&&running==false){
				anim.SetBool("Walking",true);
				walking=true;
			}
			if(rb.velocity.z!=0&&running==true){
				anim.SetBool("Running",true);
				running=true;
			}
	
	}

	void Turn(){
		// anim.SetBool("Walking",false);
		if(rb.velocity.x<0){
			sp.flipX=true;
		}else if(rb.velocity.x>0){
			sp.flipX=false;
		}
	}
	void Attack(){																//I activated the attack animation and when the 
		if (Input.GetKeyDown(KeyCode.Space)){
			if(rb.velocity.x<0){
				sp.flipX=true;
			}else if(rb.velocity.x>0){
				sp.flipX=false;
			}
			rb.GetComponent<attack>().Attack();
			// walking=true;
        }
	}
	void Fall(){

		//  if(rb.velocity.y>0 && up==false){
        //     up=true;
		// }else if(rb.velocity.y<0 && down==false){
        //     down=true;
		// 	up=true;
        //     anim.SetTrigger("Down");
		// 	print("down is "+ down);

        // }else if(rb.velocity.y==0 && (up==true||down==true)){
        //     up=false;
        //     down=false;
        //     anim.SetTrigger("Ground");
		// 	print("down is "+ down);
        // }
	}
	
	void AttackEnd(){
		attacking=false;
	}					

	// touch enemy 
	void OnCollisionEnter(Collision other) {						//Case of Touch
		if(other.gameObject.tag=="Enemy"){
			// health goes down
			Hurt();
		}
	}
	public float m_Thrust = 20f;
	void Hurt(){
		// decrease health here
		anim.SetTrigger("Damage");
		rb.velocity *= -100;
		// transform.LookAt(Enemy);
		anim.SetBool("Walking",false);
		UpdateHealth(-10);
		//jump back when hurt
		rb.AddForce(player.up * m_Thrust);
		
	}

	void Dead(){
		// dying animation
		Debug.Log("YOU DIED");
		anim.SetTrigger("Dead");
		// FindObjectOfType<GameOver>().displayGameOver();
		
	}

	//jieying was here: adding update health function
    public void UpdateHealth(int d){
        //make sure health doesn't go above max or below min
		if (isAlive == true){
			health = Mathf.Clamp(health + d, 0, maxHealth);
			//update health bar
			// healthBar.updateHealthBar(health);
			print("Player health is "+ health+ " right now");
			checkAliveStatus();
		}
    }

	void Starve(){
		if(isAlive){
			UpdateHunger(-0.1f);
			//update hunger bar UI
			// hungerBar.updatewHungerBar(hunger);
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
		}
	}

	// face the enemy when taking damage
	// ,........
	

	public void TryAgain(){														//Just to Call the level again
		SceneManager.LoadScene("enemy-player attack");
	}
}
