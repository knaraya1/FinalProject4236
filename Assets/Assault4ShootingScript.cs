using UnityEngine;

public class RightClickToggle : MonoBehaviour
{
    public GameObject objectToDeactivate;
    public GameObject objectToActivate;

    void Update()
    {
        if (Input.GetMouseButton(1)) // Right mouse button is held
        {
            objectToDeactivate.SetActive(false);
            objectToActivate.SetActive(true);
        }
        else
        {
            objectToDeactivate.SetActive(true);
            objectToActivate.SetActive(false);
        }
    }
}
