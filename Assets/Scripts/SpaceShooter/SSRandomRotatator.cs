using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSRandomRotatator : MonoBehaviour {

    public float tumble;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere * tumble;

	}
}
