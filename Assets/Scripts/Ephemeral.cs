using System;
using Unity.VisualScripting;
using UnityEngine;

public class Ephemeral : MonoBehaviour
{
    public int sustainDuration;
    public int disappearDuration;
    private EphemeralControler ec;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ec= FindFirstObjectByType<EphemeralControler>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void activated()
    {
        ec.disappear(this);
    }

    private void OnCollisionEnter(Collision player)
    {
        activated();
    }
}
