using UnityEngine;

public class Rotating : MonoBehaviour
{
    public int speedx;
    public int speedy;
    public int speedz;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(speedx, speedy, speedz));
    }
}
