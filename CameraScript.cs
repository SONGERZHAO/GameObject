using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public GameObject ball;
    private Vector3 disprity;
	// Use this for initialization
	void Start ()
    {
        disprity = this.transform.position - ball.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        transform.position = ball.transform.position + disprity;
		
	}
}
