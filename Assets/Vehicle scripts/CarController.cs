using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
public class CarController : MonoBehaviour
{

    //if player is inside car
    public NewBehaviourScript insideCar;
    public Transform steeringWheel;
    public Transform target;
    public Transform hand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hand)
        {
            //get the position of the hand in the collider
            target.position = hand.position;
            target.localPosition = new Vector3(target.localPosition.x, 0, target.localPosition.z);

            //set the rotation of the steering wheel
            Vector3 direct = target.position - steeringWheel.position;
            Quaternion rotate = Quaternion.LookRotation(direct, transform.up);
            steeringWheel.rotation = rotate;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            hand = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            hand = null;
        }
    }
}
