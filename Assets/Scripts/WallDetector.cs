using UnityEngine;

public class WallDetector : MonoBehaviour
{
    [SerializeField] private PlayerControl _player;

    private int _numberOfCollisions;
    
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Ground"))
        {
            _numberOfCollisions+=1;
            _player.StopPlayerMovement();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Ground"))
        {
            _numberOfCollisions-=1;
            if (_numberOfCollisions <= 0)
            {
                _player.StartPlayerMovement();
            }
        }
    }
}
