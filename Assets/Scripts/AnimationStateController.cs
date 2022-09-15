using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log(animator);
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool("isWalking");
        bool forwardPressed = Input.GetKey("w");

        //if player is walking
        if (!isWalking && forwardPressed) 
        {
            animator.SetBool("isWalking", true);
        }

        //if player stops walking
        if (isWalking && !forwardPressed)
        {
            animator.SetBool("isWalking", false);
        }

        

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

    }

}
