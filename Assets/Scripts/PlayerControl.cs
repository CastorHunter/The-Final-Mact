using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControl : MonoBehaviour
{
    [Header("Movement")]
    public int PlayerRunSpeed, PlayerJumpHeight;
    [SerializeField] private int _playerBaseSpeed, _playerBaseJumpHeight;


    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        
    }
}
