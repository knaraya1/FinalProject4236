using UnityEngine;

public class DestroyOnCollisionExceptTag : MonoBehaviour
{
    public string ignoreTag = "Player"; 
    public string ignoreTag2 = "FirePoint";  // Tag to ignore

    void OnCollisionEnter(Collision collision)
    {
        // If the collided object does NOT have the ignoreTag, destroy this object
        if (!collision.gameObject.CompareTag(ignoreTag) && !collision.gameObject.CompareTag(ignoreTag2))
        {
            Destroy(gameObject);
        }
    }
}
