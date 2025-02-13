using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleCheck : MonoBehaviour
{
    void OnTriggerEnter( Collider other ) {
        Debug.Log( "Ball in hole" );
        if ( other.tag == "Ball" ) {
            other.gameObject.SetActive( false );
        }
    }
}
