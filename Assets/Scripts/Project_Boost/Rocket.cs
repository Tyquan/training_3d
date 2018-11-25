using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    Rigidbody rb;
    AudioSource audioSource;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        Thrust();
        Rotate();
	}

    private void Rotate()
    {
        rb.freezeRotation = true; // take manual control of the physics
        if (Input.GetKey(KeyCode.A))
        {
            //print("Pressing A"); // thrust left
            transform.Rotate(Vector3.forward);
        } else if (Input.GetKey(KeyCode.D))
        {
            //print("Pressing D"); // thrust right
            transform.Rotate(-Vector3.forward);
        }
        rb.freezeRotation = true; // resume default physices
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space)) // Can thrust while rotating
        {
            rb.AddRelativeForce(Vector3.up);
            if (!audioSource.isPlaying) // so the audio doesnt overlap
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }
}
