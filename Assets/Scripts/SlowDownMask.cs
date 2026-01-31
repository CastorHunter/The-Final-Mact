using UnityEngine;

public class SlowDownMask : Mask
{
    [SerializeField] private float slowMultiplier;
    public override void Activate()
    {
        _player.PlayerSpeed = _player.PlayerSpeed / slowMultiplier;
    }

    public override void Deactivate()
    {
        _player.PlayerSpeed = _player.PlayerBaseSpeed;
    }
}
