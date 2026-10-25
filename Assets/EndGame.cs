using UnityEngine;

public class EndGame : MonoBehaviour
{
    public bool activateObject = false;
    public GameObject targetObject;
    public GameObject targetObject2;
    public bool unlockgate = false;
    public bool isGameEnding = false;

    void Update()
    {
        if (activateObject == true)
        {
            isGameEnding = true;
            unlockgate = true;
            targetObject.SetActive(true);
            targetObject2.SetActive(true);
        }
    }
}