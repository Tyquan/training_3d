using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ProcessInput();
	}

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space)) // Can thrust while rotating
        {
            print("Pressing Space");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            print("Pressing A");
        } else if (Input.GetKeyDown(KeyCode.D))
        {
            print("Pressing D");
        }
    }
}
