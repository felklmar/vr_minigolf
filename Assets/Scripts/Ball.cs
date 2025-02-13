using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    Rigidbody rb;

    public bool wallHit;

    void Start() {
        rb = GetComponent<Rigidbody>();
        wallHit = false;
    }

    void Update() {
        if ( rb.velocity.magnitude < 0.2 && !wallHit )
            rb.velocity = new Vector3( 0, 0, 0 );
    }
}
