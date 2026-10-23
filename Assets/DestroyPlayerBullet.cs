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
        if (!(other.CompareTag("Player") || !other.CompareTag("PlayerBullet") || !other.CompareTag("FirePoint"))) 
        {
            Destroy(gameObject);
        }
       
    }
    void Update()
    {
        float speed = 5f;
        Vector3 oldPos = transform.position;
        transform.position += transform.forward * speed * Time.deltaTime;

        RaycastHit hit;
        Vector3 direction = transform.position - oldPos;

        if (Physics.Raycast(oldPos, direction.normalized,
            out hit, direction.magnitude))
        {
            Debug.Log("Hit wall!");
            Destroy(gameObject);
        }
    }
    //void OnCollisionEnter(Collision collision)
    //{
    //    if (!(collision.collider.CompareTag("Player") || !collision.collider.CompareTag("PlayerBullet") || !collision.collider.CompareTag("FirePoint"))) 
    //    {
    //        Destroy(gameObject);
    //    }
    //}
}