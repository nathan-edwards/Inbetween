using UnityEngine;
public class EndPortal : MonoBehaviour 
{
    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<GameWin>().displayGameWin();
    }
}