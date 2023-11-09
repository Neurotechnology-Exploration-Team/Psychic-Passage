using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] GameObject otherPortal;
    [SerializeField] GameObject player;
    public GameObject teleportPoint;
    private bool shouldTeleport = false;

    private float teleportDelay = 0;
    private GameObject objToTeleport = null;

    private PhysicPickup physicPickup = null;
    private Portal otherPortalScript = null;

    private void Start()
    {
        physicPickup = player.GetComponent<PhysicPickup>();
        otherPortalScript = otherPortal.GetComponentInChildren<Portal>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(shouldTeleport)
        {
            objToTeleport.transform.position = otherPortalScript.teleportPoint.transform.position;
            shouldTeleport = false;
        }

        if(teleportDelay > 0)
        {
            teleportDelay -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Character Layer
        if (other.gameObject.layer == 8 && teleportDelay <= 0) 
        {
            shouldTeleport = true;
            objToTeleport = player;
            otherPortalScript.teleportDelay = 0.5f;

            if (physicPickup.currentObject != null)
            {
                physicPickup.currentObject.useGravity = true;
                physicPickup.currentObject = null;
            }

            Debug.Log(other);
        }

        //Pickup Layer
        if (other.gameObject.layer == 6 && teleportDelay <= 0)
        {
            shouldTeleport = true;
            objToTeleport = other.gameObject;
            otherPortalScript.teleportDelay = 0.5f;

            if(physicPickup.currentObject != null && objToTeleport == physicPickup.currentObject.gameObject)
            {
                physicPickup.currentObject.useGravity = true;
                physicPickup.currentObject = null;
            }
        }
    }
}
