using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class RBController : MonoBehaviour
{
    private Rigidbody rb;

    private Camera cam;

    public GameObject player;

    public float moveSpeed = 100;
    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        TurnPlayer();
    }

    void TurnPlayer()
    {
        player.transform.rotation = Quaternion.Euler( Vector3.Scale(cam.transform.rotation.eulerAngles, new Vector3(0,1,0)) );
    }

    void Move()
    {
        if (Input.GetAxis("Vertical")>0)
        {
            rb.AddForce(Vector3.Scale(cam.transform.forward.normalized * (Input.GetAxis("Vertical") * moveSpeed),new Vector3(1,0,1)));
        }

        if (Input.GetAxis("Vertical")<0)
        {
            rb.AddForce(Vector3.Scale(cam.transform.forward.normalized * (Input.GetAxis("Vertical") * moveSpeed),new Vector3(1,0,1)));
        }
        if (Input.GetAxis("Horizontal")>0)
        {
            rb.AddForce(Vector3.Scale(cam.transform.right.normalized * (Input.GetAxis("Horizontal") * moveSpeed),new Vector3(1,0,1)));
        }

        if (Input.GetAxis("Horizontal")<0)
        {
            rb.AddForce( Vector3.Scale(cam.transform.right.normalized * (Input.GetAxis("Horizontal") * moveSpeed),new Vector3(1,0,1)));
        }
    }

    void Jump()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            rb.AddForce(this.transform.up * 500);
        }
    }
    
    
}
