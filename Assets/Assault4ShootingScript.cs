using UnityEngine;

public class RightClickToggle : MonoBehaviour
{
    public GameObject objectToDeactivate;
    public GameObject objectToActivate;
    public GameObject objectToDeactivate2;
    public GameObject menu;

    void Update()
    {
        if (Input.GetMouseButton(1)) // Right mouse button is held
        {
            objectToDeactivate.SetActive(false);
            objectToActivate.SetActive(true);
            objectToDeactivate2.SetActive(false);
        }
        else
        {
            objectToDeactivate.SetActive(true);
            objectToActivate.SetActive(false);
            if (menu.GetComponent<SimpleMenu>().isActive)
            {
                objectToDeactivate2.SetActive(true);
            }
            
        }
    }
}
