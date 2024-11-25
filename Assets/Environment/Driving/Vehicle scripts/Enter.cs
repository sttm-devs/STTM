
using System;
using System.Collections;
using System.Collections.Generic;
//using TMPro.Examples;
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
    public GameObject VR2;
    public GameObject Movement;
    public GameObject Camera;

    Quaternion rotationInCar;
    Vector3 positionInCar;

    public bool inCar = false;
    public bool inCube = false;


    public InputActionReference RightPrimaryButton;

    void Start()
    {
        //ghtPrimaryButton.action.started += ButtonWasPressed;
        RightPrimaryButton.action.canceled += ButtonWasReleased;
    }

    // Update is called once per frame
    void Update()
    {
        positionInCar = Seat.transform.position; //set the variable to the seat object
        rotationInCar = Seat.transform.rotation;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            RightPrimaryButton.action.started += ButtonWasPressed;
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
        if (inCube == true) 
        {
            CharacterController cc = VR.GetComponent<CharacterController>();
            ContinuousMoveProviderBase move = Movement.GetComponent<ContinuousMoveProviderBase>();

            cc.enabled = true;

            VR.transform.position = positionInCar; //set the player to the seat in the car
            VR.transform.rotation = rotationInCar;
            inCar = true;
            cc.enabled = false;
            //move.enabled = false;

            //VR.transform.position = new Vector3(999.0f, 999.0f, 999.0f);
            
            //deactivates the main character XRrig activates the truck's XRrig
            //Camera.SetActive(false);
            //VR2.SetActive(true);
            VR.transform.parent = Truck.transform;
            
        }
    }

    void ButtonWasReleased(InputAction.CallbackContext context)
    {

    }

}
