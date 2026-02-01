using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SlowMoMask : Mask
{
    [SerializeField] private int _slowMultiplier = 2;
    [SerializeField] private GameManager _gameManager;
    
    [SerializeField] private GameObject _cachImage;
    private Transform _cachTransform;

    private void Start()
    {
        _cachImage.GetComponent<Image>().enabled = false;
        _cachTransform = _cachImage.transform;
    }

    public override void Activate()
    {
        _gameManager.environmentSpeed = _gameManager.environmentSpeed * (1 / _slowMultiplier);
        _cachImage.GetComponent<Image>().enabled = true;
        //StartCoroutine(FillScreen());
    }

    public override void Deactivate()
    {
        _gameManager.environmentSpeed = 1;
        _cachImage.GetComponent<Image>().enabled = false;
    }

    private IEnumerator FillScreen()
    {
        yield return new WaitForSeconds(0.1f);
    }
}
