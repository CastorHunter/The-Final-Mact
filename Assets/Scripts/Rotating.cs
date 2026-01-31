using UnityEngine;

public class Rotating : MonoBehaviour
{
    public int speedx;
    public int speedy;
    public int speedz;
    private GameManager gm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gm = FindFirstObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        var es = gm.environmentSpeed;
        transform.Rotate(new Vector3(speedx*es, speedy*es, speedz*es));
    }
}
