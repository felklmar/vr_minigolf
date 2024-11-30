using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnInput : MonoBehaviour
{
    public InputActionProperty pinchAnimationAction; 
    public InputActionProperty gripAnimationAction;
    public Animator handAnimator;

    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update() {
        // Get the trigger value from controller and pass it to animator
        float triggerValue = pinchAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat( "Trigger", triggerValue );

        // Get the grip value from controller and pass it to animator
        float gripValue = gripAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat( "Grip", gripValue );
    }
}
