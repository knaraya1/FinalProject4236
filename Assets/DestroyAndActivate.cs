using UnityEngine;

public class DestroyAndActivate : MonoBehaviour
{
    public string playerTag = "Player";
    public GameObject objectToActivate;
    public GameObject objectToDeactivate;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            
            objectToActivate.SetActive(true);
            objectToDeactivate.SetActive(false);

            Destroy(gameObject);
        }
    }
}
