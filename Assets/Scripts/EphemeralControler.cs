using System.Collections;
using UnityEngine;

public class EphemeralControler : MonoBehaviour
{
    private GameManager gm;

    void Start()
    {
        gm = FindFirstObjectByType<GameManager>();
    }

    public void disappear(Ephemeral platform)
    {
        StartCoroutine(disappearEnum(platform));
    }
    
    private IEnumerator disappearEnum(Ephemeral platform)
    {
        var susDuration = platform.sustainDuration;
        var disDuration = platform.disappearDuration;
        var es = gm.environmentSpeed;
        yield return new WaitForSeconds(susDuration*(1/es));
        platform.gameObject.SetActive(false);
        yield return new WaitForSeconds(disDuration*(1/es));
        platform.gameObject.SetActive(true);
        
        

    }
}
