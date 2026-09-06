using UnityEngine;

public class DestroyAndActivate : MonoBehaviour
{
    public string playerTag = "Player";
    public GameObject objectToActivate;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            
            objectToActivate.SetActive(true);

            Destroy(gameObject);
        }
    }
}
