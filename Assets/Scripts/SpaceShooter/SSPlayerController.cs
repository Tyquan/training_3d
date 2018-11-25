using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// System.Serializable means we can view this class in the Unity Editor
[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class SSPlayerController : MonoBehaviour {
    public float speed;
    public Boundary boundary;
    // Getting the player to fire shots
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate = 0.5f;

    private float nextFire = 0.0f;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    // Getting the player to fire shots
    void Update()
    {
        generateShots();
    }

    // Update is called once per frame
    void FixedUpdate () {
        movePlayer();

	}

    void movePlayer() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;
        generateMovementBoundaries();
    }

    void generateMovementBoundaries ()
    {
        rb.position = new Vector3
            (
                Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );
    }

    // Getting the player to fire shots
    void generateShots() {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            // instantiate a basic object as a game object
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }

    }
}
