using UnityEngine;

public class DestroyOnCollisionExceptTag : MonoBehaviour
{
    public string ignoreTag = "Player"; 
    public string ignoreTag2 = "FirePoint"; 
    public string ignoreTag3 = "assault1tag";
    public string ignoreTag4 = "EnemyBullet";
    public string ignoreTag5 = "Enemy";
    public string ignoreTag6 = "MainCamera";
    public string ignoreTag7 = "canvastag";// Tag to ignore

    void OnCollisionEnter(Collision collision)
    {
        
        // If the collided object does NOT have the ignoreTag, destroy this object
        if (!collision.gameObject.CompareTag(ignoreTag) || !collision.gameObject.CompareTag(ignoreTag2) || !collision.gameObject.CompareTag(ignoreTag3) || !collision.gameObject.CompareTag(ignoreTag4) || !collision.gameObject.CompareTag(ignoreTag5) || !collision.gameObject.CompareTag(ignoreTag6) || !collision.gameObject.CompareTag(ignoreTag7))
        {
            //Destroy(transform.GetChild(0).gameObject);
            Debug.Log("collided with: " + collision.gameObject.tag);
            Destroy(gameObject);
        }
        else 
        {
            Debug.Log("else, collided with: " + collision.gameObject.tag);
        }
    }
    //void onTriggerEnter(Collider other)
     //   {
      //     Destroy(gameObject); 
       // }
}
