using UnityEngine;

public class FloatingPickup : MonoBehaviour
{
    [Header("Rotation Settings")]
    public float rotationSpeed = 50f;

    [Header("Floating Settings")]
    public float floatSpeed = 2f;      // how fast it moves up/down
    public float floatHeight = 0.5f;   // how far it moves up/down

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Rotate the object
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        // Float up and down
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}
