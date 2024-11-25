using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnInput : MonoBehaviour
{
    public InputActionProperty pinch_animation_action; 
    public InputActionProperty grip_animation_action;
    public Animator hand_animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the trigger value from controller and pass it to animator
        float trigger_value = pinch_animation_action.action.ReadValue<float>();
        hand_animator.SetFloat( "Trigger", trigger_value );

        // Get the grip value from controller and pass it to animator
        float grip_value = grip_animation_action.action.ReadValue<float>();
        hand_animator.SetFloat( "Grip", grip_value );
    }
}
