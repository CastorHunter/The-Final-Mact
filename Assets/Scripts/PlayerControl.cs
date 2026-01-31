using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControl : MonoBehaviour
{
    [Header("Movement")]
    public float PlayerSpeed, PlayerJumpHeight;
    [SerializeField] private float _playerBaseSpeed, _playerBaseJumpHeight;
    
    public bool ISGrounded, CanMove = true;
    
    private Vector3 _lastPosition;
    private int _toRight, _toLeft, _selectedLeftMask = 0, _selectedRightMask = 0;
    private Mask _activeLeftMask, _activeRightMask;
    [SerializeField] private List<Mask> _leftMasks,  _rightMasks;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _playerBaseJumpHeight = _playerBaseJumpHeight*0.1f;
        PlayerJumpHeight = _playerBaseJumpHeight;
    }

    void Update()
    {
        if (CanMove)
        {
            transform.Translate(Vector3.forward * _playerBaseSpeed * Time.deltaTime);
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && ISGrounded)
        {
            Jump();
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            UseLeftMask();
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            UseRightMask();
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeLeftMask();
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            ChangeRightMask();
        }
    }
    
    /*
    //JUMP ALTERNATIF
    private IEnumerator Jump()
    {
        GetComponent<Rigidbody>().useGravity = false;
        for (int i = 0; i <= PlayerJumpHeight; i++)
        {
            transform.localPosition += Vector3.up;
            yield return new WaitForSeconds(0.1f * i*i*i * Time.deltaTime);
        }
        GetComponent<Rigidbody>().useGravity = true;
    }
    */

    private void Jump()
    {
        GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 0, 0);
        GetComponent<Rigidbody>().AddForce(new Vector3(0, 300, 0));
    }

    public void StopPlayerMovement()
    {
        CanMove = false;
        print("StopPlayerMovement");
    }

    public void StartPlayerMovement()
    {
        CanMove = true;
        print("StartPlayerMovement");
    }

    private void UseRightMask()
    {
        if (_activeRightMask != null)
        {
            _activeRightMask.Deactivate();
        }
        _rightMasks[_selectedRightMask].Activate();
    }

    private void UseLeftMask()
    {
        if (_activeLeftMask != null)
        {
            _activeLeftMask.Deactivate();
        }
        _leftMasks[_selectedLeftMask].Activate();
    }

    private void ChangeRightMask()
    {
        if (_rightMasks.Count > 1)
        {
            if (_selectedRightMask >= _rightMasks.Count)
            {
                _selectedRightMask = 0;
            }
            else
            {
                _selectedRightMask += 1;
            }
        }
    }

    private void ChangeLeftMask()
    {
        if (_leftMasks.Count > 1)
        {
            if (_selectedLeftMask >= _leftMasks.Count)
            {
                _selectedLeftMask = 0;
            }
            else
            {
                _selectedLeftMask += 1;
            }
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            ISGrounded = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            ISGrounded = false;
        }
    }
}
