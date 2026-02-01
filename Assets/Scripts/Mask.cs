using UnityEngine;
using UnityEngine.UI;

public class Mask : MonoBehaviour
{
    public PlayerControl _player;
    public Sprite MaskSprite;
    public virtual void Activate()
    {
        print("Activated");
    }
    public virtual void Deactivate()
    {
        print("Deactivated");
    }
}
