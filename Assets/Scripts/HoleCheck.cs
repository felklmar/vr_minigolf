using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleCheck : MonoBehaviour
{

    public Vector3 position;
    public Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter( Collider other ) {
        Debug.Log( "Ball in hole" );
        other.gameObject.transform.SetPositionAndRotation( position, rotation );
    }
}
