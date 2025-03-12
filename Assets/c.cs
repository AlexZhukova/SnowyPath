using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;       // Player's movement speed
    public float runSpeed = 10f;       // Speed when running
    public float crouchSpeed = 2.5f;   // Speed when crouching

    public float lookSpeed = 2f;       // Mouse look sensitivity
    private float pitch = 0f;          // Camera pitch for up/down rotation

    public float crouchHeight = 0.5f;  // Height when crouching
    public float standingHeight = 2f;  // Height when standing
    private bool isCrouching = false;  // Flag for crouch state

    private CharacterController characterController;   // Reference to CharacterController
    public Camera playerCamera;                          // Reference to the camera

    private bool isRunning = false;    // Flag for running state

    void Start()
    {
        // Get the CharacterController component
        characterController = GetComponent<CharacterController>();
        
        // Check if the CharacterController is attached
        if (characterController == null)
        {
            Debug.LogError("No CharacterController component found on the player!");
        }

        // Lock the cursor for first-person perspective
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Input for movement (WASD or Arrow keys)
        float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right arrow
        float vertical = Input.GetAxis("Vertical");     // W/S or Up/Down arrow

        // Debug log to check input values
        Debug.Log($"Horizontal: {horizontal}, Vertical: {vertical}");

        // Check if the player is running or crouching
        isRunning = Input.GetKey(KeyCode.LeftShift); // Hold Left Shift to run
        if (Input.GetKeyDown(KeyCode.C)) // Press 'C' to crouch
        {
            ToggleCrouch();
        }

        // Calculate current movement speed
        float currentMoveSpeed = moveSpeed;
        if (isRunning && !isCrouching)
        {
            currentMoveSpeed = runSpeed;  // Run if shift is held and not crouching
        }
        else if (isCrouching)
        {
            currentMoveSpeed = crouchSpeed;  // Crouch speed if crouching
        }

        // Calculate movement direction
        Vector3 moveDirection = transform.right * horizontal + transform.forward * vertical;

        // Debug log to show movement direction
        Debug.Log($"Movement Direction: {moveDirection}");

        // Apply movement to the player using the CharacterController
        characterController.Move(moveDirection * currentMoveSpeed * Time.deltaTime);

        // Mouse Look (camera rotation)
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Rotate the player object on the Y axis (for turning left/right)
        transform.Rotate(0, mouseX * lookSpeed, 0);

        // Rotate the camera on the X axis (for looking up/down)
        pitch -= mouseY * lookSpeed;
        pitch = Mathf.Clamp(pitch, -90f, 90f); // Prevent camera from flipping upside down
        playerCamera.transform.localRotation = Quaternion.Euler(pitch, 0f, 0f);

        // Direct key input check (WASD keys)
        if (Input.GetKey(KeyCode.W)) {
            Debug.Log("W key pressed");
        }
        if (Input.GetKey(KeyCode.A)) {
            Debug.Log("A key pressed");
        }
        if (Input.GetKey(KeyCode.S)) {
            Debug.Log("S key pressed");
        }
        if (Input.GetKey(KeyCode.D)) {
            Debug.Log("D key pressed");
        }
    }

    private void ToggleCrouch()
    {
        if (isCrouching)
        {
            // Stand up
            characterController.height = standingHeight;
            playerCamera.transform.localPosition = new Vector3(0, standingHeight / 2, 0);
        }
        else
        {
            // Crouch
            characterController.height = crouchHeight;
            playerCamera.transform.localPosition = new Vector3(0, crouchHeight / 2, 0);
        }

        isCrouching = !isCrouching;
    }
}

