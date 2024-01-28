using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    #region Fields
    public Transform portalG;
    public Transform portalR;

    /* All of the portal cameras will move relative to the player camera.
     * This means that where ever the player camera is in relation to the portals
     * The portal cameras will be in the opposite position to the portals.
     * If the player is looking at the front of the portals, then the portals will display
     */
    public Camera playerCamera;
    public Camera portalGCamera;
    public Camera portalRCamera;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
