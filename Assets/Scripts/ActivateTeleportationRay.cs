using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class ActivateTeleportationRay : MonoBehaviour
{
    public GameObject left_teleportation;
    public GameObject right_teleportation;

    public InputActionProperty left_active;
    public InputActionProperty right_active;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        left_teleportation.SetActive( left_active.action.ReadValue<float>() > 0.1f );
        right_teleportation.SetActive( right_active.action.ReadValue<float>() > 0.1f ); 
    }
}
