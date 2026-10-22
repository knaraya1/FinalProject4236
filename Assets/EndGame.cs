using UnityEngine;

public class EndGame : MonoBehaviour
{
    public bool activateObject = false;
    public GameObject targetObject;
    public GameObject targetObject2;

    void Update()
    {
        if (activateObject == true)
        {
            targetObject.SetActive(true);
            targetObject2.SetActive(true);
        }
    }
}