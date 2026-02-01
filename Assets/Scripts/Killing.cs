using UnityEngine;

public class Killing : MonoBehaviour
{
    public CheckpointManager cm;

    public PlayerControl player;
    void Start()
    {
        
    }

    private void killing()
    {
        foreach (Checkpoint cp in cm.allCheckpoints)
        {
            if (cp.activatedPoint){player.transform.position = cp.transform.position;}
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print("killed");
        killing();
    }
}
