using System.Collections;
using UnityEngine;

public class ProjectileMask : Mask
{
    [SerializeField] private ProjectileBehavior ProjectilePrefab;
    [SerializeField] private Transform _launchOffset;
    [SerializeField] private int _cooldown = 10;
    private bool _canFire = false, _cooldownFinished;
    
    [SerializeField] private CameraControl _playerCamera;
    
    private void Start()
    {
        _playerCamera.HasToShake = false;
    }
    
    public override void Activate()
    {
        _canFire = true;
        _cooldownFinished = true;
        _playerCamera.HasToShake = true;
    }

    public override void Deactivate()
    {
        _canFire = false;
        _cooldownFinished = false;
        _playerCamera.HasToShake = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && (_canFire == true && _cooldownFinished == true))
        {
            StartCoroutine(ThrowProjectile());
        }

    }

    private IEnumerator ThrowProjectile()
    {
        _cooldownFinished = false;
        Quaternion target = Quaternion.Euler(0, 0, 0);
        transform.localRotation = Quaternion.identity;
        Instantiate(ProjectilePrefab, _launchOffset.position, _launchOffset.rotation);
        yield return new WaitForSeconds(_cooldown);
        _cooldownFinished = true;
    }
}
