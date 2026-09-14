using UnityEngine;

public class DestroyOnCollision2 : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall")) 
        {
            Destroy(gameObject);
        }
       
    }
}