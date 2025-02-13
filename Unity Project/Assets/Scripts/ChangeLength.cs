using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class ChangeLength : MonoBehaviour {

    public InputActionReference leftPrimaryButton;
    public InputActionReference leftSecondaryButton;
    public GameObject putterBottom;
    public bool putterHeld = false;

    float increment = 0.005f;

    public void enterHold() {
        putterHeld = true;
    }

    public void exitHold() {
        putterHeld = false;
    }

    void Update() {
        if ( putterHeld ) {
            if ( leftPrimaryButton.action.IsPressed() && putterBottom.transform.localPosition.y > -0.6f )
                putterBottom.transform.localPosition += new Vector3( 0.0f, -increment, 0.0f );
            else if ( leftSecondaryButton.action.IsPressed() && putterBottom.transform.localPosition.y < 0.0f ) 
                putterBottom.transform.localPosition += new Vector3( 0.0f, increment, 0.0f );
        }
    }
}
