using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public float moveSpeed = 6f;
    public float jumpHeight = 3f;
    public float gravity = -9.81f;

    public Transform cameraTransform;
    private CharacterController controller;

    private float xRotation = 0f;
    private Vector3 velocity;
    private float groundedTimer = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // Lock cursor to center of screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        LookAround();
        MovePlayer();

       // if (controller.isGrounded) {
       //     Debug.Log("Is grounded");
       // }
    }

    void LookAround()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Vertical rotation (camera only)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Horizontal rotation (player body)
        transform.Rotate(Vector3.up * mouseX);
    }

    void MovePlayer()
    {
        float x = Input.GetAxis("Horizontal"); // A/D
        float z = Input.GetAxis("Vertical");   // W/S
        

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * moveSpeed * Time.deltaTime);

        // Jumping
        if (controller.isGrounded && velocity.y < 0)
            velocity.y = -2f; // small downward force to keep grounded

        if (controller.isGrounded)
        {
            groundedTimer = 0.1f;
            //Debug.Log("grounded");
        } // small buffer window
        else
            groundedTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && groundedTimer > 0f)
        {
            Debug.Log("jumping");                                   
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
