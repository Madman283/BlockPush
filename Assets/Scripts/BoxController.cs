using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    [HideInInspector]
    public Rigidbody rb;
    private FirstPersonController character;
    [SerializeField]
    private bool held;
    private Collider col;
    [SerializeField]
    private float dropTimer;

    private TempLerpScript lerpMove;
    private void Awake()
    {
        if (character == null)
        {
            character = GameObject.Find("Player").GetComponent<FirstPersonController>();
        }

        rb = GetComponent<Rigidbody>();
        lerpMove = this.AddComponent<TempLerpScript>();
        col = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        HoldManager();
        if (held)
        {
            ReadLerp();
            DropTimerManager();
        }
    }

    private void OnMouseDown()
    {
        if (!character.holdingSomething)
        {
            Pickup();
        }
    }

    private void ReadLerp()//grabs the values from the lerp component and makes them real.
    {
        transform.position = lerpMove.vecVal;
        lerpMove.vecTarget = character.playerHand.transform.position + (character.playerHand.transform.forward.normalized * col.bounds.extents.z);
        transform.localRotation = character.playerHand.transform.rotation;
    }

    private void Drop()//self expanatory
    {
        held = false;
        character.holdingSomething = false;
        rb.useGravity = true;
        character.heldObject = null;
    }

    private void Pickup()
    {
        if (!lerpMove.initialized)
        {
            lerpMove.Initialize(transform.position,character.playerHand.transform.position + (character.playerHand.transform.forward.normalized * col.bounds.extents.z),8,false);
        }
        dropTimer = 0;
        held = true;
        rb.useGravity = false;
        //for character purpose
        character.holdingSomething = true;
        character.heldObject = this.gameObject;
    }

    private void HoldManager()
    {
        if(held && character.holdingSomething && character.heldObject == this.GameObject() && Input.GetMouseButtonDown(0) && dropTimer >1)
        {
            Drop();
        }
    }

    void DropTimerManager()
    {
        dropTimer += Time.deltaTime;
    }
}
