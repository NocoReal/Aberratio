using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpDrop : MonoBehaviour 
{
    [SerializeField] private Transform holdPos;
    [SerializeField] private LayerMask pickUpLayerMask, player;
    public GameObject weapon, playerObj;

    [SerializeField] private float pickUpDistance = 2.0f;
    [SerializeField] private float pickUpForce = 150.0f;

    private GameObject heldObj;
    private Rigidbody heldObjRB;

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            if (heldObj == null) 
            {
                RaycastHit hit;             
                if (Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward), out hit, pickUpDistance)) 
                {
                    PickupObject(hit.transform.gameObject);
                    weapon.SetActive(false);
                    playerObj.GetComponent<ColorTogglePlayer>().pickedUp = true;
                }
            } 
            else 
            {
                playerObj.GetComponent<ColorTogglePlayer>().pickedUp = false;
                weapon.SetActive(true);
                DropObject();
            }
        }
        if(heldObj != null) 
        {
            MoveObject();
        }
    }
    void MoveObject()
    {
        if(Vector3.Distance(heldObj.transform.position,holdPos.position)> 0.1f)
        {
            Vector3 moveDirection = (holdPos.position - heldObj.transform.position);
            heldObjRB.AddForce(moveDirection * pickUpForce);
        }
    }
    void PickupObject(GameObject pickObj)
    {
        if(pickObj.GetComponent<Rigidbody>() != null)
        {
            heldObjRB = pickObj.GetComponent<Rigidbody>();
            heldObjRB.useGravity = false;
            heldObjRB.drag = 10;
            heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;
            heldObj = pickObj;

            heldObjRB.transform.parent = holdPos;
            
        }
    }
    void DropObject()
    {
        heldObjRB.useGravity = true;
        heldObjRB.drag = 1;
        heldObjRB.constraints = RigidbodyConstraints.None;

        heldObj.transform.parent = null;
        heldObj = null;
    }
}