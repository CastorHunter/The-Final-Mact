using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private GameObject _destroyTarget;
    public virtual void Activate()
    {
        Destroy(_destroyTarget);
    }
}
