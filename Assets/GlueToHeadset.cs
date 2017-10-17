using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlueToHeadset : MonoBehaviour {

    public GameObject player;
    public float distanceFromCamera;

	// Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame
	void Update () {
        // Better to make the following Gameobject children of the Camera
        this.transform.position = player.transform.position + player.transform.forward * distanceFromCamera;
    }
}
