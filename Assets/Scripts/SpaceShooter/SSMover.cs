using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSMover : MonoBehaviour {
    public float speed;
    
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(transform.forward * speed);
        // If the bullet moves past the screen then destroy it
        if (transform.position.z >= 25.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
