using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    private GameObject[] checkpoints;
    public void ActivateCheckpoint()
    {
        switch (gameObject.name)
        {
            case "Checkpoint1":
                checkpoints = GameObject.FindGameObjectsWithTag(gameObject.name);
                foreach (GameObject checkpointObject in checkpoints)
                {
                    checkpointObject.SetActive(false);
                }

                break;
        }
    }
}
