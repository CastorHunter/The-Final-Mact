using UnityEngine;

public class SlowDownMask : Mask
{
    [SerializeField] private float slowMultiplier;
    private SlowedFov _slowedFov;

    void Start()
    {
        _slowedFov = FindFirstObjectByType<SlowedFov>();
    }
    public override void Activate()
    {
        _player.PlayerSpeed = _player.PlayerSpeed / slowMultiplier;
        _slowedFov.isActive = true;
    }

    public override void Deactivate()
    {
        _slowedFov.isActive = false;
        _slowedFov.ResetFov();
    }
}
