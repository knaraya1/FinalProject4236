using UnityEngine;

public class SimpleMenu : MonoBehaviour
{
    public GameObject menuPanel;
    public bool isActive;
    public KeyCode toggleKey = KeyCode.Escape;

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            isActive = menuPanel.activeSelf;
            menuPanel.SetActive(!isActive);
        }
        if (!(isActive))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
