using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public Gameobject playerHand;
    //public Gameobject heldObject;
    //public bool holdingSomething;

    Rigidbody rig;
    //[SerializeField] Transform camT;
    //[SerializeField] float MSpeed = 6f;
    [SerializeField] float speed;
    [SerializeField] float JForce = 5f;
    [SerializeField] Transform GCheck;
    [SerializeField] LayerMask ground;
    public CharacterController controller;
    public bool collidingBox;
    bool isJumping;
    bool right;
    bool left;
    bool forward;
    bool back;
    public bool holdingSomething;
    public GameObject heldObject;
    public GameObject playerHand;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //The following establishes the inputs that give the player the ability to move

        if (right)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            right = false;
        }
        if (left)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            left = false;
        }
        if (forward)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            forward = false;
        }
        if (back)
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
            back = false;
        }
        if (isJumping)
        {
            Jump();
        }

        //Vector3 tempRotation = camT.rotation.eulerAngles;
        //transform.rotation = Quaternion.Euler(0, tempRotation.y, 0);

    }

    void Update()
    {
       
        //If the player is on ground he can jump
        if (Input.GetButtonDown("Jump") && Grounded())
        {
            isJumping = true;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            right = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            left = true;
        }
        if (Input.GetKey(KeyCode.W))
        {
            forward = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            back = true;
        }

        
       


    }
    void Jump()
    {
        //Allows player to jump
        rig.AddForce(JForce * Vector3.up, ForceMode.Impulse);
        isJumping = false;
        
    }
    
    bool Grounded()
    {
        //checks if the player is on ground
        return Physics.CheckSphere(GCheck.position, .1f, ground);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PushBox"))
        {
            collidingBox = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("PushBox"))
        {
            collidingBox = false;
        }
    }

    private void TurnPlayer()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            this.transform.rotation = Quaternion.Euler(new Vector3(0, 30, 0) + transform.localRotation.eulerAngles);
        }
    }



}
