using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class SplineSpeed : MonoBehaviour
{
    private GameManager gm;

    public List<SplineAnimate> balancingObjects;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gm= FindFirstObjectByType<GameManager>();
    }

    public void SpeedChange()
    {
        foreach (SplineAnimate spl in balancingObjects)
        {
            spl.MaxSpeed *= gm.environmentSpeed;
        }
    }
}
