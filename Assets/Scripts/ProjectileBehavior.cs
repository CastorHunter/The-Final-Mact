
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    private float _speed = 7f; //vitesse de base
    private float _timeTillEnd = 5; //regle la portee/distance avant destruction du projectil
    private float _curveincrementator = 1;

    [SerializeField]
    private AudioSource _source;

    private void Start()
    {
        StartCoroutine(TimeToSlow());
    }
    void Update()
    {
        _curveincrementator += 1.5f;
        transform.position += (-transform.right * (Time.deltaTime * _speed * 3));
        transform.position += new Vector3(0, -0.01f*_curveincrementator * Time.deltaTime, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target")
        {
            other.GetComponent<Target>().Activate(); 
        }
        //_source.Play();
        Destroy(gameObject);
    }

    private IEnumerator TimeToSlow()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f); //temps attendu avant la decrementation de la vitesse
            _speed -= 0.25f * Time.deltaTime; //diminution de la vitesse
            _timeTillEnd -= 1;
            if (_timeTillEnd < 0)
            {
                ProjectileDestruction();
            }
        }
    }

    private void ProjectileDestruction()
    {
        //_source.Play();
        Destroy(gameObject);
    }
}
