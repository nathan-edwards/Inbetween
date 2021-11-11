using System;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    [SerializeField] private float speed = 5;

    private void Start()
    {
        transform.position = GameObject.FindGameObjectsWithTag("Player")[0].transform.position;
    }

    private void Update()
    {
        // Moves the object to target position
        transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Portal").transform.position, Time.deltaTime * speed);
    }
}