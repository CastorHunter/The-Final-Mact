using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    [Header("Movement")]
    public float PlayerSpeed, PlayerJumpHeight;
    public float PlayerBaseSpeed, PlayerBaseJumpHeight;
    
    public bool ISGrounded, CanMove = true;
    
    private Vector3 _lastPosition;
    private Rigidbody _rb;
    private int _selectedLeftMask = 0, _selectedRightMask = 0;
    private Mask _activeLeftMask, _activeRightMask;
    private bool _canUseMask;
    [SerializeField] private List<Mask> _leftMasks,  _rightMasks;
    
    [SerializeField] private Image _rightMaskImage, _leftMaskImage;
    [SerializeField] private TextMeshProUGUI _cooldownText;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        PlayerBaseJumpHeight = PlayerBaseJumpHeight*0.1f;
        PlayerJumpHeight = PlayerBaseJumpHeight;
        PlayerSpeed = PlayerBaseSpeed;
        _rb = GetComponent<Rigidbody>();
        _activeLeftMask = _leftMasks[0];
        _activeRightMask = _rightMasks[0];
        _canUseMask = true;
        UpdateUI();
        UpdateCooldownUI();
    }

    void Update()
    {
        if (CanMove)
        {
            transform.Translate(Vector3.forward * (PlayerSpeed * Time.deltaTime));
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && ISGrounded)
        {
            Jump();
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if ((_canUseMask && _leftMasks[_selectedLeftMask].GetComponent<EmptyMask>() == null) && _leftMasks[_selectedLeftMask] != _activeLeftMask)
            {
                _canUseMask = false;
                StartCoroutine(MaskCooldown());
                UseLeftMask();
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if ((_canUseMask && _rightMasks[_selectedRightMask].GetComponent<EmptyMask>() == null) && _rightMasks[_selectedRightMask] != _activeRightMask)
            {
                _canUseMask = false;
                StartCoroutine(MaskCooldown());
                UseRightMask();
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Q))
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
        _rb.linearVelocity = new Vector3(0, 0, 0);
        _rb.AddForce(new Vector3(0, 300, 0));
    }

    public void StopPlayerMovement()
    {
        CanMove = false;
    }

    public void StartPlayerMovement()
    {
        CanMove = true;
    }

    private void UseRightMask()
    {
        if (_rightMasks[_selectedRightMask] != _activeRightMask)
        {
            if (_activeRightMask != null)
            {
                _activeRightMask.Deactivate();
            }
            _rightMasks[_selectedRightMask].Activate();
            _activeRightMask = _rightMasks[_selectedRightMask];
        }
    }

    private void UseLeftMask()
    {
        if (_leftMasks[_selectedLeftMask] != _activeLeftMask)
        {
            if (_activeLeftMask != null)
            {
                _activeLeftMask.Deactivate();
            }
            _leftMasks[_selectedLeftMask].Activate();
            _activeLeftMask = _leftMasks[_selectedLeftMask];
        }
    }
    
    private void ChangeRightMask()
    {
        if (_rightMasks.Count > 1)
        {
            if (_selectedRightMask >= _rightMasks.Count-1)
            {
                _selectedRightMask = 0;
            }
            else
            {
                _selectedRightMask += 1;
            }
        }
        UpdateUI();
    }

    private void ChangeLeftMask()
    {
        if (_leftMasks.Count > 1)
        {
            if (_selectedLeftMask >= _leftMasks.Count-1)
            {
                _selectedLeftMask = 0;
            }
            else
            {
                _selectedLeftMask += 1;
            }
        }
        UpdateUI();
    }
    
    private void UpdateUI()
    {
        _rightMaskImage.GetComponent<Image>().sprite = _rightMasks[_selectedRightMask].MaskSprite;
        _leftMaskImage.GetComponent<Image>().sprite = _leftMasks[_selectedLeftMask].MaskSprite;
    }

    private void UpdateCooldownUI(int cooldown = 0)
    {
        if (cooldown > 0)
        {
            _cooldownText.enabled = true;
            _cooldownText.text = cooldown.ToString();
        }
        else
        {
            _cooldownText.enabled = false;
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

    private IEnumerator MaskCooldown()
    {
        for (int i = 5; i >= 0; i--)
        {
            UpdateCooldownUI(i);
            yield return new WaitForSeconds(1f);
        }
        UpdateCooldownUI();
        _canUseMask = true;
    }
}
