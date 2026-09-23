using UnityEngine;

public class DestroyAfterSpawn : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 2f); // destroy after 2 seconds
    }
}
