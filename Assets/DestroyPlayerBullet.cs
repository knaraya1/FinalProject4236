using UnityEngine;

public class DestroyOnCollision2 : MonoBehaviour
{
    [SerializeField] LayerMask hitLayers;
    public GameObject bullet;
   
    void Update()
    {
        float speed = 60f;

        Vector3 oldPos = transform.position;
        Vector3 movement = transform.forward * speed * Time.deltaTime;

        RaycastHit hit;

        if (Physics.Raycast(
            oldPos,
            movement.normalized,
            out hit,
            movement.magnitude,
            hitLayers))
        {
            transform.position = hit.point;

            Debug.Log("Hit " + hit.collider.name);

            Destroy(gameObject);
            return;
        }
        

        transform.position += movement;
    }
 
}