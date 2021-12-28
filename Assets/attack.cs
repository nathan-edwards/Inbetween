using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    public Animator anim;
    public Transform attackPoint;
    public float attackRange=0.5f;
    public LayerMask enemyLayers;
    void Start(){
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            Attack();
        }
    }

    void Attack(){
        anim.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies){
            Debug.Log("We hit" + enemy.name);
        }
    }
}
