using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class HandPresencePhysics : MonoBehaviour
{
    public Transform target;
    public Renderer nonPhysicalHand;
    public float showNonPhysicalHandDist = 0.05f;


    private Rigidbody _rb;
    private Collider[] _handColliders;

    // Start is called before the first frame update
    void Start() {
        _rb = GetComponent<Rigidbody>();   
        _handColliders = GetComponentsInChildren<Collider>();
    }

    void Update() {
        ShowGhostHands();
    }

    void FixedUpdate() {
        SetHandPositionAndRotation();
    }

    private void SetHandPositionAndRotation() {
        _rb.velocity = ( target.position - transform.position ) / Time.fixedDeltaTime;
        Quaternion rotationDiff = target.rotation * Quaternion.Inverse( transform.rotation );
        rotationDiff.ToAngleAxis( out float angleInDeg, out Vector3 rotationAxis );

        Vector3 rotation_diff_deg = angleInDeg * rotationAxis;
        _rb.angularVelocity = rotation_diff_deg * Mathf.Deg2Rad / Time.fixedDeltaTime;
    }

    private void ShowGhostHands() {
        float distance = Vector3.Distance( transform.position, target.position );
        nonPhysicalHand.enabled = distance > showNonPhysicalHandDist;
    }

    public void EnableHandCollider() {
        foreach ( var item in _handColliders )
            item.enabled = true;
    }

    public void EnableHandColliderDelay( float delay ) {
        Invoke( "EnableHandCollider", delay );
    }

    public void DisableHandCollider() {
        foreach ( var item in _handColliders )
            item.enabled = false;
    }

}
