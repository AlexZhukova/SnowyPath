using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class FriendopedeAttackAnimation : MonoBehaviour

{
    private Vector3 moveDirection;
    public Animator animator;
    public string Attack;
    public string MovingSpeed;

    


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

            animator.SetFloat(MovingSpeed, 0);
        }
        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            //Walk

            animator.SetFloat(MovingSpeed, 0.5f);
        }
        else
        {
            //Run

            animator.SetFloat(MovingSpeed, 1);
        }
    }
    public void FriendopedeAttack()
    {
        animator.SetBool(Attack, true);
    }
}
