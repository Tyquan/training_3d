using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour {

    public int playerNumber = 1;
    public float speed = 12f;
    public float turnSpeed = 180f;
    public AudioSource movementAudio;
    public AudioClip engineIdle;
    public AudioClip engineDriving;
    public float pitchRange = 0.2f;

    private string movementAxisName;
    private string turnAxisName;
    private Rigidbody rb;
    private float movementInputValue;
    private float turnInputValue;
    private float originalPitch;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        rb.isKinematic = false; // allow force
        movementInputValue = 0f;
        turnInputValue = 0f;
    }
    private void OnDisable()
    {
        rb.isKinematic = true; // dont allow force
    }
    // Use this for initialization
    void Start () {
        movementAxisName = "Vertical";
        turnAxisName = "Horizontal";
        originalPitch = movementAudio.pitch;
	}

    // Update is called once per frame
    void Update()
    {
        movementInputValue = Input.GetAxis(movementAxisName);
        turnInputValue = Input.GetAxis(turnAxisName);
        EngineAudio();
    }

    private void EngineAudio ()
    {

        if (Mathf.Abs(movementInputValue) < 0.1f && Mathf.Abs(turnInputValue) < 0.1f)
        {
            // if wer'e idle (Not moving)
            if (movementAudio.clip == engineDriving)
            {
                movementAudio.clip = engineIdle;
                movementAudio.pitch = Random.Range(originalPitch - pitchRange, originalPitch + pitchRange);
                movementAudio.Play();
            }
        } else
        {
            // if wer'e driving around
            if (movementAudio.clip == engineIdle)
            {
                movementAudio.clip = engineDriving;
                movementAudio.pitch = Random.Range(originalPitch - pitchRange, originalPitch + pitchRange);
                movementAudio.Play();
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        Move();
        Turn();
	}

    private void Move()
    {
        Vector3 movement = transform.forward * movementInputValue * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }

    private void Turn()
    {
        float turn = turnInputValue * turnSpeed * Time.deltaTime;

        Quaternion turnRotation = Quaternion.Euler(0f,turn,0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
