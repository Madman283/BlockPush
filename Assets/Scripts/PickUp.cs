using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;

    [SerializeField] private LayerMask pickupLayerMask;
    // Update is called once per frame
    private void Update()
    {
     
        if (Input.GetKeyDown(KeyCode.E))
        {
            float pickUpDistance = 2f;

            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickupLayerMask))
            {
                if (raycastHit.transform.TryGetComponent(out ObjectGrabble objectGrabble))
                {
                    Debug.Log(objectGrabble);
                }
            }
        }  

    }
}
