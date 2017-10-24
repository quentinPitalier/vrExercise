using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gvr;

public class SimpleTeleport : MonoBehaviour
{

    public Camera mainCam;

    Vector3 currentTargetPos;

    void Start()
    {
      //  Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };

    }

    void Update()
    {
        Quaternion ori = GvrController.Orientation;
        gameObject.transform.localRotation = ori;

        Vector3 v = GvrController.Orientation * Vector3.forward;

        ShootLaserFromTargetPosition(transform.position, v, 100f);
        //  laser.enabled = true;

        if (GvrController.ClickButton)
        {
            // teleport to location
            Vector3 pointerTeleportPos = new Vector3(currentTargetPos.x - 0.46f, 0.81f, currentTargetPos.z + 1.3f);
            gameObject.transform.position = pointerTeleportPos;
            Vector3 camTeleportPos = new Vector3(currentTargetPos.x, 1.6f, currentTargetPos.z);
            mainCam.transform.position = camTeleportPos;
        }
    }

    void ShootLaserFromTargetPosition(Vector3 targetPosition, Vector3 direction, float length)
    {
        Ray ray = new Ray(targetPosition, direction);
        RaycastHit raycastHit;

        if (Physics.Raycast(ray, out raycastHit, length))
        {

                // Show the target and follow track to the pointer
                currentTargetPos = new Vector3(raycastHit.point.x,
                                            transform.localPosition.y,
                                            raycastHit.point.z);
                transform.localPosition = currentTargetPos;
            
        }

        Vector3 endPosition = targetPosition + (length * direction);

    }

}

