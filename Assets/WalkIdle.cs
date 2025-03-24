using UnityEngine;
using UnityEngine.AI; // Required for NavMeshAgent

public class CompanionAnimationController : MonoBehaviour
{
    private Animator animator;   // Reference to Animator component
    private NavMeshAgent agent;  // Reference to NavMeshAgent

    void Start()
    {
        animator = GetComponent<Animator>();  // Get the Animator component
        agent = GetComponent<NavMeshAgent>(); // Get the NavMeshAgent
    }

    void Update()
    {
        // Get the companion's current speed
        float speed = agent.velocity.magnitude;

        // If moving, play walking animation, otherwise play idle
        if (speed > 0.1f) // Companion is moving
        {
            animator.SetBool("isWalking", true);
        }
        else // Companion is idle
        {
            animator.SetBool("isWalking", false);
        }
    }
}