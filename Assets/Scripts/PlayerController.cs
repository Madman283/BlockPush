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
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //The following establishes the inputs that give the player the ability to move

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            right = false;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            left = false;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            forward = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
            back = false;
        }
        if (isJumping)
        {
            Jump();
        }

        TurnPlayer();

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
        Vector3 forward = new Vector3(0, cam.transform.rotation.eulerAngles.y, 0);
        this.transform.rotation = Quaternion.Euler( forward);
    }

    void UnlockMouse()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }



}
