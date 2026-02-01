using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SpeedMask : Mask
{
    [SerializeField] private float speedMultiplier;
    [SerializeField] private Image _blurImage;
    
    private Color _baseColor;
    
    public override void Activate()
    {
        _player.PlayerSpeed = _player.PlayerBaseSpeed;
        _player.PlayerSpeed = _player.PlayerSpeed * speedMultiplier;
        _blurImage.enabled = true;
        print(_blurImage.color.a);
        _baseColor = _blurImage.color;
        StartCoroutine(_blurCoroutine());
    }

    public override void Deactivate()
    {
        _player.PlayerSpeed = _player.PlayerBaseSpeed;
        _blurImage.color = _baseColor;
        _blurImage.enabled = false;
    }

    private IEnumerator _blurCoroutine(float i = 0)
    {
        _blurImage.color = (new Color(_blurImage.color.r, _blurImage.color.g,  _blurImage.color.b, 0f));
        while (i < 10)
        {
            yield return new WaitForSeconds(0.1f);
            i += 0.1f;
            _blurImage.color = (new Color(_blurImage.color.r, _blurImage.color.g,  _blurImage.color.b, _blurImage.color.a + 1f/120f));
        }
    }
}
