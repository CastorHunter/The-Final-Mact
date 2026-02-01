using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool activatedPoint = false;
    public CheckpointManager cm;

    void Start()
    {
       
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (Checkpoint point in cm.allCheckpoints)
            {
                point.activatedPoint = false;
            }
            activatedPoint = true;
            
        }
    }
}

