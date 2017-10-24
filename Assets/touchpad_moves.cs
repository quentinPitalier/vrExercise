using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gvr.Internal;

public class touchpad_moves : MonoBehaviour {

	public Vector2 touchPos;
	public Vector3 test;
	private float speed = 1.0f;

	private Transform cameraTransform;

	void Start () {
		cameraTransform = Camera.main.transform;

	}
	
	// Update is called once per frame
	void Update () {

		test = Vector3.ProjectOnPlane (cameraTransform.forward, Vector3.up).normalized;
		// Example: check if touchpad was just touched
		if (GvrControllerInput.IsTouching) {

			//Position of the touch
			touchPos = GvrController.TouchPos;
			Debug.Log(touchPos);


			//transform.position = Vector3.MoveTowards(transform.position, test, speed * Time.deltaTime); Camera.main.transform.forward
			transform.position = transform.position + test * speed * Time.deltaTime;
		}



	}
}
