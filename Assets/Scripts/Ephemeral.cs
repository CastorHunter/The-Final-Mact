using System;
using Unity.VisualScripting;
using UnityEngine;

public class Ephemeral : MonoBehaviour
{
    public int sustainDuration;
    public int disappearDuration;
    public EphemeralControler ec;

    public bool playerDependant;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
