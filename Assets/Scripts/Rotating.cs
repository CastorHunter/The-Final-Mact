using UnityEngine;

public class Rotating : MonoBehaviour
{
    public int speedx;
    public int speedy;
    public int speedz;
    private GameManager gm;
    void Start()
    {
        gm = FindFirstObjectByType<GameManager>();
    }

    void Update()
    {
        var es = gm.environmentSpeed;
        transform.Rotate(new Vector3(speedx*es, speedy*es, speedz*es));
    }
}
