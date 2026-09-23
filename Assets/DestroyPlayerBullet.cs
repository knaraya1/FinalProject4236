using UnityEngine;

public class DestroyOnCollision2 : MonoBehaviour
{
   // void OnCollisionEnter(Collision collision)
   // {
    //    if (!collider.CompareTag("Player") && !collider.other.CompareTag("collectible2")) 
    //    {
    //        Destroy(gameObject);
    //    }
    //}
    void OnTriggerEnter(Collider other)
    {
        if (!(other.CompareTag("Player") || other.CompareTag("collectible2"))) 
        {
            Destroy(gameObject);
        }
       
    }
}