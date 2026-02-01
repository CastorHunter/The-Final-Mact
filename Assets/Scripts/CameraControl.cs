using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraControl : MonoBehaviour {

    public float Sensitivity {
        get { return sensitivity; }
        set { sensitivity = value; }
    }
    [Range(0.1f, 9f)][SerializeField] float sensitivity = 2f;
    [Range(0f, 90f)][SerializeField] float yRotationLimit = 88f;

    Vector2 rotation = Vector2.zero;
    const string xAxis = "Mouse X";
    const string yAxis = "Mouse Y";

    private int i;
    private bool _handsUp;
    
    [SerializeField] private PlayerControl _player;

    public bool HasToShake = false;

    void Start()
    {
        StartCoroutine(Shaking());
    }
    
    void Update(){
        rotation.x += Input.GetAxis(xAxis) * sensitivity;
        rotation.y += Input.GetAxis(yAxis) * sensitivity;
        rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);
        var xRot = Quaternion.AngleAxis(rotation.x, Vector3.up);
        var yRot = Quaternion.AngleAxis(rotation.y, Vector3.left);

        transform.localRotation = yRot;
        
        _player.transform.localRotation = xRot;
    }

    private IEnumerator Shaking(float _shakeIntensity = 1)
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if (_player.CanMove || HasToShake)
            {
                _shakeIntensity = Random.Range(-_shakeIntensity, _shakeIntensity);
                if (_handsUp)
                {
                    if (i > 0)
                    {
                        transform.position += new Vector3(0, 0.02f, 0);
                        if (HasToShake)
                        {
                            transform.position += new Vector3(_shakeIntensity, 0.18f, 0);
                        }
                        _handsUp = false;
                        i -= 1;
                    }
                }
                else
                {
                    if (i < 20)
                    {
                        transform.position += new Vector3(0, -0.02f, 0);
                        if (HasToShake)
                        {
                            transform.position += new Vector3(_shakeIntensity, -0.18f, 0);
                        }
                        _handsUp = true;
                        i += 1;
                    }
                }
            }
        }
    }
}