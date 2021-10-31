using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlsMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody rb;
    Vector3 move;
    
    void Update()
    {
        // move.z=Input.GetAxisRaw("Vertical");
        // move.x=Input.GetAxisRaw("Horizontal");
        // move.y=0;
        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

    }

    void FixedUpdate(){
        rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
    }









    // stop the player from moving when touches an object
    //     void OnCollisionEnter(Collision collision) 
    // {
    //         if(collision.gameObject.name == "YourWallName")  // or if(gameObject.CompareTag("YourWallTag"))
    //         {
    //                     rigidbody.velocity = Vector3.zero;
    //         }
    // }
}
