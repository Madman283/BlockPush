using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rig;
    //[SerializeField] float MSpeed = 6f;
    [SerializeField] float speed;
    [SerializeField] float JForce = 5f;
    [SerializeField] Transform GCheck;
    [SerializeField] LayerMask ground;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //The following establishes the inputs that give the player the ability to move

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

<<<<<<< HEAD
=======
        
>>>>>>> parent of 2a32c0c (Added ability to pick up cube)
    }

    void Update()
    {
        //If the player is on ground he can jump
        if (Input.GetButtonDown("Jump") && Grounded())
        {
            Jump();
        }

    }
    void Jump()
    {
        //Allows player to jump
        rig.velocity = new Vector3(rig.velocity.x, JForce, rig.velocity.z);       
    }
    
    bool Grounded()
    {
        //checks if the player is on ground
        return Physics.CheckSphere(GCheck.position, .1f, ground);
    }


}
