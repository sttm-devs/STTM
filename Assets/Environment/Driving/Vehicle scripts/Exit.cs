using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;


public class Exit : MonoBehaviour
{

    public GameObject VR;
    public GameObject Truck;
    public GameObject ExitSpot;
    public GameObject VR2;
    public GameObject Movement;
    public GameObject Camera;

    Quaternion rotationOutside;
    Vector3 positionOutside;

    public NewBehaviourScript insideCar;
    public InputActionReference LeftPrimaryButton;

    void Start()
    {
        //gets the boolean to determine if the player is in the truck
        insideCar = Truck.GetComponent<NewBehaviourScript>();

        //determines whether the left primary button has been pressed
        LeftPrimaryButton.action.started += ButtonWasPressed;
        LeftPrimaryButton.action.canceled += ButtonWasReleased;
    }

    // Update is called once per frame
    void Update()
    {
        positionOutside = ExitSpot.transform.position; //set the variable to the outside object
        rotationOutside = ExitSpot.transform.rotation;
    }

    void ButtonWasPressed(InputAction.CallbackContext context)
    {
        if (insideCar.inCar == true)
        {
            insideCar.inCar = false;

            //VR.transform.parent = null;
            
            //deactivates the truck XRrig and reactivates main rig

            //VR2.SetActive(false);
            //Camera.SetActive(true);
            CharacterController cc = VR.GetComponent<CharacterController>();
            cc.enabled = true;

            VR.transform.parent = null;
            VR.transform.position = positionOutside; //set the player to the spot outside
            VR.transform.rotation = rotationOutside;
            //VR.SetActive(true);

        }
    }

    void ButtonWasReleased(InputAction.CallbackContext context)
    {

    }
}
