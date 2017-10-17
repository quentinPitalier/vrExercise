using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gvr.Internal;

public class Pointer : MonoBehaviour {

    public GameObject pointerDot;

    public GameObject target;

    private Ray ray;
    private RaycastHit hit;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        // Get the orientation from the controller

        this.transform.rotation = GvrControllerInput.Orientation;

        // Create raycast

        ray = new Ray(this.transform.position, this.transform.forward);
 
        if (Physics.Raycast(ray, out hit, 1000))
        {
            Debug.DrawLine(ray.origin, hit.point);

            // Get the game Object that I've been hit by the raycast

            target = hit.transform.gameObject;

            // Enable the pointerDot

            pointerDot.SetActive(true);
            pointerDot.transform.position = hit.point;

        }

        else
        {
            // No target

            target = null;

            //Disable pointerDot
            pointerDot.SetActive(false);
        }
    }
}
