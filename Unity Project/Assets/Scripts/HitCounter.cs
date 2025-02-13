using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class HitCounter : MonoBehaviour {

    MenuScript menu;

    void Awake() {
        menu = GameObject.Find( "Hand Menu" ).GetComponent<MenuScript>();
    }

    void OnTriggerExit( Collider other ) {
        if ( other.tag == "Putter" )
            menu.increaseScore();
    }
}
