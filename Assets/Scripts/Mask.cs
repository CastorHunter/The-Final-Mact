using UnityEngine;

public class Mask : MonoBehaviour
{
    public PlayerControl _player;
    public virtual void Activate()
    {
        print("Activated");
    }
    public virtual void Deactivate()
    {
        print("Deactivated");
    }
}
