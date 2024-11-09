using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class npcPath1 : MonoBehaviour
{


    [SerializeField] GameObject car = null;

    // [SerializeField] GameObject humanModel = null;
    [SerializeField] Transform[] Points;

    // [SerializeField] GameObject StopZone;

    [SerializeField] private float moveSpeed;

    public float rotSpeed;

    private int pointsIndex = 0;

    private bool move = true;

    void Start()
    {
        transform.position = Points[pointsIndex].transform.position;
    }


    void Update()
    {
        // if (Vector3.Distance(car.transform.position, humanModel.transform.position) < 5)
        // {
        //     move = false;
        // }
        // else
        // {
        //     move = true;
        // }

        if (move && pointsIndex <= Points.Length - 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, Points[pointsIndex].transform.position, moveSpeed * Time.deltaTime);

            Vector3 direction = Points[pointsIndex].transform.position - transform.position;
            Quaternion rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);
            rotation.x = 0;
            rotation.z = 0;
            transform.rotation = rotation;


            if (transform.position == Points[pointsIndex].transform.position)
            {
                pointsIndex ++;
            }

            if (pointsIndex == Points.Length)
            {
                pointsIndex = 0;
            }
            
        }
    }

}
