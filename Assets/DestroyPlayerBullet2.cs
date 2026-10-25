using UnityEngine;

public class DestroyPlayerBullet2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet")) 
        {
            Debug.Log("Collided with bullet");
            Destroy(other.gameObject);
        }
       
    }
}
