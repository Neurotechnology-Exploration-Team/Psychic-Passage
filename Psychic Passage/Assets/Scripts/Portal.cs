using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] GameObject otherPortal;
    [SerializeField] GameObject player;
    private bool shouldTeleport = false;

    private float teleportDelay = 0;

    // Update is called once per frame
    void LateUpdate()
    {
        if(shouldTeleport)
        {
            player.transform.position = otherPortal.transform.position;
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
            otherPortal.GetComponentInChildren<Portal>().teleportDelay = 0.5f;
        }

        Debug.Log("AAA");
    }
}
