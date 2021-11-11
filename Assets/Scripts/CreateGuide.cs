using UnityEngine;
public class CreateGuide : MonoBehaviour 
{
    // Reference to the Prefab.
    public GameObject particles;
    

    // This script will simply instantiate the Particle Prefab when the player collides with the object.
    private void OnTriggerEnter(Collider other)
    {
        // Instantiate the particle object at position player position and destroys it once the particle is created
        Instantiate(particles, GameObject.FindGameObjectsWithTag("Player")[0].transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}