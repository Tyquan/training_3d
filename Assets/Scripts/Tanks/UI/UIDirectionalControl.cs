using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDirectionalControl : MonoBehaviour {

    // This class is used to make sure world space UI
    // elements such as the health bar face the correct direction.

    public bool useRelativeRotation = true;

    private Quaternion relativeRotation;

    // Use this for initialization
    void Start()
    {
        relativeRotation = transform.parent.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (useRelativeRotation)
        {
            transform.rotation = relativeRotation;
        }
    }
}
