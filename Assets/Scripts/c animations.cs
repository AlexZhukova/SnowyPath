using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class canimations : MonoBehaviour

{
    private Vector3 moveDirection;
    private Animator animator;

   


    // Update is called once per frame
    void Update()
    {
        animator = GetComponent<Animator>();
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        moveDirection = new Vector3(horizontal, 0, vertical);

        if (moveDirection == Vector3.zero)
        {
            //Idle

            animator.SetFloat("Speed", 0);
        }
        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            //Walk

            animator.SetFloat("Speed", 0.5f);
        }
        else
        {
            //Run

            animator.SetFloat("Speed", 1);
        }
    }
}
