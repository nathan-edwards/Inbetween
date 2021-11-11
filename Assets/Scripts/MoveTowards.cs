using System;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    // The speed that the particles will move at
    [SerializeField] private float speed = 5;

    // Sets the particle's inital transform to start at the player position
    private void Start()
    {
        transform.position = GameObject.FindGameObjectsWithTag("Player")[0].transform.position;
    }

    // Begins the movement of the particle towards the portal starting at its position set in the Start function
    private void Update()
    {
        // Moves the object to target position
        transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Portal").transform.position, Time.deltaTime * speed);
    }
}