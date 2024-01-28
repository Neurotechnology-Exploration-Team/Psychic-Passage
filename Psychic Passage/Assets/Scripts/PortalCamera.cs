using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
 /*
 * Three Cameras are in play at all times.
 * 
 * - The player camera is what the player sees
 * 
 * - The portal camera is what the portal this is attached to sees.
 * 
 * - The other portal camera is what the second portal on the screen sees.
 * 
 * - Each portal needs to display what the other one is seeing.
 * 
 * - The camera for each portal should be mimicing the players position in relation to the portal.
 */

    public Transform playerCamera;
    public Transform portalCamera;
    public Transform otherPortalCamera;

    // Update is called once per frame
    void LastUpdate()
    {
        portalCamera = portalCamera - playerCamera;
    }
}
