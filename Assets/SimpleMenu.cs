using UnityEngine;

public class SimpleMenu : MonoBehaviour
{
    public GameObject menuPanel;
    public bool isActive;
    public KeyCode toggleKey = KeyCode.Escape;
    public GameObject crosshair;

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {

            isActive = menuPanel.activeSelf;
            menuPanel.SetActive(!isActive);
            crosshair.SetActive(isActive);
        }
        if (!(isActive))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            //crosshair.SetActive(!isActive);
            
        }
    }
}
