using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class HandPresencePhysics : MonoBehaviour
{
    public Transform target;
    private Rigidbody rb;
    public Renderer nonPhysicalHand;
    public float showNonPhysicalHandDist = 0.05f;
    private Collider[] handColliders;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();   
        handColliders = GetComponentsInChildren<Collider>();
    }

    void Update() {
        float distance = Vector3.Distance( transform.position, target.position );
        
        nonPhysicalHand.enabled = distance > showNonPhysicalHandDist;
        UnityEngine.Debug.Log( nonPhysicalHand.enabled );
    }

    void FixedUpdate() {
        rb.velocity = ( target.position - transform.position ) / Time.fixedDeltaTime;
        Quaternion rotationDiff = target.rotation * Quaternion.Inverse( transform.rotation );
        rotationDiff.ToAngleAxis( out float angleInDeg, out Vector3 rotationAxis );

        Vector3 rotation_diff_deg = angleInDeg * rotationAxis;
        rb.angularVelocity = rotation_diff_deg * Mathf.Deg2Rad / Time.fixedDeltaTime;
        
        //UnityEngine.Debug.Log( rb.angularVelocity + " " + rotation_diff_deg * Mathf.Deg2Rad / Time.fixedDeltaTime );
    }

    public void EnableHandCollider() {
        foreach ( var item in handColliders )
            item.enabled = true;
    }

    public void EnableHandColliderDelay( float delay ) {
        Invoke( "EnableHandCollider", delay );
    }

    public void DisableHandCollider() {
        foreach ( var item in handColliders )
            item.enabled = false;
    }

}
