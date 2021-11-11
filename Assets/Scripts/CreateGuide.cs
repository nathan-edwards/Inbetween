using UnityEngine;
public class CreateGuide : MonoBehaviour 
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject particles;
    

    // This script will simply instantiate the Prefab when the game starts.
    private void OnTriggerEnter(Collider other)
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        Instantiate(particles, GameObject.FindGameObjectsWithTag("Player")[0].transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}