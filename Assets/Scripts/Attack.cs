using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator anim;
    public Transform attackPoint;
    public float attackRange=0.5f;
    public LayerMask enemyLayers;
    public int attackDamage=20;
    private Rigidbody rb;
    private SpriteRenderer sp;
    Player player;
    void Start(){
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
		sp=GetComponent<SpriteRenderer>();
        player = FindObjectOfType<Player>();
    }

    public void AttackAction(){
         if (player.swordOn == true)
         {
             Debug.Log("haleluia sword on");
             anim.SetBool("swordOn",true);
         }
         
         anim.SetTrigger("Attack");
         // for 3d enemies
         Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

         foreach(Collider enemy in hitEnemies){ 
             Debug.Log("We hit " + enemy.name);
             enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
         } 
         // anim.SetBool("Walking", true);
    }
}
