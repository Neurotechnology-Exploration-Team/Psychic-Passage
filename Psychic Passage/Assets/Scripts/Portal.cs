using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] GameObject otherPortal;
    [SerializeField] GameObject player;
    private bool shouldTeleport = false;

    private float teleportDelay = 0;
    private GameObject objToTeleport = null;

    // Update is called once per frame
    void LateUpdate()
    {
        if(shouldTeleport)
        {
            objToTeleport.transform.position = otherPortal.transform.position;
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
            otherPortal.GetComponentInChildren<Portal>().teleportDelay = 0.5f;
        }

        //Pickup Layer
        if (other.gameObject.layer == 6 && teleportDelay <= 0)
        {
            shouldTeleport = true;
            objToTeleport = other.gameObject;
            otherPortal.GetComponentInChildren<Portal>().teleportDelay = 0.5f;
        }

        Debug.Log("AAA");
    }
}
