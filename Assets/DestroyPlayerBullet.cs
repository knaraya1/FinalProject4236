using UnityEngine;

public class DestroyOnCollision2 : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}