using UnityEngine;

public class TransformScript : MonoBehaviour
{
    public GameObject child1;
    
    void Start()
    {
        child1 = GameObject.FindGameObjectWithTag("assault1tag1");
    }

    // Update is called once per frame
    void Update()
    {
        if (child1.activeSelf) 
        {
            this.transform.localPosition = new Vector3(0f, 0f, 0f);
        }
    }
}
