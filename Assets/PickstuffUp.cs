using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickstuffUp : MonoBehaviour
{
    public GameObject holder;
    public Camera cam;
    public LayerMask pickUpLayerMask;
    bool isHolding;
    private GameObject heldObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(!isHolding)
            {
                float pickUpDistance = 10000000090f;

                if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask))
                {
                    heldObj = raycastHit.collider.gameObject;
                    Debug.Log("HIT");
                    LeanTween.followDamp(heldObj.transform, holder.transform, LeanProp.position,-1);
                    if (heldObj.GetComponent<Rigidbody>().useGravity = true)
                    {
                        heldObj.GetComponent<Rigidbody>().useGravity = false;
                    }
                    isHolding = true;
                }
            }
            else
            {
                LeanTween.cancel(heldObj);
                heldObj.GetComponent<Rigidbody>().useGravity = true;
                isHolding = false;
                heldObj = null;
            }

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(cam.transform.position, cam.transform.forward);
    }


}
