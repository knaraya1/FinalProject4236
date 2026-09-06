using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Renderer targetRenderer;   // assign in Inspector
    public float value = 1f;          // 0–1 range recommended

    void Update()
    {
        // Example: value controls color from red (0) to green (1)
        Color newColor = Color.Lerp(Color.red, Color.green, value);
        targetRenderer.material.color = newColor;
    }
}
