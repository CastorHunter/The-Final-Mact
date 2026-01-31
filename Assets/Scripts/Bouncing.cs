using System;
using System.Collections;
using UnityEngine;

public class Bouncing : MonoBehaviour
{
    public int verticalForce;
    public float delay;
    public int horizontalForce;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision other)
    {
        StartCoroutine(Bounce( other.gameObject ));
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private IEnumerator Bounce(GameObject bounced)
    {
        if (bounced.gameObject.CompareTag("Player"))
        {
            yield return new WaitForSeconds(delay);
            var diff=bounced.gameObject.transform.position - transform.position;
            var playerControl = bounced.GetComponent<PlayerControl>();
            playerControl.CanMove = false;
            bounced.GetComponent<Rigidbody>().AddForce(new Vector3(diff.x*horizontalForce,verticalForce,diff.z*horizontalForce));
            yield return new WaitUntil(() => playerControl.ISGrounded);
            playerControl.CanMove = true;
        }
    }
}
