using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicPickup : MonoBehaviour
{
    [SerializeField] private LayerMask pickupMask;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Transform pickupTarget;

    [SerializeField] private float pickupRange;
    private Rigidbody currentObject;

    private StarterAssetsInputs _input;

    private void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_input.interact)
        {
            if (currentObject)
            {
                currentObject.useGravity = true;
                currentObject = null;
                return;
            }

            Ray cameraRay = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if(Physics.Raycast(cameraRay, out RaycastHit HitInfo, pickupRange, pickupMask))
            {
                currentObject = HitInfo.rigidbody;
                currentObject.useGravity = false;
            }
        }
    }

    void FixedUpdate()
    {
        if (currentObject)
        {
            Vector3 directionToPoint = pickupTarget.position - currentObject.position;
            float distanceToPoint = directionToPoint.magnitude;

            currentObject.velocity = directionToPoint * 12f * distanceToPoint;
        }
    }
}
