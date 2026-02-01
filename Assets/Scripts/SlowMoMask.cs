using UnityEngine;

public class SlowMoMask : Mask
{
    [SerializeField] private int _slowMultiplier = 2;
    [SerializeField] private GameManager _gameManager;
    public override void Activate()
    {
        _gameManager.environmentSpeed = _gameManager.environmentSpeed * (1 / _slowMultiplier);
    }

    public override void Deactivate()
    {
        _gameManager.environmentSpeed = 1;
    }
}
