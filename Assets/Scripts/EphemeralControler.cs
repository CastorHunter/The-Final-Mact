using System.Collections;
using UnityEngine;

public class EphemeralControler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void disappear(Ephemeral platform)
    {
        StartCoroutine(disappearEnum(platform));
    }
    
    private IEnumerator disappearEnum(Ephemeral platform)
    {
        var susDuration = platform.sustainDuration;
        var disDuration = platform.disappearDuration;
        yield return new WaitForSeconds(susDuration);
        platform.gameObject.SetActive(false);
        yield return new WaitForSeconds(disDuration);
        platform.gameObject.SetActive(true);
        
        

    }
}
