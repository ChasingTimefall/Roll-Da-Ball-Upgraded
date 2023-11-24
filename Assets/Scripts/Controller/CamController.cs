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
        //Vector3 cameraPosition = MoveObject.transform.position + vecInitialDelta;
        //transform.position = cameraPosition;
    }

    public float rotateSpeed = 5.0f;
    public float zoomSpeed = 20.0f;

    public float distance = 5.0f;
    public float xSpeed = 120.0f;
    public float ySpeed = 120.0f;

    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;

    public float distanceMin = 1.5f;
    public float distanceMax = 25f;
    public float distanceDefault = 5.0f;

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }

    public void ResetCamera()
    {
        x = 180;
        y = 25;
    }

    float x = 0.0f;
    float y = 0.0f;
    void Update()
    {
        //float rotateHorizontal = Input.GetAxis("Mouse X");
        // float rotateVertical = Input.GetAxis("Mouse Y");

        x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
        y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

        y = ClampAngle(y, yMinLimit, yMaxLimit);

        Quaternion rotation = Quaternion.Euler(y, x, 0);

       // distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * zoomSpeed, distanceMin, distanceMax);



       // RaycastHit hit;
       // if (Physics.Linecast(MoveObject.transform.position, transform.position, out hit))
       // {
       //     distance -= hit.distance;
      //  }
        Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
        Vector3 position = rotation * negDistance + MoveObject.transform.position;

        transform.rotation = rotation;
        transform.position = position;

        //   transform.LookAt(MoveObject.transform);



        // transform.RotateAround(MoveObject.transform.position, -Vector3.up, rotateHorizontal * flSensitivity); 
        //  transform.RotateAround(Vector3.zero, transform.right, rotateVertical * flSensitivity); 
        //    transform.LookAt(MoveObject.transform);
    }


    public float distanceFromTarget = 5.0f; // Default distance from the target
    public Vector3 cameraOffset; // Offset of the camera position


}