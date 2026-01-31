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
    private int _toRight, _toLeft;

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
            StartCoroutine(Jump());
        }
    }

    private IEnumerator Jump()
    {
        
        print("Jump");
        GetComponent<Rigidbody>().linearVelocity = new Vector3(0, 0, 0);
        GetComponent<Rigidbody>().AddForce(new Vector3(0, 300, 0));
        yield return new WaitForSeconds(0.1f);
        /*
        GetComponent<Rigidbody>().useGravity = false;
        for (int i = 0; i <= PlayerJumpHeight; i++)
        {
            transform.localPosition += Vector3.up;
            yield return new WaitForSeconds(0.1f * i*i*i * Time.deltaTime);
        }
        GetComponent<Rigidbody>().useGravity = true;
        */
        
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
