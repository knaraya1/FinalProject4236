using UnityEngine;

public class ProximityIncrement : MonoBehaviour
{
    public string targetTag = "Enemy";   // tag to check for
    public float detectionRange = 50f;
    public float value = 0f;
    public float incrementRate = 2f;
    public GameObject CylinderObj;

    private Transform target;

    void Start()
    {
        // Find the object with the tag
        
    }

    void Update()
    {
        GameObject obj = GameObject.FindGameObjectWithTag(targetTag);
        if (obj != null)
            target = obj.transform;

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= detectionRange)
        {
            Health yes = CylinderObj.GetComponent<Health>();
            yes.objcurrentHealth += incrementRate * Time.deltaTime;
          //  Debug.Log("isnear");
        }
    }
}

            
        
           
         