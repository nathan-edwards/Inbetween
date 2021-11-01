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

    // Start is called before the first frame update
    void Start()
    {
        rb=this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //roation towards player
        Vector3 direction = player.position -transform.position;
        distanceToPlayer= Vector3.Distance(transform.position, player.position);
        // float angle= Mathf.Atan2(direction.x, direction.) * Mathf.Rad2Deg - 90f;
        // Quaternion q= Quaternion.AngleAxis(angle, Vector3.forward);
        // transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 90 * Time.deltaTime);
        //Debug.Log(direction);
        //direction.Normalize();
        move=direction;
    }

    private void FixedUpdate(){
        moveCharacter(move, distanceToPlayer);
    }

    void moveCharacter(Vector3 direction, float distanceToPlayer){
        //when player is close to the attack range enemy should move towards it 
        if (distanceToPlayer <= attackRange){ 
           // print("nice we moving");
            rb.MovePosition(transform.position +(direction * moveSpeed * Time.deltaTime));
            
        }

    }
}
