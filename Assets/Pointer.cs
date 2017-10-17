using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gvr.Internal;

public class Pointer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.rotation = GvrControllerInput.Orientation;
    }
}
