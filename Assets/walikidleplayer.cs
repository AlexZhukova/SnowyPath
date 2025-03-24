using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;  // Reference to Animator component
    private CharacterController characterController; // Reference to CharacterController

    void Start()
    {
        animator = GetComponent<Animator>();  // Get the Animator component attached to this GameObject
        characterController = GetComponent<CharacterController>();  // Get the CharacterController
    }

    void Update()
    {
        // Get the movement input
        float speed = new Vector3(characterController.velocity.x, 0, characterController.velocity.z).magnitude;

        // Update the animation based on movement speed
        if (speed > 0.1f) // If the player is moving
        {
            animator.SetBool("isWalking", true);
        }
        else // If the player stops
        {
            animator.SetBool("isWalking", false);
        }
    }
}
