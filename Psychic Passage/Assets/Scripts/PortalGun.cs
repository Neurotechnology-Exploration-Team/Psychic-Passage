using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PortalGun : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] GameObject orangePortal;
    [SerializeField] GameObject bluePortal;

    private StarterAssetsInputs _input;


    private void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_input.rightClick)
        {
            FirePortal("orange");
        }

        if(_input.leftClick)
        {
            FirePortal("blue");
        }
    }

    void FirePortal(string portalType)
    {
        RaycastHit hit;

        if(Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if(portalType == "orange")
            {
                orangePortal.transform.SetPositionAndRotation(hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
            }
            else if (portalType == "blue")
            {
                bluePortal.transform.SetPositionAndRotation(hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
            }
        }
    }
}
