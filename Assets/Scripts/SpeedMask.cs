using UnityEngine;

public class SpeedMask : Mask
{
    [SerializeField] private float speedMultiplier;
    public override void Activate()
    {
        _player.PlayerSpeed = _player.PlayerSpeed * speedMultiplier;
    }

    public override void Deactivate()
    {
        _player.PlayerSpeed = _player.PlayerBaseSpeed;
    }
}
