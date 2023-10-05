using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CamController : MonoBehaviour
{
    GameObject MoveObject;
    float flSensitivity = 19f;

    Vector3 vecInitialDelta;
    void Start()
    {
        MoveObject = GameObject.Find("DaBall");
        vecInitialDelta = transform.position - MoveObject.transform.position;
    }


    void FixedUpdate()
    {
        Vector3 cameraPosition = MoveObject.transform.position + vecInitialDelta;
        transform.position = cameraPosition;
    }


    void Update()
    {

        //  transform.LookAt(MoveObject.transform);
    }

}