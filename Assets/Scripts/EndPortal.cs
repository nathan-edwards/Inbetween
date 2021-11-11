using UnityEngine;
public class EndPortal : MonoBehaviour 
{
    // When the player collides the scripts calls the function to display the Game Win Screen
    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<GameWin>().displayGameWin();
    }
}