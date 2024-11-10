/*
 * 
 * ****Maybe deleted later*****
 * 
 * 
 * 
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject VR;
    public GameObject LeftHand;
    public GameObject RightHand;
    public GameObject Truck;
    public GameObject Seat;
    public GameObject ExitSpot;

    Quaternion rotationOutside;
    Vector3 positionOutside;
    Quaternion rotationInCar;
    Vector3 positionInCar;

    public bool inCar = false;
    public bool inCube = false;

    public InputActionReference RightPrimaryButton;

    void Start()
    {
        RightPrimaryButton.action.started += ButtonWasPressed;
        RightPrimaryButton.action.canceled += ButtonWasReleased;
    }

    // Update is called once per frame
    void Update()
    {
        positionInCar = Seat.transform.position; //set the variable to the seat object
        rotationInCar = Seat.transform.rotation;
        positionOutside = ExitSpot.transform.position; //set the variable to the outside object
        rotationOutside = ExitSpot.transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inCube = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inCube = false;
        }
    }

    void ButtonWasPressed(InputAction.CallbackContext context)
    {
        Debug.Log("Something");
        if (inCube == true) 
        {
            Debug.Log("Nothing");
            VR.transform.position = positionInCar; //set the player to the seat in the car
            VR.transform.rotation = rotationInCar;
            inCar = true;

            VR.transform.parent = Truck.transform;
        }
    }

    void ButtonWasReleased(InputAction.CallbackContext context)
    {
        Debug.Log("Release");

    }

}
*/