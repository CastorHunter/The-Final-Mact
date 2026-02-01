using UnityEngine;

public class DeleteHandler : MonoBehaviour
{
    public GameObject objectToDisable;

    public void DisableObject()
    {
        objectToDisable.SetActive(false);
    }
}
