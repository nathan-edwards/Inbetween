using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follower : MonoBehaviour
{
    public Transform player;
    public Rigidbody rb;
    public float moveSpeed = 5f;
    public Vector3 move;

    // Start is called before the first frame update
    void Start()
    {
        rb=this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position -transform.position;
        //Debug.Log(direction);
        // rb.rotation= Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        direction.Normalize();
        move=direction;
    }

    private void FixedUpdate(){
        moveCharacter(move);
    }

    void moveCharacter(Vector3 direction){
        rb.MovePosition(transform.position +(direction * moveSpeed * Time.deltaTime));
    }
}
