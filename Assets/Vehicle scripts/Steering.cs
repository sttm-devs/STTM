using System.Collections;
using System.Collections.Generic;
//using TMPro.Examples;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;


public class Steering : MonoBehaviour
{
    public ActionBasedController left;
    public ActionBasedController right;
    public Transform offset;
    public Transform steeringWheel;
    public Transform steerSubset;
    public float accelerate;
    public float brake;
    public float steeringWheelAngle;
    public GameObject Truck;
    public NewBehaviourScript insideCar;

    private Transform hand;
    private Vector3 vector;
    private bool steering;
    private float angle;
    private float forwardDirection;
    private float turnSpeed = 45.0f;

    //public InputActionReference Activate;
    //public InputActionReference Reverse;

    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {
        if (insideCar.inCar)
        {
            if (hand)
            {
                //sets the position of the offset
                offset.position = hand.position;
                offset.localPosition = new Vector3(offset.localPosition.x, 0, offset.localPosition.z);

                Vector3 direct = offset.position - steeringWheel.position;
                Quaternion rotate = Quaternion.LookRotation(direct, transform.up);

                steeringWheel.rotation = rotate;
                direct.x = Mathf.Clamp(direct.x, -0.05f, 0.05f);
                direct.y = Mathf.Clamp(direct.y, -0.05f, 0.05f);
                direct.z = Mathf.Clamp(direct.z, -0.05f, 0.05f);

                if (steering)
                {
                    angle = Vector3.Angle(vector, direct);
                    Vector3 cross = Vector3.Cross(vector, direct);

                    if (cross.y < 0)
                    {
                        //if the angle is negative, it will be changed to positive
                        angle = -angle;
                    }
                    vector = direct;
                }
                else
                {
                    steering = true;
                    vector = direct;
                }

                //use the right grip button to drive forward
                if (right.activateAction.action.ReadValue<float>() > 0.0f)
                {
                    forwardDirection = accelerate;
                }

                //use the left grip button to drive backward
                else if (left.activateAction.action.ReadValue<float>() > 0.0f)
                {
                    forwardDirection = -accelerate;
                }
                else
                {
                    forwardDirection = 0;
                }

                Truck.transform.Translate(Vector3.forward * Time.deltaTime * forwardDirection);
                Truck.transform.Rotate(Vector3.up, angle * Time.deltaTime * turnSpeed);

            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            hand = other.transform;

            //sets the position of the offset
            offset.position = hand.position;
            offset.localPosition = new Vector3(offset.localPosition.x, 0, offset.localPosition.z);

            Vector3 direct = offset.position - steeringWheel.position;
            Quaternion rotate = Quaternion.LookRotation(direct, transform.up);
            
            steerSubset.SetParent(null);
            steeringWheel.rotation = rotate;
            steerSubset.SetParent(steeringWheel);
        }
    }
    
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            hand = other.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            hand = null;
            steering = false;
        }
    }
}