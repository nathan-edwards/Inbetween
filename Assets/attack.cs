using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    public Animator anim;
    public Transform attackPoint;
    public float attackRange=0.5f;
    public LayerMask enemyLayers;
    public int attackDamage=20;
    private Rigidbody rb;
    private SpriteRenderer sp;

    void Start(){
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
		sp=GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
    }

    public void Attack(){
        anim.SetTrigger("Attack");
    // for 3d enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies){
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            
        }
        // anim.SetBool("Walking", true);
    }

    
}
