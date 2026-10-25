using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public float moveSpeed = 6f;
    public float jumpHeight = 3f;
    public float gravity = -9.81f;
    public bool canMove = true;
    public GameObject managerobj;
    public SimpleMenu managerscr;

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
        //Cursor.lockState = CursorLockMode.Locked;
        SimpleMenu managerscr = managerobj.GetComponent<SimpleMenu>();
        if (managerscr.isActive == true && canMove == true) 
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            LookAround();
            //if (canMove == true)
            //{
            
            //}
        }
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
                SimpleMenu managerscr = managerobj.GetComponent<SimpleMenu>();
       // if (managerscr.isActive && canMove)
       // {

            Vector3 move = Vector3.zero;

        if (managerscr.isActive && canMove)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            move = transform.right * x + transform.forward * z;
        }

        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        move.y = velocity.y;

        controller.Move(move * moveSpeed * Time.deltaTime);
      //  }
    }
}
