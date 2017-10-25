using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gvr.Internal;

public class touchpad_moves : MonoBehaviour {

	public Vector2 touchPos;
	public Vector3 normalizedDDTouch;

	private float speed = 15.0f;
	private float deadZone = 0.2f;

	private Transform cameraTransform;

	void Start () {
		cameraTransform = Camera.main.transform;

	}
	
	// Update is called once per frame
	void Update () {

		// Example: check if touchpad was just touched
		if (GvrControllerInput.IsTouching) {

			//Position of the touch
			touchPos = GvrController.TouchPos;
			Debug.Log(touchPos);

			if (touchPos.y < 0.5f - deadZone) {
				normalizedDDTouch = Vector3.ProjectOnPlane (cameraTransform.forward, Vector3.up) * 0.08f;
			}
			if (touchPos.y > 0.5f + deadZone)
			{
				normalizedDDTouch = Vector3.ProjectOnPlane(cameraTransform.forward, Vector3.up) * -0.07f;
			}

			if (touchPos.x < 0.5f - deadZone)
			{
				normalizedDDTouch = cameraTransform.right * -0.07f;
			}
			if (touchPos.x > 0.5f + deadZone)
			{
				normalizedDDTouch = cameraTransform.right * 0.08f;
			}


			transform.position = transform.position + normalizedDDTouch * speed * Time.deltaTime;

			 
		}



	}
}
