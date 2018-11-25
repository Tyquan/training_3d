using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSDestroyByBoundary : MonoBehaviour {

    void OnTriggerExit(Collider other)
    {
        // when something is in contact with it it will be destroyed
        Destroy(other.gameObject);
    }
}
